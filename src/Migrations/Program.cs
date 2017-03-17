using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System.Configuration;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HockeyLeagueContext"].ConnectionString;

            var options = new MigrationOptions {PreviewOnly = false, Timeout = 0};
            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Trace.WriteLine(s));
            var migrationContext = new RunnerContext(announcer);

            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2012ProcessorFactory();
            var processor = factory.Create(connectionString, announcer, options);

            var runner = new MigrationRunner(Assembly.GetAssembly(typeof(Program)), migrationContext, processor);
            runner.MigrateUp();
        }

        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int Timeout { get; set; }
            public string ProviderSwitches { get; private set; }
        }
    }
}
