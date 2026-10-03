using System.Globalization;
using System.Text.RegularExpressions;
using Interpreter.Rules;

namespace Interpreter.Parsing
{
    /// <summary>
    /// Turns a rule written as text into a tree of expressions.
    /// The parser is not part of the Interpreter pattern itself: the pattern starts
    /// once the tree exists. Grammar (from lowest to highest precedence):
    ///
    ///   or         := and ( OR and )*
    ///   and        := not ( AND not )*
    ///   not        := NOT not | '(' or ')' | comparison
    ///   comparison := field operator value
    /// </summary>
    internal class RuleParser
    {
        private static readonly Regex TokenPattern = new(@"\G(?:>=|<=|!=|=|>|<|\(|\)|'[^']*'|\d+(?:\.\d+)?|[A-Za-z_]\w*)");
        private static readonly string[] Operators = ["=", "!=", ">", ">=", "<", "<="];

        private readonly List<string> _tokens;
        private int _position;

        private RuleParser(List<string> tokens)
        {
            _tokens = tokens;
        }

        public static IExpression Parse(string rule)
        {
            var parser = new RuleParser(Tokenize(rule));
            var expression = parser.ParseOr();

            if (parser._position < parser._tokens.Count)
                throw new FormatException($"Unexpected '{parser._tokens[parser._position]}'.");

            return expression;
        }

        private static List<string> Tokenize(string rule)
        {
            var tokens = new List<string>();
            var position = 0;

            while (position < rule.Length)
            {
                if (char.IsWhiteSpace(rule[position]))
                {
                    position++;
                    continue;
                }

                var match = TokenPattern.Match(rule, position);
                if (!match.Success)
                    throw new FormatException($"Invalid character '{rule[position]}' at position {position}.");

                tokens.Add(match.Value);
                position += match.Length;
            }

            return tokens;
        }

        private IExpression ParseOr()
        {
            var expression = ParseAnd();
            while (Accept("OR"))
                expression = new OrExpression(expression, ParseAnd());
            return expression;
        }

        private IExpression ParseAnd()
        {
            var expression = ParseNot();
            while (Accept("AND"))
                expression = new AndExpression(expression, ParseNot());
            return expression;
        }

        private IExpression ParseNot()
        {
            if (Accept("NOT"))
                return new NotExpression(ParseNot());

            if (Accept("("))
            {
                var expression = ParseOr();
                Expect(")");
                return expression;
            }

            return ParseComparison();
        }

        private IExpression ParseComparison()
        {
            var field = Next("a field name");
            var @operator = Next("an operator");

            if (!Operators.Contains(@operator))
                throw new FormatException($"Expected an operator after '{field}', found '{@operator}'.");

            return new ComparisonExpression(field, @operator, ParseValue(Next("a value")));
        }

        private static object ParseValue(string token)
        {
            if (token.StartsWith('\''))
                return token.Trim('\'');

            if (bool.TryParse(token, out var flag))
                return flag;

            if (decimal.TryParse(token, NumberStyles.Number, CultureInfo.InvariantCulture, out var number))
                return number;

            throw new FormatException($"'{token}' is not a valid value.");
        }

        private bool Accept(string token)
        {
            if (_position < _tokens.Count && string.Equals(_tokens[_position], token, StringComparison.OrdinalIgnoreCase))
            {
                _position++;
                return true;
            }

            return false;
        }

        private void Expect(string token)
        {
            if (!Accept(token))
                throw new FormatException($"Expected '{token}'.");
        }

        private string Next(string expected) =>
            _position < _tokens.Count
                ? _tokens[_position++]
                : throw new FormatException($"Expected {expected}, but the rule ended.");
    }
}
