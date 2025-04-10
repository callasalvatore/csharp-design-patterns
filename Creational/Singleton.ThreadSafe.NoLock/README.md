# 🧱 Singleton Pattern – Thread-Safe without Locks (Eager Initialization)

This version of the Singleton pattern takes advantage of **CLR's static initialization** behavior to ensure thread safety **without using locks**.

The instance is created **at the time of type loading**, which makes this both simple and safe — no explicit synchronization is required.

---

# 🔍 What happens with static in .NET?

When you write:

```csharp
private static readonly Singleton _instance = new();
```

You're relying on the CLR to initialize that static field exactly once, when the type is first used.

The CLR follows the .NET type initialization guarantees, which are defined by the ECMA specification for the CLI (Common Language Infrastructure). Here's what it says:

✅ The CLR guarantees:
“A type initializer (also called a static constructor or .cctor) is executed once and only once, per AppDomain, and is guaranteed to be thread-safe.”

That means:

- Only one thread will execute the static constructor (even if multiple threads access the class at the same time).
- Other threads are blocked until the static constructor finishes.
- No race conditions can occur in the initialization of static fields.

so, in the previous line, the `_instance` is:

- Created once
- Guaranteed to be completed before any thread can access ``Singleton.Instance``
- Fully synchronized by the runtime itself

Even if you don’t write a static constructor explicitly (static Singleton() { }), the compiler will generate one for you if static fields are declared and initialized.

## 🚀 When is the static constructor triggered?

- The first time any static member of the class is accessed 
- OR the first time an instance is created (new Singleton() — which you’ve blocked anyway with a private constructor)

---

## 💡 How is it different from the double-checked version?

| Double-Checked Locking Singleton         | No-Lock (Eager Initialization) Singleton             |
|------------------------------------------|------------------------------------------------------|
| ✅ Thread-safe with conditional locking   | ✅ Thread-safe without locking                       |
| 🕰 Lazy initialization (on first use)     | ⚡ Eager initialization (when type is loaded)        |
| ⚙ Slightly more complex                  | ✨ Very simple implementation                        |
| ✅ Better for heavy construction on-demand | ❌ Might create the instance even if never used     |

---

## 🧠 When to use this version

- You want **simplicity and safety** with minimal code
- The singleton object is **cheap to create**
- The singleton is **always used** during the application's lifetime

---

## ⚠️ Trade-Off

This version creates the instance **even if it's never accessed**, which could be wasteful if the object is heavy and never actually needed.

If lazy instantiation is important, consider using:
- **Double-checked locking** (as in the previous version), or
- **Lazy<T>** (recommended and idiomatic in modern C#)

---

## ⏭ Next: [Singleton with Lazy<T> ➡](../Singleton.Lazy/)
