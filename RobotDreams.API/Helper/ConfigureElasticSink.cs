using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace RobotDreams.API.Helper
{
    public static class ConfigureElasticSink
    {
        public static ElasticsearchSinkOptions Configure(IConfigurationRoot configuration, string environment)
        {
            var a = new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = "search-2023-11"
            };
            return a;
        }
    }
}
