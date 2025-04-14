using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectVideo.DatabaseSetup;
using ProjectVideo.Infrastructure.Data;

namespace ProjectVideo.Tests.Setup
{
    public class RepoCollectionFixture : IAsyncLifetime
    {
        public readonly ProjectVideoDbContext DbContext;
        private readonly DatabaseTools DbTools;
        private readonly string TestDbConnectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;";
        private readonly string TestDbName;
        private readonly string TestDbSnapShotName;

        public RepoCollectionFixture()
        {
            TestDbName = $"ProjectsVideo_Test_{Guid.NewGuid().ToString().Replace("-", "")}";
            TestDbSnapShotName = $"{TestDbName}_SnapShot";
            var connStrBuilder = new SqlConnectionStringBuilder(TestDbConnectionStr)
            {
                InitialCatalog = TestDbName
            };

            TestDbConnectionStr = connStrBuilder.ToString();

            DbTools = new DatabaseTools(TestDbConnectionStr);
            DbContext = new ProjectVideoDbContext(GetDbContextOptions());
        }

        public async Task InitializeAsync()
        {
            var result = DbTools.RunMigrations(true);
            if (result.Successful)
            {
                await TakeDatabaseSnapShot();
            }
            else
            {
                throw new Exception("Failed to create test databse.");
            }
        }

        public async Task DisposeAsync()
        {
            await DeleteDatabase();
            await DbContext.DisposeAsync();
        }

        public async Task RestoreToInitialState()
        {
            using var connection = new SqlConnection(TestDbConnectionStr);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();

            command.CommandText = "USE [master];";
            await command.ExecuteNonQueryAsync();

            command.CommandText = $"ALTER DATABASE [{TestDbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            await command.ExecuteNonQueryAsync();

            command.CommandText = @$"
			    RESTORE DATABASE {TestDbName}
			    FROM
				    DATABASE_SNAPSHOT = '{TestDbSnapShotName}'
			;";
            await command.ExecuteNonQueryAsync();

            await command.DisposeAsync();
            await connection.CloseAsync();
        }


        private async Task TakeDatabaseSnapShot()
        {
            using var connection = new SqlConnection(TestDbConnectionStr);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "USE [master];";
            await command.ExecuteNonQueryAsync();

            command.CommandText = @$"
			    SELECT TOP 1 Physical_Name 
			    FROM sys.master_files MF
			    INNER JOIN sys.databases DB ON DB.database_id = MF.database_id
			;";
            var databaseFilePath = await command.ExecuteScalarAsync();
            databaseFilePath ??= string.Empty;

            var databaseFolderPath = Path.GetDirectoryName(databaseFilePath.ToString()) ?? string.Empty;
            var snapshotFilePath = Path.Combine(databaseFolderPath, $"{TestDbSnapShotName}.ss");

            command.CommandText = @$"
			    CREATE DATABASE {TestDbSnapShotName}
			    ON
				    (
					    NAME = {TestDbName},
					    FILENAME = '{snapshotFilePath}'
				    ) AS SNAPSHOT OF {TestDbName}
			;";
            await command.ExecuteNonQueryAsync();
            await command.DisposeAsync();
            await connection.CloseAsync();
        }

        private async Task DeleteDatabase()
        {
            await using var connection = new SqlConnection(TestDbConnectionStr);
            await connection.OpenAsync();
            await using var command = connection.CreateCommand();

            command.CommandText = $"EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{TestDbName}';";
            await command.ExecuteNonQueryAsync();

            command.CommandText = "USE [master];";
            await command.ExecuteNonQueryAsync();

            command.CommandText = $"ALTER DATABASE [{TestDbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            await command.ExecuteNonQueryAsync();

            command.CommandText = $"DROP DATABASE [{TestDbSnapShotName}];";
            await command.ExecuteNonQueryAsync();

            command.CommandText = $"DROP DATABASE [{TestDbName}];";
            await command.ExecuteNonQueryAsync();

            await command.DisposeAsync();
            await connection.CloseAsync();
        }

        private DbContextOptions<ProjectVideoDbContext> GetDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .AddLogging()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ProjectVideoDbContext>();
            builder.UseSqlServer(TestDbConnectionStr)
                   .EnableSensitiveDataLogging();

            return builder.Options;
        }
    }

    [CollectionDefinition(nameof(RepoCollection))]
    public class RepoCollection : ICollectionFixture<RepoCollectionFixture>
    {
    }
}
