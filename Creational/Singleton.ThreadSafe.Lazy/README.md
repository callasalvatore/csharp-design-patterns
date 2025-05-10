# 🧱 Singleton Pattern – Lazy<T> Version

This version of the Singleton pattern uses `.NET`'s built-in `Lazy<T>` type to achieve **lazy initialization** and **thread safety** in a clean and idiomatic way.

The Singleton instance is not created until it's accessed for the first time — and the entire lifecycle is managed by the .NET runtime, with no manual locking required.

---

## 💡 Why use Lazy<T>?

`Lazy<T>` provides a clean and robust mechanism for delaying object creation until it's needed. It simplifies thread-safe singleton implementations by removing the need for custom `lock` blocks or double-checked logic.

---

## 🔍 How is it different from the previous version?

| Static Initialization Singleton             | Lazy<T> Singleton                              |
|---------------------------------------------|------------------------------------------------|
| ✅ Thread-safe via CLR static guarantees     | ✅ Thread-safe via Lazy<T> implementation      |
| ⚡ Instance is created at type load time     | 🕰 Instance is created on first access         |
| ❌ Always created, even if never used        | ✅ Created only when needed (lazy)             |
| 🧱 Slightly more verbose                     | ✨ Cleaner, more idiomatic                     |

---

## 🧠 When to use this version

- When the singleton is **not always needed**
- When you want the cleanest, most modern syntax
- When **thread safety and lazy loading** are both required
- When you want to reduce boilerplate code

---

## ✅ Advantages

- Built-in thread-safety without locks
- Lazy initialization by default
- Cleaner and easier to test
- Encouraged by Microsoft and .NET community as best practice for most singleton use cases
