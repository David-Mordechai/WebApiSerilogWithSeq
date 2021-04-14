using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Linq;

namespace Tools.Logger
{
    public static class LoggerSetup
    {
        // add here logs to exclude
        private static readonly string[] excludedLogs = new string[] 
        { 
            "asset.axd", 
            "WebApi/Scripts",
            "swagger/ui/images",
            "swagger/ui/css",
            "swagger/ui/lib",
            "swagger/ui/swagger-ui-min-js",
            "swagger/docs"
        };

        public static void ConfigureLogger(string seqServerUrl, string seqApiKey)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithUserName()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithHttpRequestClientHostIP()
                .Enrich.WithHttpRequestClientHostName()
                .Enrich.WithHttpRequestId()
                .Enrich.WithHttpRequestNumber()
                .Enrich.WithHttpRequestRawUrl()
                .Enrich.WithHttpRequestTraceId()
                .Enrich.WithHttpRequestType()
                .Enrich.WithHttpRequestUrl()
                .Enrich.WithHttpRequestUrlReferrer()
                .Enrich.WithHttpRequestUserAgent()
                .Enrich.WithHttpSessionId()
                .Enrich.FromLogContext()
                .Filter.ByExcluding(x => x.Properties.Any(p => excludedLogs.Any(el => p.Value.ToString().Contains(el))))
                .WriteTo.Console()
                .WriteTo.Seq(
                    serverUrl: seqServerUrl,
                    apiKey: seqApiKey,
                    controlLevelSwitch: new LoggingLevelSwitch { MinimumLevel = LogEventLevel.Information})
                .CreateLogger();
        }
    }
}
