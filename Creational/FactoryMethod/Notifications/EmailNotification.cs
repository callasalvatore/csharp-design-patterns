namespace FactoryMethod.Notifications
{
    internal class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending EMAIL: {message}");
        }
    }
}
