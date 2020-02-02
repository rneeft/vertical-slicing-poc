using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using App.Shared;
using Feature.MyName;
using Features.CountOfNames;
using Features.ListOfNames;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App4
{
    public static class Startup
    {
        public static void Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {
            var systemDir = FileSystem.CacheDirectory;
            ExtractSaveResource("App4.appsettings.json", FileSystem.CacheDirectory);
            var fullConfig = Path.Combine(systemDir, "App4.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    c.AddJsonFile(fullConfig);
                })
                .ConfigureServices((c, x) =>
                {
                    nativeConfigureServices(c, x);
                    ConfigureServices(c, x);
                })
               .ConfigureLogging(l => l.AddConsole(o =>
               {
                   //setup a console logger and disable colors since they don't have any colors in VS
                   o.DisableColors = true;
               }))
                .Build();

            ServiceProviderContainer.ServiceProvider = host.Services;
        }

        private static void ExtractSaveResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }
                }
            }
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddTransient<MyNameViewModel>();
            services.AddSingleton<ListOfNameViewModel>();
            services.AddSingleton<CountOfNamesViewModel>();

            services.AddSingleton<IMessagingCenter, MessagingCenter>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
        }
    }
}
