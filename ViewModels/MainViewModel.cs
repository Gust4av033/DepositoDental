using DepositoDental.Core;
using DepositoDental.Models.Entities;
using DepositoDental.Services.Abstractions;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.IconPacks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DepositoDental.Services.Abstractions; // Asegúrate de tener el using correcto para el servicio de diálogo // Asegúrate de tener el using correcto para el servicio de tema


namespace DepositoDental.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private SecUsuario _currentUser;
        private object _currentView;
        private string _pageTitle;
        private bool _isMenuOpen = true;
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private MenuItemViewModel _selectedMenuItem;
        private readonly IDialogService _dialogService; // Agrega esta línea
       // private readonly IThemeManager _themeManager; // Agrega esta línea

        public MainViewModel(IAuthenticationService authService, IDialogService dialogService)
        {
            _authService = authService;
            _dialogService = dialogService; // Asigna el servicio de diálogo
            

            // Inicializar comandos
            NavigateCommand = new RelayCommand<string>(Navigate);
            ToggleMenuCommand = new RelayCommand(ToggleMenu);
            LogoutCommand = new AsyncRelayCommand(LogoutAsync);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            ShowUserProfileCommand = new AsyncRelayCommand(ShowUserProfileAsync);

            // Inicializar menú
            InitializeMenu();

            // Establecer vista inicial
            Navigate("Dashboard");
        }

        #region Properties

        public SecUsuario CurrentUser
        {
            get => _currentUser;
            set
            {
                if (SetProperty(ref _currentUser, value))
                {
                    OnPropertyChanged(nameof(CurrentUserName));
                    OnPropertyChanged(nameof(UserInitials));
                }
            }
        }

        public string CurrentUserName => CurrentUser != null
            ? $"{CurrentUser.Primernombre} {CurrentUser.Primerapellido}"
            : "Usuario";

        public string UserInitials => CurrentUser != null
            ? $"{CurrentUser.Primernombre[0]}{CurrentUser.Primerapellido[0]}"
            : "U";

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set => SetProperty(ref _isMenuOpen, value);
        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public MenuItemViewModel SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                if (SetProperty(ref _selectedMenuItem, value) && value != null)
                {
                    Navigate(value.NavigationKey);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand NavigateCommand { get; }
        public ICommand ToggleMenuCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand ShowUserProfileCommand { get; }

        #endregion

        #region Methods

        private void InitializeMenu()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Title = "Dashboard",
                    Icon = PackIconModernKind.Home,
                    NavigationKey = "Dashboard",
                    IsSelected = true
                },
                new MenuItemViewModel
                {
                    Title = "Productos",
                    Icon = PackIconModernKind.Box,
                    NavigationKey = "Productos",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Lista de Productos", NavigationKey = "ProductosList" },
                        new MenuItemViewModel { Title = "Categorías", NavigationKey = "Categorias" },
                        new MenuItemViewModel { Title = "Marcas", NavigationKey = "Marcas" },
                        new MenuItemViewModel { Title = "Unidades de Medida", NavigationKey = "UnidadesMedida" }
                    }
                },
                new MenuItemViewModel
                {
                    Title = "Clientes",
                    Icon = PackIconModernKind.People,
                    NavigationKey = "Clientes"
                },
                new MenuItemViewModel
                {
                    Title = "Inventario",
                    Icon = PackIconModernKind.Database,
                    NavigationKey = "Inventario",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Movimientos", NavigationKey = "Movimientos" },
                        new MenuItemViewModel { Title = "Stock por Bodega", NavigationKey = "StockBodega" },
                        new MenuItemViewModel { Title = "Ajustes", NavigationKey = "AjustesInventario" }
                    }
                },
                new MenuItemViewModel
                {
                    Title = "Ventas",
                    Icon = PackIconModernKind.CurrencyDollar,
                    NavigationKey = "Ventas",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Facturas", NavigationKey = "Facturas" },
                        new MenuItemViewModel { Title = "Cotizaciones", NavigationKey = "Cotizaciones" },
                        new MenuItemViewModel { Title = "Pedidos", NavigationKey = "Pedidos" },
                        new MenuItemViewModel { Title = "Notas de Crédito", NavigationKey = "NotasCredito" }
                    }
                },
                new MenuItemViewModel
                {
                    Title = "Compras",
                    Icon = PackIconModernKind.Cart,
                    NavigationKey = "Compras",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Órdenes de Compra", NavigationKey = "OrdenesCompra" },
                        new MenuItemViewModel { Title = "Proveedores", NavigationKey = "Proveedores" }
                    }
                },
                new MenuItemViewModel
                {
                    Title = "Reportes",
                    Icon = PackIconModernKind.PageText,
                    NavigationKey = "Reportes",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Ventas", NavigationKey = "ReporteVentas" },
                        new MenuItemViewModel { Title = "Inventario", NavigationKey = "ReporteInventario" },
                        new MenuItemViewModel { Title = "Clientes", NavigationKey = "ReporteClientes" },
                        new MenuItemViewModel { Title = "Productos más vendidos", NavigationKey = "ProductosMasVendidos" }
                    }
                },
                new MenuItemViewModel
                {
                    Title = "Administración",
                    Icon = PackIconModernKind.Settings,
                    NavigationKey = "Administracion",
                    SubItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Title = "Usuarios", NavigationKey = "Usuarios" },
                        new MenuItemViewModel { Title = "Roles y Permisos", NavigationKey = "Roles" },
                        new MenuItemViewModel { Title = "Configuración", NavigationKey = "Configuracion" },
                        new MenuItemViewModel { Title = "Respaldos", NavigationKey = "Respaldos" }
                    }
                }
            };
        }

        private void Navigate(string destination)
        {
            try
            {
                // Desmarcar todos los items
                foreach (var item in MenuItems)
                {
                    item.IsSelected = false;
                    if (item.SubItems != null)
                    {
                        foreach (var subItem in item.SubItems)
                        {
                            subItem.IsSelected = false;
                        }
                    }
                }

                // Aquí navegas a la vista correspondiente
                switch (destination)
                {
                    case "Dashboard":
                        CurrentView = new DashboardViewModel();
                        PageTitle = "Dashboard";
                        break;

                    case "ProductosList":
                        // CurrentView = App.ServiceProvider.GetService<ProductoListViewModel>();
                        CurrentView = new object(); // Temporal
                        PageTitle = "Productos";
                        break;

                    case "Clientes":
                        // CurrentView = App.ServiceProvider.GetService<ClienteListViewModel>();
                        CurrentView = new object(); // Temporal
                        PageTitle = "Clientes";
                        break;

                    case "Facturas":
                        // CurrentView = App.ServiceProvider.GetService<FacturaListViewModel>();
                        CurrentView = new object(); // Temporal
                        PageTitle = "Facturas";
                        break;

                    default:
                        CurrentView = new NotImplementedViewModel { Message = $"Vista '{destination}' no implementada aún." };
                        PageTitle = destination;
                        break;
                }

                // Marcar el item seleccionado
                MarkSelectedMenuItem(destination);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, $"Error al navegar a {destination}");
            }
        }

        private void MarkSelectedMenuItem(string navigationKey)
        {
            foreach (var item in MenuItems)
            {
                if (item.NavigationKey == navigationKey)
                {
                    item.IsSelected = true;
                    return;
                }

                if (item.SubItems != null)
                {
                    foreach (var subItem in item.SubItems)
                    {
                        if (subItem.NavigationKey == navigationKey)
                        {
                            subItem.IsSelected = true;
                            item.IsExpanded = true;
                            return;
                        }
                    }
                }
            }
        }

        private void ToggleMenu()
        {
            IsMenuOpen = !IsMenuOpen;
        }

        private async Task LogoutAsync()
        {
            var result = await _dialogService.ShowMessage(
                "¿Está seguro que desea cerrar sesión?",
                "Cerrar Sesión",
                "Sí",
                "No",
                null);

            if (result)
            {
                // Limpiar datos de sesión
                CurrentUser = null;

                // Cerrar ventana actual y mostrar login
                System.Windows.Application.Current.MainWindow.Close();

                var loginView = App.ServiceProvider.GetService<Views.LoginView>();
                loginView.Show();
            }
        }

        private void ChangeTheme()
        {
            ThemeManager.ToggleTheme();
        }

        private async Task ShowUserProfileAsync()
        {
            // Implementar diálogo de perfil de usuario
            await Task.CompletedTask;
        }

        public void SetCurrentUser(SecUsuario user)
        {
            CurrentUser = user;
        }

        #endregion
    }

    #region Helper Classes

    public class MenuItemViewModel : ViewModelBase
    {
        private bool _isSelected;
        private bool _isExpanded;
        private ObservableCollection<MenuItemViewModel> _subItems;

        public string Title { get; set; }
        public PackIconModernKind Icon { get; set; }
        public string NavigationKey { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        public ObservableCollection<MenuItemViewModel> SubItems
        {
            get => _subItems;
            set => SetProperty(ref _subItems, value);
        }

        public bool HasSubItems => SubItems != null && SubItems.Count > 0;
    }

    public class DashboardViewModel : ViewModelBase
    {
        public string WelcomeMessage => $"Bienvenido al Sistema de Gestión - Depósito Dental";

        // Aquí irían las propiedades para mostrar estadísticas del dashboard
        public int TotalProductos { get; set; }
        public int ProductosConStockBajo { get; set; }
        public int ClientesActivos { get; set; }
        public decimal VentasDelDia { get; set; }
        public int PedidosPendientes { get; set; }
    }

    public class NotImplementedViewModel : ViewModelBase
    {
        public string Message { get; set; }
    }

    #endregion
}
