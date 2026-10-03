namespace Mediator.Components
{
    internal class CountrySelector : FormComponent
    {
        public string? Country { get; private set; }

        public void Select(string country)
        {
            Country = country;
            Console.WriteLine($"[Country] User selected {country}");
            NotifyChanged();
        }
    }
}
