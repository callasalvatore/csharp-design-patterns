using AbstractFactory.Interfaces;

namespace AbstractFactory.WindowsUI
{
    internal class WindowsFactory : IGuiFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }
}
