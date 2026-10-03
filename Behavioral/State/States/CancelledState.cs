namespace State.States
{
    /// <summary>
    /// Final state: every action is refused by the base class.
    /// </summary>
    internal class CancelledState : OrderState
    {
        public override string Name => "Cancelled";
    }
}
