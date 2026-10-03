namespace Flyweight.Map
{
    /// <summary>
    /// The context: one per point on the map. It only stores what is unique to the marker
    /// (its position) and a reference to the shared icon.
    /// </summary>
    internal class MapMarker
    {
        private readonly double _latitude;
        private readonly double _longitude;
        private readonly MarkerIcon _icon;

        public MapMarker(double latitude, double longitude, MarkerIcon icon)
        {
            _latitude = latitude;
            _longitude = longitude;
            _icon = icon;
        }

        public void Draw() => _icon.Draw(_latitude, _longitude);
    }
}
