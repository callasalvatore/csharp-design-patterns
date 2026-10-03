using State.Orders;

namespace State.States
{
    /// <summary>
    /// The state: by default every action is refused.
    /// Each concrete state overrides only the actions allowed in that state.
    /// </summary>
    internal abstract class OrderState
    {
        public abstract string Name { get; }

        public virtual void Pay(Order order) => Refuse(order, "pay");
        public virtual void Ship(Order order) => Refuse(order, "ship");
        public virtual void Deliver(Order order) => Refuse(order, "deliver");
        public virtual void Cancel(Order order) => Refuse(order, "cancel");

        protected void Refuse(Order order, string action, string? reason = null) =>
            Console.WriteLine($"  Cannot {action} {order.Id}: it's {Name}{(reason is null ? "" : $" ({reason})")}");
    }
}
