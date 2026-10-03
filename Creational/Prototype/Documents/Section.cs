using Prototype.Interfaces;

namespace Prototype.Documents
{
    internal class Section : IPrototype<Section>
    {
        public string Heading { get; set; }
        public string Body { get; set; }

        public Section(string heading, string body)
        {
            Heading = heading;
            Body = body;
        }

        public Section Clone() => new(Heading, Body);
    }
}
