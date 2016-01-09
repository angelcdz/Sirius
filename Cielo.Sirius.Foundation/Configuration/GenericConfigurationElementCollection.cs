using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T> where T : BaseConfigurationElement, new()
    {
        List<T> _elements = new List<T>();

        protected override ConfigurationElement CreateNewElement()
        {
            T newElement = new T();
            _elements.Add(newElement);
            return newElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BaseConfigurationElement)element).Name;
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public T this[int idx]
        {
            get
            {
                return (T)BaseGet(idx);
            }
        }

        public new T this[string name]
        {
            get
            {
                return (T)BaseGet(name);
            }
        }
    }
}
