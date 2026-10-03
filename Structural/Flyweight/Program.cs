
using System.Globalization;
using Flyweight.Map;

const int markerCount = 10_000;
string[] iconTypes = ["warehouse", "store", "delivery"];

var factory = new MarkerIconFactory();
var markers = new List<MapMarker>(markerCount);

Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Creating {markerCount:N0} markers:"));

for (var i = 0; i < markerCount; i++)
{
    // Positions around Milan, spread on a grid
    var latitude = 45.40 + (i % 100) * 0.002;
    var longitude = 9.10 + (i / 100) * 0.002;

    var icon = factory.GetIcon(iconTypes[i % iconTypes.Length]);
    markers.Add(new MapMarker(latitude, longitude, icon));
}

Console.WriteLine();
Console.WriteLine("Drawing the first markers:");
foreach (var marker in markers.Take(4))
    marker.Draw();

// Memory used by the icon images only
var withoutFlyweight = (double)markerCount * MarkerIcon.ImageSizeInBytes;
var withFlyweight = (double)factory.LoadedIcons * MarkerIcon.ImageSizeInBytes;

Console.WriteLine();
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Markers: {markers.Count:N0}, icons in memory: {factory.LoadedIcons}"));
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Icon memory without Flyweight: {withoutFlyweight / (1024 * 1024):0.0} MB"));
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Icon memory with Flyweight:    {withFlyweight / 1024:0} KB"));

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
