using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.Services;

namespace TemplateRevit2025
{
    public static class Host
    {
        private static IHost _host;
        public static void Start()
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(
                new HostApplicationBuilderSettings
                {
                    ContentRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                });

            // loger

            builder.Services.AddTransient<ICreateColumnService, CreateColumnService>();
            _host = builder.Build();
            _host.Start ();
        }
        public static void Stop()
        {
            _host.StopAsync().GetAwaiter ().GetResult();
        }

        public static T GetService<T>() where T : class
        {
            return _host.Services.GetRequiredService<T>();
        }
    }
}
