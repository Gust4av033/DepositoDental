using System;
using System.Windows;
using ControlzEx.Theming;

namespace DepositoDental.Core
{
    public static class ThemeManager
    {
        public static event EventHandler<ThemeChangedEventArgs> ThemeChanged;

        private static bool _isDarkMode = true;
        private static string _accentColor = "Steel";

        public static bool IsDarkMode
        {
            get => _isDarkMode;
            private set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(value));
                }
            }
        }

        public static void Initialize()
        {
            // Configurar tema inicial
            SetTheme(_isDarkMode);
        }

        public static void SetTheme(bool isDark)
        {
            try
            {
                var app = Application.Current;
                if (app?.Resources == null) return;

                string baseTheme = isDark ? "Dark" : "Light";

                // Cambiar tema de MahApps
                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(app, $"{baseTheme}.{_accentColor}");

                // Cargar recursos personalizados adicionales si existen
                LoadCustomResources(app, isDark);

                IsDarkMode = isDark;

                // Guardar preferencia
                SaveThemePreference(isDark);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error changing theme: {ex.Message}");
            }
        }

        private static void LoadCustomResources(Application app, bool isDark)
        {
            try
            {
                // Remover diccionarios personalizados anteriores
                for (int i = app.Resources.MergedDictionaries.Count - 1; i >= 0; i--)
                {
                    var dict = app.Resources.MergedDictionaries[i];
                    if (dict.Source?.ToString().Contains("Resources/Themes") == true)
                    {
                        app.Resources.MergedDictionaries.RemoveAt(i);
                    }
                }

                // Cargar nuevos recursos personalizados
                var customThemeUri = new Uri($"pack://application:,,,/DepositoDental;component/Resources/Themes/{(isDark ? "Dark" : "Light")}Theme.xaml");
                if (Application.GetResourceStream(customThemeUri) != null)
                {
                    var customTheme = new ResourceDictionary { Source = customThemeUri };
                    app.Resources.MergedDictionaries.Add(customTheme);
                }
            }
            catch
            {
                // Si no hay recursos personalizados, continuar sin ellos
            }
        }

        public static void ToggleTheme()
        {
            SetTheme(!IsDarkMode);
        }

        public static void ChangeAccent(string accentName)
        {
            _accentColor = accentName;
            SetTheme(IsDarkMode);
        }

        private static void SaveThemePreference(bool isDark)
        {
            try
            {
                var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    System.Configuration.ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["Theme"] != null)
                {
                    config.AppSettings.Settings["Theme"].Value = isDark ? "Dark" : "Light";
                }
                else
                {
                    config.AppSettings.Settings.Add("Theme", isDark ? "Dark" : "Light");
                }

                config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            }
            catch
            {
                // Si falla, no es crítico
            }
        }

        public static void LoadThemePreference()
        {
            try
            {
                var themeSetting = System.Configuration.ConfigurationManager.AppSettings["Theme"];
                if (!string.IsNullOrEmpty(themeSetting))
                {
                    SetTheme(themeSetting == "Dark");
                }
            }
            catch
            {
                // Usar tema por defecto
            }
        }
    }

    public class ThemeChangedEventArgs : EventArgs
    {
        public bool IsDarkMode { get; }

        public ThemeChangedEventArgs(bool isDarkMode)
        {
            IsDarkMode = isDarkMode;
        }
    }
}