namespace Flyweight.Map
{
    /// <summary>
    /// The flyweight factory: creates each icon only the first time it's requested,
    /// then always returns the same shared instance.
    /// </summary>
    internal class MarkerIconFactory
    {
        private readonly Dictionary<string, MarkerIcon> _icons = [];

        private static readonly Dictionary<string, string> Colors = new()
        {
            ["warehouse"] = "blue",
            ["store"] = "green",
            ["delivery"] = "red"
        };

        public int LoadedIcons => _icons.Count;

        public MarkerIcon GetIcon(string name)
        {
            if (!_icons.TryGetValue(name, out var icon))
            {
                Console.WriteLine($"  [Factory] Loading icon '{name}' from disk");
                icon = new MarkerIcon(name, Colors[name]);
                _icons[name] = icon;
            }

            return icon;
        }
    }
}
