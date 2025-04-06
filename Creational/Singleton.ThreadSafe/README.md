# 🧱 Singleton Pattern – Thread-Safe Version

This version of the **Singleton Pattern** ensures **thread-safety**, making it safe to use in **multithreaded environments**.

It uses a `lock` statement to ensure that only one thread can create the instance at a time.  
This guarantees that only one instance is created — even if multiple threads access the `Instance` property simultaneously.


## 📦 Implementation Summary

**Singleton.cs**: 
```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }
    }

    public void DoWork() => Console.WriteLine("Thread-safe singleton working...");
}
```

**Program.cs**
```csharp
var s1 = Singleton.Instance;
var s2 = Singleton.Instance;

Console.WriteLine(ReferenceEquals(s1, s2)); // True
s1.DoWork();
Console.WriteLine("Press any key to exit...");
Console.ReadLine();
```

⚙️ How Thread Safety is Achieved

The lock ensures that only one thread at a time can enter the critical section where the singleton is created:

```csharp
lock (_lock)
{
    if (_instance == null)
    {
        _instance = new Singleton();
    }
}
```
⚠️ This pattern introduces a small performance overhead due to locking, 
but it's generally negligible unless the Instance property is accessed extremely frequently in performance-critical paths.

---

## 🚨 How is it different from the basic version?

| Basic Singleton                            | Thread-Safe Singleton                             |
|--------------------------------------------|--------------------------------------------------|
| ❌ Not safe in multithreaded environments   | ✅ Ensures only one instance in multi-threading   |
| ✅ Lightweight and fast in single-threaded  | ⚠️ Slightly slower due to locking (minor)         |
| 🧪 Risk of race conditions                  | 🔐 Uses `lock` to prevent concurrent instantiation |

---