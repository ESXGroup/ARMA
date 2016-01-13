using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Primitives;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ARMA
{
    public class Startup
    {
        private const string LoggerName = "ARMA-LOGGER";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


          //  log.AddConsole();

           // log.MinimumLevel = LogLevel.Verbose;

          //  var factory = new LoggerFactory();
          /*  _logger = log.CreateLogger<Program>();

            var loggingConfiguration = new ConfigurationBuilder().AddJsonFile("logging.json").Build();
            log.AddConsole(loggingConfiguration);
            loggingConfiguration.Reload();*/


            /* var settings = new ConsoleLoggerSettings()
             {
                 IncludeScopes = true,
                 Switches =
                 {
                     ["Default"] = LogLevel.Verbose,
                     ["Microsoft"] = LogLevel.Information,
                 }
             };

             factory.AddConsole(settings);*/


            // How to manually wire up file-watching without a configuration file 
            // 
            // 
            //factory.AddConsole(new RandomReloadingConsoleSettings()); 


            System.Diagnostics.Trace.Listeners.Add(new DefaultTraceListener());
            System.Diagnostics.Trace.AutoFlush = true;
            app.UseIISPlatformHandler();
          //  _logger.LogInformation("Starting TEST");
          //  _logger.LogError("This is a test stephane");

            System.Diagnostics.Trace.TraceError("Test Test Test Test");

            Debug.WriteLine("TEST TEST TEST");
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();


          //  _logger.LogDebug("This is a test of the log");
            /*  app.Run(async (context) =>
              {
                  await context.Response.WriteAsync("Hello World!");
              });*/



            app.Map("/arma", (myAppPath) => this.ConfigureMyAppPath(myAppPath, env));
        }

        private class RandomReloadingConsoleSettings : IConsoleLoggerSettings
        {
            private PhysicalFileProvider _files = new PhysicalFileProvider(PlatformServices.Default.Application.ApplicationBasePath);

            public RandomReloadingConsoleSettings()
            {
                Reload();
            }

            public IChangeToken ChangeToken { get; private set; }

            public bool IncludeScopes { get; }

            private Dictionary<string, LogLevel> Switches { get; set; }

            public IConsoleLoggerSettings Reload()
            {
                ChangeToken = _files.Watch("logging.json");
                Switches = new Dictionary<string, LogLevel>()
                {
                    ["Default"] = (LogLevel)(DateTimeOffset.Now.Second % 5 + 1),
                    ["Microsoft"] = (LogLevel)(DateTimeOffset.Now.Second % 5 + 1),
                };

                return this;
            }

            public bool TryGetSwitch(string name, out LogLevel level)
            {
                return Switches.TryGetValue(name, out level);
            }
        }


        public void ConfigureMyAppPath(IApplicationBuilder app, IHostingEnvironment env)
        {
            // the actual Configure code
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
