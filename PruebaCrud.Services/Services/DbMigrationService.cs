using System.Reflection;
using System.Text;
using DbUp;
using Microsoft.Extensions.Logging;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Services.Services
{
    public class DbMigrationService : IDbMigrationService
    {
        private ILogger _logger;

        public DbMigrationService(ILogger<DbMigrationService> logger)
        {
            _logger = logger;
        }

        public void RunMigrationsFromAssembly(string connString, Assembly assembly, string scriptsFolder)
        {
            EnsureDatabase.For.SqlDatabase(connString);

            var upgradeEngine =
                DeployChanges.To
                    .SqlDatabase(connString)
                    .WithScriptsEmbeddedInAssembly(assembly,
                        scriptName => scriptName.ToUpper().Contains("MIG_") &&
                                      scriptName.ToUpper().Contains(scriptsFolder.ToUpper() + "."))
                    .LogToAutodetectedLog()
                    .Build();

            if (upgradeEngine.IsUpgradeRequired())
            {
                var result = upgradeEngine.PerformUpgrade();

                if (!result.Successful)
                {
                    throw new Exception($"DB migrations failed with error: {result.Error}");
                }
                StringBuilder logMessage = new StringBuilder();
                logMessage.Append("DB migrations were applied successfully: ");

                foreach (var executedScript in upgradeEngine.GetExecutedScripts())
                {
                    logMessage.AppendLine(executedScript);
                }
                _logger.LogInformation(logMessage.ToString());
            }
            else
            {
                _logger.LogInformation("No DB migrations pending at startup");
            }
        }
    }
}
