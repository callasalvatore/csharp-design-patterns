using FactoryMethod.Notifications;

namespace FactoryMethod.Sender
{
    internal class EmailSender : NotificationSender
    {
        public override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }
}
