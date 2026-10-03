namespace Facade.Subsystems
{
    internal class EmailService
    {
        public void SendOrderConfirmation(string email, string orderId, string trackingNumber)
        {
            Console.WriteLine($"  [Email] Confirmation for order {orderId} sent to {email} (tracking {trackingNumber})");
        }
    }
}
