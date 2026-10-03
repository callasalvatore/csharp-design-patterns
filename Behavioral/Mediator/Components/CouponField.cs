namespace Mediator.Components
{
    internal class CouponField : FormComponent
    {
        public string? Code { get; private set; }

        public void Enter(string code)
        {
            Code = code;
            Console.WriteLine($"[Coupon] User entered {code}");
            NotifyChanged();
        }
    }
}
