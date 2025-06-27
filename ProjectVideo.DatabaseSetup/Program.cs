using DbUp.Engine;

namespace ProjectVideo.DatabaseSetup
{
	internal class Program
	{
        private const string SEED_ACTION = "seed";
        private const string DB_INIT = "init";

        static async Task Main(string[] args)
		{
            (bool seed, bool init, string connStr) = ParseArgs(args);
            if (string.IsNullOrEmpty(connStr))
            {
                WriteLine("No SQL connection string argument found.", ConsoleColor.Yellow);
                Environment.Exit(1);
            }

            DatabaseTools dbTools = new DatabaseTools(connStr);
            // Attempt to Migrate the Database
            try
            {
                DatabaseUpgradeResult result = dbTools.RunMigrations(seed);
                if (result.Successful)
                {
                    if (init)
                    {
                        await dbTools.InitDatabseForProduction();
                    }

                    WriteLine("Database migration successful!", ConsoleColor.Green);
                    Environment.ExitCode = 0;
                }
                else
                {
                    WriteLine("Database migration failed.", ConsoleColor.Red);
                    Environment.ExitCode = 1;
                }
            }
            catch (Exception e)
            {
                WriteLine($"An unexpected error occured: {e.Message}");
                if (e.InnerException != null)
                {
                    WriteLine($"Inner Exception: {e.InnerException}", ConsoleColor.Yellow);
                }
                WriteLine("--- Stack Trace ---");
                WriteLine(e.StackTrace);

                Environment.ExitCode = 1;
            }
        }

        private static void WriteLine(string? message, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static (bool seed, bool init, string connectionString) ParseArgs(string[] args)
        {
            (bool seed, bool init, string connStr) result = (false, false, "");

            foreach (string s in args)
            {
                Console.Write(s + ",");
            }
            Console.WriteLine();

            if (args.Length < 4 && args.Length > 1)
            {
                foreach (string arg in args)
                {
                    if (arg == SEED_ACTION)
                    {
                        result.seed = true;
                    }

                    if (arg == DB_INIT)
                    {
                        result.init = true;
                    }

                    if (arg.Contains("Server=") || arg.Contains("Data Source="))
                    {
                        result.connStr = arg;
                    }
                }
            }
            Console.WriteLine(result);

            return result;
        }
    }
}
