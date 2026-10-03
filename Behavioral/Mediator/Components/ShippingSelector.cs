using System.Globalization;

namespace Mediator.Components
{
    internal class ShippingSelector : FormComponent
    {
        private IReadOnlyList<ShippingOption> _options = [];

        public ShippingOption? Selected { get; private set; }

        // Called by the mediator when the available options change
        public void SetOptions(IReadOnlyList<ShippingOption> options)
        {
            _options = options;
            Selected = options.FirstOrDefault();

            var list = string.Join(", ", options.Select(o => string.Create(CultureInfo.InvariantCulture, $"{o.Name} {o.Cost:0.00}")));
            Console.WriteLine($"  [Shipping] Options updated: {list} (selected: {Selected?.Name})");
        }

        // Called by the user
        public void Choose(string name)
        {
            Selected = _options.Single(option => option.Name == name);
            Console.WriteLine($"[Shipping] User chose {name}");
            NotifyChanged();
        }
    }
}
