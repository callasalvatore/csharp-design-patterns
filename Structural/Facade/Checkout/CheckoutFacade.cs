using Facade.Orders;
using Facade.Subsystems;

namespace Facade.Checkout
{
    /// <summary>
    /// The facade: a single entry point that coordinates the subsystems
    /// in the right order and undoes the previous steps when one fails.
    /// </summary>
    internal class CheckoutFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly ShippingService _shipping;
        private readonly EmailService _email;

        public CheckoutFacade(InventoryService inventory, PaymentService payment, ShippingService shipping, EmailService email)
        {
            _inventory = inventory;
            _payment = payment;
            _shipping = shipping;
            _email = email;
        }

        public OrderResult PlaceOrder(Order order)
        {
            if (!_inventory.Reserve(order.Sku, order.Quantity))
                return OrderResult.Failure("Product out of stock");

            var transactionId = _payment.Charge(order.PaymentToken, order.Amount);
            if (transactionId is null)
            {
                // Compensation: the reserved items go back to the stock
                _inventory.Release(order.Sku, order.Quantity);
                return OrderResult.Failure("Payment declined");
            }

            var trackingNumber = _shipping.CreateShipment(order.Id, order.ShippingAddress);
            _email.SendOrderConfirmation(order.CustomerEmail, order.Id, trackingNumber);

            return OrderResult.Success($"Order completed (payment {transactionId}, tracking {trackingNumber})");
        }
    }
}
