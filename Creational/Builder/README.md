# 🏗️ Builder Pattern – Computer Configuration Example (C#)

This example demonstrates the **Builder Pattern** in C#.  
It builds an **immutable `Computer`** made of required parts (CPU, RAM, storage) and optional parts (GPU, Wi-Fi) step by step, without a constructor full of parameters.

---

## 💡 Intent

> Separate the construction of a complex object from its representation, so that the same construction process can create different representations.

Use it when an object has many parameters, some of them optional, or when it must be valid and immutable once created.
Without a builder you end up with a *telescoping constructor* (`new Computer("i5", 16, 512, null, true)`), which is hard to read and easy to get wrong.

---

## 🧠 Key Concepts in This Example

| Role             | Class              | Responsibility                                                   |
|------------------|--------------------|------------------------------------------------------------------|
| Builder          | `IComputerBuilder` | Declares the construction steps (fluent interface)               |
| Concrete Builder | `ComputerBuilder`  | Collects the parts, validates them and creates the product       |
| Director         | `ComputerDirector` | Encapsulates the steps for well-known configurations             |
| Product          | `Computer`         | The immutable object being built                                 |
| Client           | `Program.cs`       | Uses the director for presets, or the builder for custom builds  |

---

## 🧪 Example Use Case

A PC configurator offers some predefined models (Office, Gaming) and also lets the customer pick each component.  
The **Director** handles the presets, while the **Builder** is also exposed to clients for custom configurations.  
The `Build()` method is the single point where the configuration is validated, so an invalid `Computer` can never exist.

---

## 📦 Example Execution

```csharp
IComputerBuilder builder = new ComputerBuilder();

// Predefined configurations
var director = new ComputerDirector(builder);

Console.WriteLine("Office PC:");
Console.WriteLine(director.BuildOfficePc());

Console.WriteLine("Gaming PC:");
Console.WriteLine(director.BuildGamingPc());

// Custom configuration
var customPc = builder
    .WithCpu("Apple M3")
    .WithRam(24)
    .WithStorage(1000)
    .WithWifi()
    .Build();

Console.WriteLine("Custom PC:");
Console.WriteLine(customPc);

// Missing required parts
try
{
    builder.WithRam(8).Build();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Invalid configuration: {ex.Message}");
}
```

Output:

```
Office PC:
CPU: Intel Core i5 | RAM: 16 GB | Storage: 512 GB | GPU: Integrated | Wi-Fi: Yes
Gaming PC:
CPU: AMD Ryzen 9 | RAM: 32 GB | Storage: 2000 GB | GPU: NVIDIA RTX 4080 | Wi-Fi: No
Custom PC:
CPU: Apple M3 | RAM: 24 GB | Storage: 1000 GB | GPU: Integrated | Wi-Fi: Yes
Invalid configuration: A CPU is required.
```

## ✅ Benefits

| Feature                          | Benefit                                                         |
| -------------------------------- | --------------------------------------------------------------- |
| 📖 Readable construction          | Named steps instead of long, positional constructor parameters  |
| 🔒 Immutable and always valid     | Validation happens once in `Build()`, the product has no setters |
| ♻️ Reusable construction logic    | The director centralizes common configurations                  |
| 🧩 Optional parts made explicit   | Clients call only the steps they need                           |

## ⚠️ Notes

- The **Director is optional**: many modern C# builders (e.g. `StringBuilder`, `HostApplicationBuilder`, `UriBuilder`) are used directly through a fluent API.
- `ComputerBuilder` resets its state after `Build()`, so a single instance can be reused. Builders are **not thread-safe**: don't share one across threads.
- For simple objects with few parameters, C# **object initializers** with `required`/`init` properties are often enough and a builder would be over-engineering.

## 🔄 Alternatives & Related Patterns

- Use **[Abstract Factory](../AbstractFactory/README.md)** when you need families of related objects created in a single call.
- Use **[Factory Method](../FactoryMethod/README.md)** when subclasses should decide which object to create.
- Builder is often used to create **Composite** structures, since it can build them step by step.
