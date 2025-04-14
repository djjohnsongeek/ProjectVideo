using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Data.SqlClient;
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
