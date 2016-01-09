using System;
using System.Windows;
using System.Windows.Interactivity;

namespace Cielo.Sirius.Foundation.USD.Behaviors
{
    public class ClosePopupOnMoveBehavior : Behavior<System.Windows.Controls.Primitives.Popup>
    {
        private Window _parentWindow;

        protected override void OnAttached()
        {
            base.OnAttached();

            _parentWindow = Application.Current.MainWindow;
            if (_parentWindow != null)
            {
                _parentWindow.LocationChanged += _parentWindow_LocationChanged;
                _parentWindow.SizeChanged += _parentWindow_SizeChanged;
                _parentWindow.Deactivated += _parentWindow_Deactivated;
                _parentWindow.Closed += _parentWindow_Closing;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (_parentWindow != null)
            {
                _parentWindow.LocationChanged -= _parentWindow_LocationChanged;
                _parentWindow.SizeChanged -= _parentWindow_SizeChanged;
                _parentWindow.Deactivated -= _parentWindow_Deactivated;
                _parentWindow.Closed -= _parentWindow_Closing;
            }
        }

        private void _parentWindow_Closing(object sender, EventArgs e)
        {
            base.AssociatedObject.IsOpen = false;
        }

        private void _parentWindow_Deactivated(object sender, EventArgs e)
        {
            base.AssociatedObject.IsOpen = false;
        }

        private void _parentWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            base.AssociatedObject.IsOpen = false;
        }

        private void _parentWindow_LocationChanged(object sender, EventArgs e)
        {
            base.AssociatedObject.IsOpen = false;
        }

    }
}
