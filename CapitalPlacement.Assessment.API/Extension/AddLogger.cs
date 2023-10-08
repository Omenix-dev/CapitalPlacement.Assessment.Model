using Serilog.Events;
using Serilog;
using Serilog.Core;

namespace CapitalPlacement.Assessment.API.Extension
{
    public static class AddLogger
    {
        public static Logger SerilogRegister(IConfiguration config)
        {
            var log = new LoggerConfiguration()
                       .MinimumLevel.Debug()
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Information) // Adjust the log levels as needed
                       .Enrich.FromLogContext()
                       .WriteTo.Console() // Configure Serilog to log to the console
                       .CreateLogger();
            return log;
        }
    }
}
