namespace Prototype.Interfaces
{
    /// <summary>
    /// Strongly typed alternative to ICloneable: the return type is explicit
    /// and the contract is that Clone() returns a deep, independent copy.
    /// </summary>
    internal interface IPrototype<out T>
    {
        T Clone();
    }
}
