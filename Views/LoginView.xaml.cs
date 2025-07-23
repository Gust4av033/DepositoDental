using DepositoDental.Core;
using DepositoDental.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DepositoDental.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            SetupEvents();

            // Foco inicial en el campo de usuario
            Loaded += (s, e) =>
            {
                if (string.IsNullOrEmpty(_viewModel.Username))
                    MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                else
                    PasswordBox.Focus();
            };
        }

        private void SetupEvents()
        {
            _viewModel.LoginSuccess += OnLoginSuccess;
            _viewModel.ShowCreateUserDialog += OnShowCreateUserDialog;
            PasswordBox.PasswordChanged += OnPasswordChanged;
            PasswordBox.KeyDown += OnPasswordBoxKeyDown;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.SecurePassword;
            }
        }

        private void OnPasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && _viewModel.LoginCommand.CanExecute(null))
            {
                _viewModel.LoginCommand.Execute(null);
            }
        }

        private void OnLoginSuccess()
        {
            Dispatcher.Invoke(() =>
            {
                DialogResult = true;
                Close();
            });
        }

        private void OnShowCreateUserDialog()
        {
            try
            {
                // Obtener el CreateUserViewModel del contenedor de DI
                var createUserViewModel = App.ServiceProvider.GetRequiredService<CreateUserViewModel>();
                var createUserView = new CreateUserView(createUserViewModel);

                // Mostrar como modal
                var result = createUserView.ShowDialog();

                if (result == true)
                {
                    // Usuario creado exitosamente
                    MessageBox.Show("Usuario creado exitosamente. Ahora puede iniciar sesión.",
                        "Usuario Creado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana de crear usuario: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ToggleTheme();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.LoginSuccess -= OnLoginSuccess;
                _viewModel.ShowCreateUserDialog -= OnShowCreateUserDialog;
            }

            base.OnClosed(e);
        }
    }
}
