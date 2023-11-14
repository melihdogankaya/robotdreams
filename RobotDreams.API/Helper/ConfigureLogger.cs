using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace RobotDreams.API.Helper
{
    public static class ConfigureLogger
    {
        public static void ConfigureLogging(IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Log.Logger = new LoggerConfiguration()
                             .Enrich.FromLogContext()
                             .Enrich.WithMachineName()
                             .WriteTo.Debug()
                             .WriteTo.Console()
                             .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
                             .Enrich.WithProperty("Environment", environment)
                             .ReadFrom.Configuration(configuration)
                             .CreateLogger();
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
        {
            return new ElasticsearchSinkOptions()
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }
    }
}
