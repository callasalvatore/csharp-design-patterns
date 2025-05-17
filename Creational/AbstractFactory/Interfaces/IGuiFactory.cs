namespace AbstractFactory.Interfaces
{
    internal interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
}
