using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoDental.Core
{
    public static class ErrorHandler
    {
        public static async void HandleError(Exception ex, string userMessage = null)
        {
            // Log del error
            LogError(ex);

            // Mostrar mensaje al usuario
            var window = Application.Current.MainWindow as MetroWindow;
            if (window != null)
            {
                var message = userMessage ?? "Ha ocurrido un error inesperado.";
                await window.ShowMessageAsync("Error", message, MessageDialogStyle.Affirmative);
            }
            else
            {
                MessageBox.Show(userMessage ?? ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static async void HandleValidationError(string message)
        {
            var window = Application.Current.MainWindow as MetroWindow;
            if (window != null)
            {
                await window.ShowMessageAsync("Validación", message, MessageDialogStyle.Affirmative);
            }
            else
            {
                MessageBox.Show(message, "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private static void LogError(Exception ex)
        {
            // TODO: Implementar logging con Serilog
            System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"STACK: {ex.StackTrace}");
        }
    }
}
