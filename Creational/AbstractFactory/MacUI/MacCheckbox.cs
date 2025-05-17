using AbstractFactory.Interfaces;

namespace AbstractFactory.MacUI
{
    internal class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style Checkbox.");
        }
    }
}
