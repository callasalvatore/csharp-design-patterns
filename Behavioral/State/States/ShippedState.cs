using State.Orders;

namespace State.States
{
    internal class ShippedState : OrderState
    {
        public override string Name => "Shipped";

        public override void Deliver(Order order) => order.TransitionTo(new DeliveredState());

        public override void Cancel(Order order) => Refuse(order, "cancel", "already on its way, request a return instead");
    }
}
