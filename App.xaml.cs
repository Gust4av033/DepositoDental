using DepositoDental.Core;
using DepositoDental.DataAccess;
using DepositoDental.Services.Abstractions;
using DepositoDental.Services.Implementations;
using DepositoDental.ViewModels;
using DepositoDental.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using ControlzEx.Theming;

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

            // Configurar el AppDomain para manejar excepciones no capturadas
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            // Cargar configuración
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            // Configurar servicios
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Inicializar el tema
            InitializeTheme();

            // Mostrar ventana de login
            ShowLoginWindow();
        }

        private void InitializeTheme()
        {
            // Inicializar ThemeManager personalizado
            Core.ThemeManager.Initialize();

            // Cargar preferencia de tema guardada
            Core.ThemeManager.LoadThemePreference();
        }

        private void ShowLoginWindow()
        {
            try
            {
                var loginView = ServiceProvider.GetRequiredService<LoginView>();

                // Suscribirse al evento de login exitoso
                var loginViewModel = loginView.DataContext as LoginViewModel;
                if (loginViewModel != null)
                {
                    loginViewModel.LoginSuccess += OnLoginSuccess;
                }

                if (loginView.ShowDialog() == true)
                {
                    ShowMainWindow();
                }
                else
                {
                    // El usuario cerró la ventana de login
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al iniciar la aplicación: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void OnLoginSuccess()
        {
            // Se maneja desde el DialogResult del LoginView
        }

        private void ShowMainWindow()
        {
            try
            {
                var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al abrir la ventana principal: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // === Configuración de Entity Framework ===
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null))
                .EnableSensitiveDataLogging(false)
                .EnableDetailedErrors(false));

            // === Registro de Servicios ===
            // Servicios Core
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            // Agregar más servicios según se vayan creando
            // services.AddScoped<IProductoService, ProductoService>();
            // services.AddScoped<IClienteService, ClienteService>();
            // services.AddScoped<IInventarioService, InventarioService>();

            // === Registro de ViewModels ===
            services.AddTransient<LoginViewModel>();
            services.AddTransient<CreateUserViewModel>();
            services.AddSingleton<MainViewModel>(); // Singleton para mantener estado

            // === Registro de Vistas (Ventanas) ===
            services.AddTransient<LoginView>();
            services.AddTransient<CreateUserView>();
            services.AddTransient<MainWindow>();

            // === Configuración adicional ===
            // Agregar logging si es necesario
            // services.AddLogging(configure => configure.AddDebug());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Limpiar recursos
            if (ServiceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }

            base.OnExit(e);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            var message = exception?.Message ?? "Error desconocido";

            // Log del error (implementar logging más adelante)
            System.Diagnostics.Debug.WriteLine($"Unhandled exception: {message}");

            MessageBox.Show(
                $"Ha ocurrido un error inesperado:\n\n{message}\n\nLa aplicación se cerrará.",
                "Error Fatal",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            if (e.IsTerminating)
            {
                // Guardar estado si es necesario antes de cerrar
            }
        }
    }
}