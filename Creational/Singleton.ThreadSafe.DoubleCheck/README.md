# 🧱 Singleton Pattern – Thread-Safe with Double-Checked Locking

This version improves the basic thread-safe Singleton by using **double-checked locking**.

The idea is to avoid acquiring the lock unnecessarily once the instance has already been initialized — reducing overhead in high-read, low-write scenarios.

**Singleton.cs**
```csharp
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
```
---

**Program.cs**
```csharp
using SingletonThreadSafeDoubleCheck;

var s1 = Singleton.Instance;
var s2 = Singleton.Instance;

Console.WriteLine(ReferenceEquals(s1, s2)
    ? "Same instance"
    : "Different instances");

s1.DoWork();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
```

## 💡Differences from the previous version

| Basic Thread-Safe Singleton            | Double-Checked Locking Version                          |
|----------------------------------------|----------------------------------------------------------|
| Always enters the `lock` block         | Only locks **if** instance is `null`                    |
| ✅ Safe in multithreaded environments  | ✅ Still safe in multithreaded environments              |
| ❌ Slight performance overhead on every access | ✅ More performant after initialization         |
| ✅ Easy to read                        | 🔧 Slightly more complex but idiomatic with `??=` syntax |

---

## 🔍 Why it's better

- The first `if (_instance is null)` avoids locking once the instance is already created.
- Inside the `lock`, `??=` ensures that only the first thread creates the instance.
- It's safe and more efficient, especially in scenarios where `Instance` is accessed frequently.

This pattern is very common in modern C# implementations and strikes a good balance between performance and thread-safety.

---

## 🧠 When to use this version

- You need thread safety
- You want to optimize performance by avoiding locking after initialization
- You prefer using `is null` and `??=` for readability and conciseness