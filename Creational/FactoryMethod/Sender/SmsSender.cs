using FactoryMethod.Notifications;

namespace FactoryMethod.Sender
{
    internal class SmsSender : NotificationSender
    {
        public override INotification CreateNotification()
        {
            return new SmsNotification();
        }
    }
}
