using State.Orders;

namespace State.States
{
    internal class NewState : OrderState
    {
        public override string Name => "New";

        public override void Pay(Order order) => order.TransitionTo(new PaidState());

        public override void Ship(Order order) => Refuse(order, "ship", "it must be paid first");

        public override void Cancel(Order order) => order.TransitionTo(new CancelledState());
    }
}
