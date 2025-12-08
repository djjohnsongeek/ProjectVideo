using CsvHelper;
using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Infrastructure;
using ProjectVideo.Infrastructure.Data;
using System.Globalization;
using System.Reflection;
using System.Data.Common;

namespace ProjectVideo.DatabaseSetup
{
	public class DatabaseTools
    {

        private const string LocalizationFileName = "Localizations.csv";
        private const string LocalizationDirectoryName = "Localization";

        private readonly string ConnectionString;
        private readonly string DatabaseName;
        private readonly string SnapShotName;
        private readonly string ProjectNamespace = $"{nameof(ProjectVideo)}.{nameof(ProjectVideo.DatabaseSetup)}";

        public DatabaseTools(string connectionString)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
            ConnectionString = connectionString;

            var conn = new SqlConnection(ConnectionString);
            DatabaseName = conn.Database;
            SnapShotName = DatabaseName + "_SnapShot";
            conn.Dispose();
        }

        /// <summary>
        /// Initializes the database, optionally seeds with test data.
        /// </summary>
        /// <param name="seedWithTestData"></param>
        /// <returns></returns>
        public DatabaseUpgradeResult RunMigrations(bool seedWithTestData = false)
        {
            EnsureDatabase.For.SqlDatabase(ConnectionString);

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            var dbUpgradeEngineBuilder = DeployChanges.To
                .SqlDatabase(ConnectionString)
                .JournalToSqlTable("dbo", "_Migrations")
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"{ProjectNamespace}.Scripts.PreMigration"), new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 0 })
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"{ProjectNamespace}.Scripts.Migration"), new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 1 })
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"{ProjectNamespace}.Scripts.PostMigration"), new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 2 })
                .WithTransactionPerScript()
                .LogToConsole();

            if (seedWithTestData)
            {
                dbUpgradeEngineBuilder = dbUpgradeEngineBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"{ProjectNamespace}.Scripts.TestData"), new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 3 });
            }

            var upgradeEngine = dbUpgradeEngineBuilder.Build();
            var scriptsToExecute = upgradeEngine.GetScriptsToExecute();
            var result = upgradeEngine.PerformUpgrade();
            var executedScripts = upgradeEngine.GetExecutedScripts();



			return result;
        }

        public async Task SeedWithEF()
        {
            var options = new DbContextOptionsBuilder<ProjectVideoDbContext>();
            options.UseSqlServer(ConnectionString)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            var dbContext = new ProjectVideoDbContext(options.Options);
            var pwHasher = new PasswordHasher();

            var adminRole = await dbContext.Roles.Where(x => x.Name.ToLower() == "admin").FirstOrDefaultAsync();

			if (adminRole != null)
            {
                var adminUser = new User
                {
                    Email = "danieleejohnson@gmail.com",
                    FirstName = "Daniel",
                    LastName = "Johnson",
                    HashedPassword = pwHasher.HashPassword("password"),
                    UserName = "admin",
                };

                adminUser.Roles.Add(adminRole);

				dbContext.Users.Add(adminUser);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateLocalizationRecords()
        {
			var options = new DbContextOptionsBuilder<ProjectVideoDbContext>();
			options.UseSqlServer(ConnectionString)
				.EnableDetailedErrors()
				.EnableSensitiveDataLogging();

			var dbContext = new ProjectVideoDbContext(options.Options);

			// Truncate
            await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE [Localizations]");

            // Seed
			List<LocalizationRow> localizationRows = ParseLocalizationRows();
            foreach (var row in localizationRows)
            {
                var newLocalization = new Localization
                {
                    ControlName = row.ControlName,
                    Page = row.Page,
                    English = row.English,
                    Thai = row.Thai
                };
                dbContext.Localizations.Add(newLocalization);
            }

            await dbContext.SaveChangesAsync();
		}

        private List<LocalizationRow> ParseLocalizationRows()
        {
            List<LocalizationRow> rows = [];

            string localizationFilePath = Path.Join(
                Directory.GetCurrentDirectory(),
                LocalizationDirectoryName,
                LocalizationFileName
            );

            try
            {
                using var reader = new StreamReader(localizationFilePath);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                rows = csvReader.GetRecords<LocalizationRow>().ToList();
			}
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
				Console.Error.WriteLine(e.Message);
			}
            catch (IOException e)
            {
				Console.Error.WriteLine(e.Message);
			}

            return rows;
        }

        private async Task<bool> DatabaseExists(SqlConnection conn, string dbname)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM master.sys.databases WHERE name = @DBName;";
            cmd.Parameters.AddWithValue("@DBName", dbname);

            // Check if the Database exists
            var reader = await cmd.ExecuteReaderAsync();
            bool dbExists = await reader.ReadAsync();
            await reader.DisposeAsync();

            return dbExists;
        }
    }
}
