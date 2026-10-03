# C# Design Patterns

This repository contains examples of the 23 GoF design patterns implemented in C#.  
Each pattern is organized by category and includes a simple, focused implementation with inline explanations.

## 📁 Structure

The patterns are grouped into the following categories:

- **Creational Patterns**  
  Deal with object creation mechanisms.
  - Singleton
    - [Basic](Creational/Singleton.Basic/README.md)
    - [Thread Safe](Creational/Singleton.ThreadSafe/README.md)
    - [Thread Safe Double Check](Creational/Singleton.ThreadSafe.DoubleCheck/README.md)
    - [Thread Safe No Lock](Creational/Singleton.ThreadSafe.NoLock/README.md)
    - [Thread Safe Lazy](Creational/Singleton.ThreadSafe.Lazy/README.md)
  - [Factory Method](Creational/FactoryMethod/README.md)
  - [Abstract Factory](Creational/AbstractFactory/README.md)
  - [Builder](Creational/Builder/README.md)
  - [Prototype](Creational/Prototype/README.md)

- **Structural Patterns**  
  Deal with object composition and relationships.
  - [Adapter](Structural/Adapter/README.md)
  - [Bridge](Structural/Bridge/README.md)
  - [Composite](Structural/Composite/README.md)
  - [Decorator](Structural/Decorator/README.md)
  - [Facade](Structural/Facade/README.md)
  - [Flyweight](Structural/Flyweight/README.md)
  - [Proxy](Structural/Proxy/README.md)

- **Behavioral Patterns**  
  Deal with communication between objects.
  - [Chain of Responsibility](Behavioral/ChainOfResponsibility/README.md)
  - [Command](Behavioral/Command/README.md)
  - [Interpreter](Behavioral/Interpreter/README.md)
  - [Iterator](Behavioral/Iterator/README.md)
  - [Mediator](Behavioral/Mediator/README.md)
  - [Memento](Behavioral/Memento/README.md)
  - [Observer](Behavioral/Observer/README.md)
  - [State](Behavioral/State/README.md)
  - [Strategy](Behavioral/Strategy/README.md)
  - [Template Method](Behavioral/TemplateMethod/README.md)
  - [Visitor](Behavioral/Visitor/README.md)

Each folder contains:
- A simple C# console app demonstrating the pattern with a concrete example.
- A README explaining how it works, with a UML diagram and the demo output.
- Code comments for clarity.

## ✅ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Any IDE (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Rider](https://www.jetbrains.com/rider/), or [VS Code](https://code.visualstudio.com/))

## 🚀 Getting Started

```bash
git clone https://github.com/callasalvatore/csharp-design-patterns.git
cd csharp-design-patterns
dotnet build
```

To run a specific pattern demo:

```bash
dotnet run --project Behavioral/Observer
```

# 🧠 Why Design Patterns?

Design patterns are proven solutions to recurring problems in software design.
They help make your code more flexible, reusable, and easier to maintain.

Happy coding! 🎯

I want you to know that contributions and suggestions are welcome.
