using Mediator.Components;

namespace Mediator.Checkout
{
    /// <summary>
    /// The mediator: components call it when something changes,
    /// instead of talking to each other.
    /// </summary>
    internal interface ICheckoutMediator
    {
        void Notify(FormComponent sender);
    }
}
