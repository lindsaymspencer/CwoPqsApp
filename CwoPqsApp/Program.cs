using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CwoPqsApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CwoPqsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Modified from
            // https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/

            //1. Get the IWebHost which will host this application.
            var host = CreateHostBuilder(args).Build();

            //2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of CwoPqsContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CwoPqsAppContext>();

                //4. Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
            }

            //Continue to run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
