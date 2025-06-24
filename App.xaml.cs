using DepositoDental.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace DepositoDental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Aquí lee la cadena de conexión desde el appsettings.json
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // --- REGISTRO DE SERVICIOS Y VIEWMODELS ---

            // Registra tus servicios
            // services.AddTransient<IClienteService, ClienteService>();

            // Registra tus ViewModels
            // services.AddSingleton<MainViewModel>();

            // Registra tu ventana principal
            services.AddTransient<MainWindow>();
        }
    }

}
