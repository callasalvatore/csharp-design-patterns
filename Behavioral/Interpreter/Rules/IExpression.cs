namespace Interpreter.Rules
{
    /// <summary>
    /// The abstract expression: every node of the rule tree can evaluate itself.
    /// </summary>
    internal interface IExpression
    {
        bool Interpret(OrderContext context);
    }
}
