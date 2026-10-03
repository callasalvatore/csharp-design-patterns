using State.Orders;

namespace State.States
{
    internal class PaidState : OrderState
    {
        public override string Name => "Paid";

        public override void Ship(Order order) => order.TransitionTo(new ShippedState());

        public override void Cancel(Order order)
        {
            Console.WriteLine($"  Refunding the payment of {order.Id}");
            order.TransitionTo(new CancelledState());
        }
    }
}
