using Mediator.Checkout;

namespace Mediator.Components
{
    /// <summary>
    /// The colleague base class: every component knows only the mediator.
    /// </summary>
    internal abstract class FormComponent
    {
        private ICheckoutMediator? _mediator;

        public void SetMediator(ICheckoutMediator mediator) => _mediator = mediator;

        protected void NotifyChanged() => _mediator?.Notify(this);
    }
}
