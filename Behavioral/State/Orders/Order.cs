using State.States;

namespace State.Orders
{
    /// <summary>
    /// The context: exposes the actions, but delegates them to its current state.
    /// It has no switch or if/else on the state.
    /// </summary>
    internal class Order
    {
        private OrderState _state = new NewState();

        public string Id { get; }
        public string Status => _state.Name;

        public Order(string id)
        {
            Id = id;
        }

        public void Pay() => _state.Pay(this);
        public void Ship() => _state.Ship(this);
        public void Deliver() => _state.Deliver(this);
        public void Cancel() => _state.Cancel(this);

        // Called by the states to move the order to the next state
        internal void TransitionTo(OrderState next)
        {
            Console.WriteLine($"  {Id}: {_state.Name} -> {next.Name}");
            _state = next;
        }
    }
}
