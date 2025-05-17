using AbstractFactory.Interfaces;

namespace AbstractFactory.WindowsUI
{
    internal class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style Checkbox.");
        }
    }
}
