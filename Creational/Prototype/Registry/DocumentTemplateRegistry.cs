using Prototype.Documents;

namespace Prototype.Registry
{
    /// <summary>
    /// Keeps the preconfigured prototypes and hands out clones,
    /// so clients never modify (or need to know how to build) the originals.
    /// </summary>
    internal class DocumentTemplateRegistry
    {
        private readonly Dictionary<string, Document> _templates = new(StringComparer.OrdinalIgnoreCase);

        public void Register(string name, Document template)
        {
            _templates[name] = template;
        }

        public Document Create(string name)
        {
            if (!_templates.TryGetValue(name, out var template))
                throw new KeyNotFoundException($"Template '{name}' is not registered.");

            return template.Clone();
        }
    }
}
