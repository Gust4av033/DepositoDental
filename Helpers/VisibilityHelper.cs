using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoDental.Helpers
{
    public static class VisibilityHelper
    {
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.RegisterAttached(
                "IsVisible",
                typeof(bool?),
                typeof(VisibilityHelper),
                new PropertyMetadata(null, OnIsVisibleChanged));

        public static bool? GetIsVisible(DependencyObject obj)
        {
            return (bool?)obj.GetValue(IsVisibleProperty);
        }

        public static void SetIsVisible(DependencyObject obj, bool? value)
        {
            obj.SetValue(IsVisibleProperty, value);
        }

        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is bool isVisible)
            {
                element.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        // Para inversión de visibilidad
        public static readonly DependencyProperty IsHiddenProperty =
            DependencyProperty.RegisterAttached(
                "IsHidden",
                typeof(bool?),
                typeof(VisibilityHelper),
                new PropertyMetadata(null, OnIsHiddenChanged));

        public static bool? GetIsHidden(DependencyObject obj)
        {
            return (bool?)obj.GetValue(IsHiddenProperty);
        }

        public static void SetIsHidden(DependencyObject obj, bool? value)
        {
            obj.SetValue(IsHiddenProperty, value);
        }

        private static void OnIsHiddenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is bool isHidden)
            {
                element.Visibility = isHidden ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
