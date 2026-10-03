using System.Globalization;

namespace Flyweight.Map
{
    /// <summary>
    /// The flyweight: holds the heavy data shared by many markers (intrinsic state).
    /// It's immutable, so the same instance can safely be used by thousands of markers.
    /// The position is not stored here: it's passed in by each marker (extrinsic state).
    /// </summary>
    internal class MarkerIcon
    {
        public const int ImageSizeInBytes = 20 * 1024;

        private readonly byte[] _image;

        public string Name { get; }
        public string Color { get; }

        public MarkerIcon(string name, string color)
        {
            Name = name;
            Color = color;

            // Simulates a 20 KB bitmap loaded from disk
            _image = new byte[ImageSizeInBytes];
        }

        public void Draw(double latitude, double longitude) =>
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  Drawing '{Name}' icon ({Color}, {_image.Length / 1024} KB) at {latitude:0.000}, {longitude:0.000}"));
    }
}
