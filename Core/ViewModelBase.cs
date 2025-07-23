using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Core
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private bool _disposed = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Soporte para temas
        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set => SetProperty(ref _isDarkTheme, value);
        }

        protected ViewModelBase()
        {
            // Suscribirse a cambios de tema
            ThemeManager.ThemeChanged += OnThemeChanged;
            IsDarkTheme = ThemeManager.IsDarkMode;
        }

        private void OnThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            IsDarkTheme = e.IsDarkMode;
        }

        public virtual void Dispose()
        {
            if (!_disposed)
            {
                ThemeManager.ThemeChanged -= OnThemeChanged;
                _disposed = true;
            }
        }
    }
}
