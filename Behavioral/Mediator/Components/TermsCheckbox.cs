namespace Mediator.Components
{
    internal class TermsCheckbox : FormComponent
    {
        public bool IsChecked { get; private set; }

        public void Toggle()
        {
            IsChecked = !IsChecked;
            Console.WriteLine($"[Terms] User {(IsChecked ? "accepted" : "unchecked")} the terms");
            NotifyChanged();
        }
    }
}
