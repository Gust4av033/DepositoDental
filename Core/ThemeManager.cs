using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace DepositoDental.Core
{
    public static class ThemeManager
    {
        public static void SetTheme(bool isDark)
        {
            var paletteHelper = new PaletteHelper();

            // Recupera el tema actual de la aplicación
            Theme theme = paletteHelper.GetTheme();

            // Establece el tema base (claro u oscuro)
            // Esta es la forma correcta y moderna de hacerlo
            theme.SetBaseTheme(isDark ? BaseTheme.Dark : BaseTheme.Light);

            // Aplica el tema modificado de vuelta a la aplicación
            paletteHelper.SetTheme(theme);
        }
    }
}
