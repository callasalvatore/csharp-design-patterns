# C# Design Patterns

> [!WARNING]  
> This repository is a work in progress. More patterns will be added soon.

This repository contains examples of common design patterns implemented in C#.  
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
  - Command
  - Interpreter
  - Iterator
  - Mediator
  - Memento
  - Observer
  - State
  - Strategy
  - Template Method
  - Visitor

Each folder contains:
- A simple C# console app demonstrating the pattern.
- A brief explanation of how it works.
- Code comments for clarity.

## ✅ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Any IDE (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Rider](https://www.jetbrains.com/rider/), or [VS Code](https://code.visualstudio.com/))

## 🚀 Getting Started

```bash
git clone https://github.com/your-username/CSharp-Design-Patterns.git
cd CSharp-Design-Patterns
dotnet build
```

To run a specific pattern demo:

```bash
cd Creational/Singleton
dotnet run
```

# 🧠 Why Design Patterns?

Design patterns are proven solutions to recurring problems in software design.
They help make your code more flexible, reusable, and easier to maintain.

Happy coding! 🎯

I want you to know that contributions and suggestions are welcome.
