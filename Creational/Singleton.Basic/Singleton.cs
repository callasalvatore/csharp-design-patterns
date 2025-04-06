namespace SingletonBasic;

public class Singleton
{
    private static Singleton? _instance;

    // Private constructor to prevent instantiation
    private Singleton()
    {
        Console.WriteLine("Singleton instance created");
    }

    public static Singleton Instance
    {
        get
        {
            _instance ??= new Singleton();

            return _instance;
        }
    }

    public void DoWork()
    {
        Console.WriteLine("Working from singleton instance.");
    }
}
