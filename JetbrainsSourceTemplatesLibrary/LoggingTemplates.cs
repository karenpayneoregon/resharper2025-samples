using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JetbrainsSourceTemplatesLibrary;
public static class LoggingTemplates
{
    /// <summary>
    /// Configures Serilog.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> instance used to configure the application's logging.
    /// </param>
    /// <remarks>
    /// This method sets up Serilog with a default configuration that overrides logging levels for 
    /// "Microsoft" and "System" namespaces to <see cref="Serilog.Events.LogEventLevel.Warning"/>.
    /// It also sets the minimum logging level to <see cref="Serilog.Events.LogEventLevel.Information"/> 
    /// and writes logs to the console.
    ///
    /// In non-development environments, it configures Serilog to log messages to a file with verbose 
    /// logging enabled. The log files are stored in a directory named "LogFiles" under the application's 
    /// base directory, with a separate file for each day.
    ///
    /// Useful for quickly setting up logging for development and debugging purposes.
    ///
    /// 
    /// </remarks>
    [SourceTemplate]
    public static void serilogConfigure(this WebApplicationBuilder builder)
    {

        if (builder.Environment.IsDevelopment())
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
        }
        else
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Information()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month:d2}-{DateTime.Now.Day:d2}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }


        builder.Host.UseSerilog();
    }


}
