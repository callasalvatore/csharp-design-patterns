using System.Globalization;

namespace Interpreter.Rules
{
    /// <summary>
    /// Terminal expression: compares a field of the order with a constant value,
    /// e.g. total >= 50 or country = 'IT'. It's a leaf of the tree.
    /// </summary>
    internal class ComparisonExpression : IExpression
    {
        private readonly string _field;
        private readonly string _operator;
        private readonly object _value;

        public ComparisonExpression(string field, string @operator, object value)
        {
            _field = field;
            _operator = @operator;
            _value = value;
        }

        public bool Interpret(OrderContext context) => (context[_field], _value) switch
        {
            (decimal actual, decimal expected) => _operator switch
            {
                "=" => actual == expected,
                "!=" => actual != expected,
                ">" => actual > expected,
                ">=" => actual >= expected,
                "<" => actual < expected,
                "<=" => actual <= expected,
                _ => throw UnsupportedOperator()
            },
            (string or bool, string or bool) when _operator is "=" or "!=" =>
                Equals(context[_field], _value) == (_operator == "="),
            _ => throw UnsupportedOperator()
        };

        public override string ToString() => _value switch
        {
            string text => $"{_field} {_operator} '{text}'",
            bool flag => $"{_field} {_operator} {flag.ToString().ToLowerInvariant()}",
            _ => string.Create(CultureInfo.InvariantCulture, $"{_field} {_operator} {_value}")
        };

        private InvalidOperationException UnsupportedOperator() =>
            new($"Operator '{_operator}' cannot compare field '{_field}' with {_value}.");
    }
}
