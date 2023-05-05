using System.Reflection;

namespace PruebaCrud.Services.IServices
{
    public interface IDbMigrationService
    {
        void RunMigrationsFromAssembly(string connString, Assembly assembly, string scriptsFolder);
    }
}
