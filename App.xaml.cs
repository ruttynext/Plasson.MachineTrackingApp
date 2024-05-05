using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Serilog;
using Serilog.Filters;
using Microsoft.Extensions.Configuration;

namespace Plasson.MachineTrackingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
          
            // Initialize Serilog logger
            Log.Logger = new LoggerConfiguration()
             .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

            Log.Information("Starting application");

            base.OnStartup(e);

        }


        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // Close and flush Serilog logger
            Log.CloseAndFlush();
        }

    }

}
