using System.Collections.Generic;
using System.Windows.Controls;

namespace Cielo.Sirius.Foundation.USD.Extensions
{
    public static class UserControlExtensions
    {
        public static IEnumerable<T> GetViewModels<T>(this UserControl userControl_)
        {
            List<UserControl> views = new List<UserControl>(UiHelper.WPFTreeHelper.FindChildren<UserControl>(userControl_));
            views.Add(userControl_);
            foreach (var view in views)
            {
                if (view.DataContext is T)
                {
                    yield return (T)view.DataContext;
                }
            }
        }
    }
}
