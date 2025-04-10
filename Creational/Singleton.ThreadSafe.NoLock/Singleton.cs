namespace SingletonThreadSafeNoLock
{
    public class Singleton
    {
        private static readonly Singleton _instance = new();

        static Singleton()
        { }

        private Singleton()
        {
            Console.WriteLine("Singleton instance created");
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public void DoWork()
        {
            Console.WriteLine("Doing work from thread-safe singleton.");
        }
    }
}
