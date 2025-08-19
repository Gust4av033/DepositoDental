using DepositoDental.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DepositoDental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        // Constructor CON inyección de dependencias (para DI)
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            DataContext = _viewModel;

            InitializeWindow();
        }

        // Constructor SIN parámetros (fallback para XAML designer)
        public MainWindow() : this(null)
        {
            // Solo para el diseñador de XAML
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            // En runtime, obtener el ViewModel del ServiceProvider
            try
            {
                if (App.ServiceProvider != null)
                {
                    var viewModel = App.ServiceProvider.GetService<MainViewModel>();
                    if (viewModel != null)
                    {
                        DataContext = viewModel;
                        _viewModel = viewModel;
                        InitializeWindow();
                    }
                }
            }
            catch (Exception ex)
            {
                // Si falla, crear un ViewModel básico
                System.Diagnostics.Debug.WriteLine($"Error obteniendo MainViewModel: {ex.Message}");

                // Mostrar mensaje de error
                MessageBox.Show($"Error inicializando la ventana principal: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeWindow()
        {
            // Solo inicializar si tenemos un ViewModel válido
            if (_viewModel == null) return;

            // Configuración inicial de la ventana
            Title = "Depósito Dental - Sistema ERP";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;

            // Aplicar tema actual
            ApplyCurrentTheme();

            // Suscribirse a eventos
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void ApplyCurrentTheme()
        {
            // El tema se aplicará automáticamente a través de los recursos
            // Aquí puedes agregar lógica adicional específica de la ventana principal
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Lógica adicional al cargar la ventana
            try
            {
                _viewModel?.OnWindowLoaded();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en MainWindow_Loaded: {ex.Message}");
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            // Guardar estado antes de cerrar
            try
            {
                _viewModel?.OnWindowClosing();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en MainWindow_Closing: {ex.Message}");
            }

            // Aquí puedes agregar confirmación de cierre si es necesario
            // e.Cancel = !ConfirmClose();
        }

        // Método para confirmar cierre (opcional)
        private bool ConfirmClose()
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea cerrar la aplicación?",
                "Confirmar cierre",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }

    }
}