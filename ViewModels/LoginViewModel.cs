using DepositoDental.Core;
using DepositoDental.Models.Entities;
using DepositoDental.Services.Abstractions;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DepositoDental.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isLoading;

        public LoginViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new AsyncRelayCommand(LoginAsync, CanLogin);
            ShowCreateUserCommand = new AsyncRelayCommand(ShowCreateUserAsync);
        }

        public string Username
        {
            get => _username;
            set
            {
                if (SetProperty(ref _username, value))
                {
                    ErrorMessage = string.Empty;
                    ((AsyncRelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private SecUsuario _currentUser;
        public SecUsuario CurrentUser
        {
            get => _currentUser;
            private set => SetProperty(ref _currentUser, value);
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                {
                    ErrorMessage = string.Empty;
                    ((AsyncRelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (SetProperty(ref _errorMessage, value))
                {
                    OnPropertyChanged(nameof(HasError));
                }
            }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (SetProperty(ref _isLoading, value))
                {
                    ((AsyncRelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string ThemeButtonText => IsDarkTheme ? "Modo Claro" : "Modo Oscuro";

        public ICommand LoginCommand { get; }
        public ICommand ShowCreateUserCommand { get; }

        public event Action LoginSuccess;
        public event Action ShowCreateUserDialog;

        private bool CanLogin()
        {
            return !IsLoading &&
                   !string.IsNullOrWhiteSpace(Username) &&
                   Password != null &&
                   Password.Length > 0;
        }

        private async Task LoginAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                // Simular delay de red
                await Task.Delay(1500);

                // Convertir SecureString a string
                var passwordString = ConvertSecureStringToString(Password);

                var result = await _authService.AutenticarUsuarioAsync(Username, passwordString);

                if (result.IsSuccess)
                {
                    CurrentUser = result.Usuario;
                    LoginSuccess?.Invoke();
                }
                else
                {
                    ErrorMessage = result.ErrorMessage ?? "Credenciales incorrectas";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error de conexión. Verifique su conexión a internet.";
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ShowCreateUserAsync()
        {
            await Task.Run(() => ShowCreateUserDialog?.Invoke());
        }

        protected override void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            // Actualizar texto del botón de tema cuando cambie el tema
            if (propertyName == nameof(IsDarkTheme))
            {
                OnPropertyChanged(nameof(ThemeButtonText));
            }
        }

        private string ConvertSecureStringToString(SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException(nameof(secureString));

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString) ?? string.Empty;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
