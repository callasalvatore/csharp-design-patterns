namespace Mediator.Components
{
    internal class PlaceOrderButton : FormComponent
    {
        public bool IsEnabled { get; private set; }

        public void SetEnabled(bool enabled)
        {
            if (enabled == IsEnabled)
                return;

            IsEnabled = enabled;
            Console.WriteLine($"  [Button] {(enabled ? "Enabled" : "Disabled")}");
        }

        public void Click()
        {
            Console.WriteLine("[Button] User clicked 'Place order'");

            if (!IsEnabled)
            {
                Console.WriteLine("  [Button] Ignored: the button is disabled");
                return;
            }

            NotifyChanged();
        }
    }
}
