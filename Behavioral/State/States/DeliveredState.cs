namespace State.States
{
    /// <summary>
    /// Final state: every action is refused by the base class.
    /// </summary>
    internal class DeliveredState : OrderState
    {
        public override string Name => "Delivered";
    }
}
