namespace Interpreter.Rules
{
    /// <summary>
    /// The context: the data the expressions are evaluated against.
    /// Numbers are stored as decimal, text as string, flags as bool.
    /// </summary>
    internal class OrderContext
    {
        private readonly Dictionary<string, object> _values = new(StringComparer.OrdinalIgnoreCase);

        public object this[string field]
        {
            get => _values.TryGetValue(field, out var value)
                ? value
                : throw new KeyNotFoundException($"Unknown field '{field}'.");
            set => _values[field] = value;
        }
    }
}
