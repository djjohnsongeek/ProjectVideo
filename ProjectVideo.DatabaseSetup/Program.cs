using DbUp.Engine;

namespace ProjectVideo.DatabaseSetup
{
	internal class Program
	{
        private const string SEED_ACTION = "seed";

        static void Main(string[] args)
		{
            (bool seed, string connStr) = ParseArgs(args);
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

        private static (bool seed, string connectionString) ParseArgs(string[] args)
        {
            (bool seed, string connStr) result = (false, "");

            if (args.Length == 1 || args.Length == 2)
            {
                foreach (string arg in args)
                {
                    if (arg == SEED_ACTION)
                    {
                        result.seed = true;
                    }
                    else if (arg.Contains("Server=") || arg.Contains("Data Source="))
                    {
                        result.connStr = arg;
                    }
                }
            }

            return result;
        }
    }
}
