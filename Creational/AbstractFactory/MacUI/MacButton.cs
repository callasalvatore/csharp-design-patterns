using AbstractFactory.Interfaces;

namespace AbstractFactory.MacUI
{
    internal class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style Button.");
        }
    }
}
