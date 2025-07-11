using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using System.Reflection;

namespace ProjectVideo.DatabaseSetup
{
    public class DatabaseTools
    {

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
