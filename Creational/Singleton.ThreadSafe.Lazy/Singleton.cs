namespace SingletonThreadSafeLazy
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

        private Singleton()
        {
            Console.WriteLine("Singleton instance created");
        }

        public static Singleton Instance => _instance.Value;

        public void DoWork()
        {
            Console.WriteLine("Doing work from thread-safe lazy singleton.");
        }
    }
}
