using System;

namespace Cielo.Sirius.Foundation.USD.Messenger
{
    public interface IMessenger
    {
        void Register<T>(object recipient, Action<T> action);
        void Register<T>(object recipient, Action<T> action, object context);
        void Unregister(object recipient);
        void Unregister(object recipient, object context);
        void Send<T>(T message);
        void Send<T>(T message, object context);
    }
}
