namespace Interpreter.Rules
{
    /// <summary>
    /// Nonterminal expression: true when both sub-expressions are true.
    /// </summary>
    internal class AndExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public AndExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public bool Interpret(OrderContext context) => _left.Interpret(context) && _right.Interpret(context);

        public override string ToString() => $"({_left} AND {_right})";
    }
}
