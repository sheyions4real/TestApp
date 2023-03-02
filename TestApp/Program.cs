using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using TestApp.Interface;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            serviceProvider = host.Services;

            //Application.Run(new MainForm());
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider serviceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IFileOperations, FileOperations>();
                    services.AddTransient<LogFile>();
                    services.AddTransient<MainForm>();
                });
        }
    }
}
