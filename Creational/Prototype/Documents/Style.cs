using Prototype.Interfaces;

namespace Prototype.Documents
{
    internal class Style : IPrototype<Style>
    {
        public string FontFamily { get; set; }
        public int FontSize { get; set; }

        public Style(string fontFamily, int fontSize)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
        }

        // Only value-type and string members: a memberwise copy is already a deep copy.
        public Style Clone() => (Style)MemberwiseClone();

        public override string ToString() => $"{FontFamily}, {FontSize}pt";
    }
}
