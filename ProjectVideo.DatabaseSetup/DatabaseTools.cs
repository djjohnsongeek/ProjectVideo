using CsvHelper;
using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectVideo.DatabaseSetup.Localization;
using ProjectVideo.Infrastructure;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace ProjectVideo.DatabaseSetup
{
	public class DatabaseTools
    {

        private const string LocalizationFileName = "Project Proposal Form Localization.csv";
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
            var userRole = await dbContext.Roles.Where(x => x.Name.ToLower() == "user").FirstOrDefaultAsync();

			if (adminRole != null)
            {
                var adminUser = new User
                {
                    Email = "danieleejohnson@gmail.com",
                    FirstName = "Daniel",
                    LastName = "Johnson",
                    HashedPassword = pwHasher.HashPassword("password"),
                    UserName = "daniel-johnson",
                };

                adminUser.Roles.Add(adminRole);
                adminUser.Roles.Add(userRole);

				dbContext.Users.Add(adminUser);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProposalFormLocalization()
        {
			var options = new DbContextOptionsBuilder<ProjectVideoDbContext>();
			options.UseSqlServer(ConnectionString)
				.EnableDetailedErrors()
				.EnableSensitiveDataLogging();

			var dbContext = new ProjectVideoDbContext(options.Options);

			// test
			List<ProjectProposalCSVRecord> proposalFormRecords = ParseProposalFormRecords();

            var englishForm = new ProjectProposalFormLocalization(Core.AppLanguage.English);
            var thaiForm = new ProjectProposalFormLocalization(Core.AppLanguage.Thai);

            foreach (var record in proposalFormRecords)
            {
                // English
                PropertyInfo? englishProperty = englishForm.GetType().GetProperty(record.ControlName);
                if (englishProperty != null)
                {
                    englishProperty.SetValue(englishForm, record.English);
                }

                // thai
				PropertyInfo? thaiProperty = thaiForm.GetType().GetProperty(record.ControlName);
				if (thaiProperty != null)
				{
					thaiProperty.SetValue(thaiForm, record.Thai);
				}
			}

            string? tableName = dbContext.Model.FindEntityType(typeof(ProjectProposalFormLocalization))?.GetTableName();
            if (tableName != null)
            {
                await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}");
                dbContext.ProjectProposalFormLocalizations.Add(englishForm);   
                dbContext.ProjectProposalFormLocalizations.Add(thaiForm);
                await dbContext.SaveChangesAsync();
            }
		}

        private List<ProjectProposalCSVRecord> ParseProposalFormRecords()
        {
            List<ProjectProposalCSVRecord> records = [];

            string localizationFilePath = Path.Join(
                Directory.GetCurrentDirectory(),
                LocalizationDirectoryName,
                LocalizationFileName
            );

            try
            {
                using var reader = new StreamReader(localizationFilePath);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                records = csvReader.GetRecords<ProjectProposalCSVRecord>().ToList();
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

            return records;
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
