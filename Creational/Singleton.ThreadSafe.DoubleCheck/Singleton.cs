namespace SingletonThreadSafeDoubleCheck
{
    public class Singleton
    {
        private static Singleton? _instance;
        private static readonly object _lock = new();

        private Singleton()
        {
            Console.WriteLine("Singleton instance created");
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_lock)
                    {
                        _instance ??= new Singleton();
                    }
                }

                return _instance;
            }
        }

        public void DoWork()
        {
            Console.WriteLine("Doing work from thread-safe singleton.");
        }
    }
}
