using DepositoDental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DepositoDental.Views
{
    /// <summary>
    /// Lógica de interacción para CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : Window
    {
        private readonly CreateUserViewModel _viewModel;

        public CreateUserView(CreateUserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            SetupEvents();

            // Foco inicial en el primer campo
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }

        private void SetupEvents()
        {
            _viewModel.UserCreated += OnUserCreated;
            _viewModel.CancelRequested += OnCancelRequested;

            PasswordBox.PasswordChanged += OnPasswordChanged;
            ConfirmPasswordBox.PasswordChanged += OnConfirmPasswordChanged;

            PasswordBox.KeyDown += OnPasswordBoxKeyDown;
            ConfirmPasswordBox.KeyDown += OnConfirmPasswordBoxKeyDown;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.SecurePassword;
            }
        }

        private void OnConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.ConfirmPassword = passwordBox.SecurePassword;
            }
        }

        private void OnPasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmPasswordBox.Focus();
            }
        }

        private void OnConfirmPasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && _viewModel.CreateUserCommand.CanExecute(null))
            {
                _viewModel.CreateUserCommand.Execute(null);
            }
        }

        private void OnUserCreated()
        {
            Dispatcher.Invoke(() =>
            {
                DialogResult = true;
                Close();
            });
        }

        private void OnCancelRequested()
        {
            Dispatcher.Invoke(() =>
            {
                DialogResult = false;
                Close();
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.UserCreated -= OnUserCreated;
                _viewModel.CancelRequested -= OnCancelRequested;
            }

            base.OnClosed(e);
        }
    }
}
