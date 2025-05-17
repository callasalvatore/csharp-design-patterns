using AbstractFactory.Interfaces;

namespace AbstractFactory.WindowsUI
{
    internal class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style Button.");
        }
    }
}
