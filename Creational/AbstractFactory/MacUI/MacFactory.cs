using AbstractFactory.Interfaces;

namespace AbstractFactory.MacUI
{
    internal class MacFactory : IGuiFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }
}
