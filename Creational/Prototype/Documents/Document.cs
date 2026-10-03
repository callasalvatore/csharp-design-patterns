using System.Text;
using Prototype.Interfaces;

namespace Prototype.Documents
{
    internal class Document : IPrototype<Document>
    {
        public string Title { get; set; }
        public Style Style { get; }
        public List<Section> Sections { get; }

        public Document(string title, Style style, IEnumerable<Section> sections)
        {
            Title = title;
            Style = style;
            Sections = sections.ToList();
        }

        /// <summary>
        /// Deep copy: nested mutable objects are cloned too,
        /// so changes to the copy never affect the original.
        /// </summary>
        public Document Clone() =>
            new(Title, Style.Clone(), Sections.Select(section => section.Clone()));

        /// <summary>
        /// Shallow copy, kept only to show the pitfall: the copy shares
        /// the same Style and Sections instances with the original.
        /// </summary>
        public Document ShallowClone() => (Document)MemberwiseClone();

        public override string ToString()
        {
            var text = new StringBuilder();
            text.AppendLine($"[{Title}] ({Style})");

            foreach (var section in Sections)
                text.AppendLine($"  - {section.Heading}: {section.Body}");

            return text.ToString();
        }
    }
}
