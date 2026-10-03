namespace Facade.Orders
{
    internal record OrderResult(bool IsSuccess, string Message)
    {
        public static OrderResult Success(string message) => new(true, message);
        public static OrderResult Failure(string message) => new(false, message);
    }
}
