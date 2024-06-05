using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace HN.Management.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            //Initialize Logger
            // Log.Logger = new LoggerConfiguration()
            // .ReadFrom.Configuration(config)
            // .CreateLogger();
            try
            {
                //Log.Information("Application Starting.");
                CreateHostBuilder(args)
                    .UseDefaultServiceProvider(opt =>
                    {
                        // this overrides the default service provider options
                        // so that it doesn't validate the service collection (which raises exceptions)
                    })
                    .Build().Run();
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "The Application failed to start.");
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            
          Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
