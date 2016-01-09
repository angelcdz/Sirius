using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public class NavigationRegion
    {
        public static string GetRegionName(DependencyObject obj)
        {
            return (string)obj.GetValue(RegionNameProperty);
        }

        public static void SetRegionName(DependencyObject obj, string value)
        {
            obj.SetValue(RegionNameProperty, value);
        }

        public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.RegisterAttached("RegionName", typeof(string), typeof(NavigationRegion), new PropertyMetadata(String.Empty, OnRegionNameChanged));

        public static object GetNavegationContext(DependencyObject obj)
        {
            return (object)obj.GetValue(NavegationContextProperty);
        }

        public static void SetNavegationContext(DependencyObject obj, object value)
        {
            obj.SetValue(NavegationContextProperty, value);
        }

        public static readonly DependencyProperty NavegationContextProperty =
            DependencyProperty.RegisterAttached("NavegationContext", typeof(object), typeof(NavigationRegion), new PropertyMetadata(null));


        private static void OnRegionNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() =>
                {
                    MainHostedControlBase hostedControl = UiHelper.WPFTreeHelper.FindParent<MainHostedControlBase>(control);
                    if (hostedControl != null)
                    {
                        hostedControl.Navegator.AddNavegationRegion(control);
                    }
                }));
            }
        }

    }
}
