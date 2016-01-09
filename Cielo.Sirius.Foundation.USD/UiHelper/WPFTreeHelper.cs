using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Cielo.Sirius.Foundation.USD.UiHelper
{
    public class WPFTreeHelper
    {
        public static T FindChild<T>(DependencyObject depObj)
             where T : DependencyObject
        {
            if (depObj == null) return null;

            if (depObj is T)
                return depObj as T;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                T obj = FindChild<T>(child);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        public static List<T> FindChildren<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            var listaObjetos = new List<T>();
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                try
                {
                    T childT = child as T;
                    if (childT != null)
                    {
                        listaObjetos.Add(childT);
                    }
                    else
                    {
                        List<T> listaObjetosFilho = FindChildren<T>(child);
                        if (listaObjetosFilho != null &&
                            listaObjetosFilho.Count > 0)
                        {
                            listaObjetos = listaObjetos.Concat(listaObjetosFilho).ToList();
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            return listaObjetos;
        }

        public static T FindParent<T>(DependencyObject depObj)
           where T : DependencyObject
        {
            if (depObj == null) return null;

            if (depObj is T)
                return depObj as T;

            if (!(depObj is T))
            {
                DependencyObject child = VisualTreeHelper.GetParent(depObj);

                T obj = FindParent<T>(child);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        public static T FindParent<T>(DependencyObject depObj, DependencyObject topParent)
            where T : DependencyObject
        {
            if (depObj == null) return null;

            if (depObj is T)
                return depObj as T;

            if (!(depObj is T) && depObj != topParent)
            {
                DependencyObject child = VisualTreeHelper.GetParent(depObj);

                T obj = FindParent<T>(child, topParent);

                if (obj != null)
                    return obj;
            }

            return null;
        }

        public static T FindChildren<T>(DependencyObject parent, string childName)
            where T : DependencyObject
        {
            if (parent == null)
                return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChildren<T>(child, childName);

                    if (foundChild != null)
                        break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;

                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
