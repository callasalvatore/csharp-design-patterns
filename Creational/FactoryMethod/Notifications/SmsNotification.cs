namespace FactoryMethod.Notifications
{
    internal class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
}
