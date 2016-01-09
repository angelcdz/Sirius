
namespace Cielo.Sirius.Foundation.USD.Messenger
{
    public class NotificationMessage
    {
        public string Notification { get; set; }
        public string Description { get; set; }

        public NotificationMessage(string notification)
        {
            this.Notification = notification;
        }
    }
}
