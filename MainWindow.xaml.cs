using DepositoDental.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            // Establecer el usuario actual después del login
            var loginViewModel = App.ServiceProvider.GetService<LoginViewModel>();
            if (loginViewModel != null && loginViewModel.CurrentUser != null)
            {
                _viewModel.SetCurrentUser(loginViewModel.CurrentUser);
            }
        }

    }
}