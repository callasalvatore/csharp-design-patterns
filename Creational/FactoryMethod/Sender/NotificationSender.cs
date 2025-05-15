using FactoryMethod.Notifications;

namespace FactoryMethod.Sender
{
    internal abstract class NotificationSender
    {
        public abstract INotification CreateNotification();

        public void Notify(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }

}
