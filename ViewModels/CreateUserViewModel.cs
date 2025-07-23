using DepositoDental.Core;
using DepositoDental.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DepositoDental.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private string _nombreUsuario;
        private string _email;
        private SecureString _password;
        private SecureString _confirmPassword;
        private string _primerNombre;
        private string _primerApellido;
        private string _telefono;
        private string _errorMessage;
        private string _successMessage;
        private bool _isLoading;

        public CreateUserViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            CreateUserCommand = new AsyncRelayCommand(CreateUserAsync, CanCreateUser);
            CancelCommand = new AsyncRelayCommand(CancelAsync);
        }

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                if (SetProperty(ref _nombreUsuario, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (SetProperty(ref _email, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public SecureString ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (SetProperty(ref _confirmPassword, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string PrimerNombre
        {
            get => _primerNombre;
            set
            {
                if (SetProperty(ref _primerNombre, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string PrimerApellido
        {
            get => _primerApellido;
            set
            {
                if (SetProperty(ref _primerApellido, value))
                {
                    ClearMessages();
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Telefono
        {
            get => _telefono;
            set => SetProperty(ref _telefono, value);
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

        public string SuccessMessage
        {
            get => _successMessage;
            set
            {
                if (SetProperty(ref _successMessage, value))
                {
                    OnPropertyChanged(nameof(HasSuccess));
                }
            }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
        public bool HasSuccess => !string.IsNullOrEmpty(SuccessMessage);

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (SetProperty(ref _isLoading, value))
                {
                    ((AsyncRelayCommand)CreateUserCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand CreateUserCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action UserCreated;
        public event Action CancelRequested;

        private bool CanCreateUser()
        {
            return !IsLoading &&
                   !string.IsNullOrWhiteSpace(NombreUsuario) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(PrimerNombre) &&
                   !string.IsNullOrWhiteSpace(PrimerApellido) &&
                   Password != null && Password.Length >= 6 &&
                   ConfirmPassword != null && PasswordsMatch();
        }

        private bool PasswordsMatch()
        {
            if (Password == null || ConfirmPassword == null)
                return false;

            var pass1 = ConvertSecureStringToString(Password);
            var pass2 = ConvertSecureStringToString(ConfirmPassword);
            return pass1 == pass2;
        }

        private async Task CreateUserAsync()
        {
            try
            {
                IsLoading = true;
                ClearMessages();

                if (!PasswordsMatch())
                {
                    ErrorMessage = "Las contraseñas no coinciden";
                    return;
                }

                var passwordString = ConvertSecureStringToString(Password);

                var success = await _authService.CrearUsuarioAsync(
                    NombreUsuario, Email, passwordString,
                    PrimerNombre, PrimerApellido, Telefono);

                if (success)
                {
                    SuccessMessage = "Usuario creado exitosamente";
                    await Task.Delay(1500); // Mostrar mensaje de éxito
                    UserCreated?.Invoke();
                }
                else
                {
                    ErrorMessage = "Error al crear usuario. Verifique que el nombre de usuario y email no existan.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error inesperado: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task CancelAsync()
        {
            await Task.Run(() => CancelRequested?.Invoke());
        }

        private void ClearMessages()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
        }

        private string ConvertSecureStringToString(SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

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
