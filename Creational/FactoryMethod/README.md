# 🏭 Factory Method Pattern – Notification System (C#)

This example demonstrates the **Factory Method Pattern** through a simple notification system that supports sending messages via **Email** or **SMS**.

Rather than instantiating notifications directly with `new`, the object creation is handled by factory methods (`CreateNotification()`) defined in abstract and concrete sender classes.

---

## 💡 Intent

> Define an interface for creating an object, but let subclasses decide which class to instantiate.

This pattern promotes loose coupling by delegating the responsibility of object creation to subclasses.

---

## 🧠 Structure Overview

| Role                  | Class                        | Description                                            |
|-----------------------|------------------------------|--------------------------------------------------------|
| Creator (abstract)    | `NotificationSender`         | Declares the factory method `CreateNotification()`     |
| Concrete Creators     | `EmailSender`, `SmsSender`   | Implement the factory method to return specific objects |
| Product (interface)   | `INotification`              | Defines the `Send()` method for all notifications      |
| Concrete Products     | `EmailNotification`, `SmsNotification` | Implement actual sending logic                  |

---

## ⚙️ How It Works

1. The client (in `Program.cs`) creates an instance of `EmailSender` or `SmsSender`.
2. The client calls `CreateNotification()` to get a concrete `INotification`.
3. The client sends a message without knowing the concrete class details.

---

### 📌 Sample Flow (as seen in `Program.cs`)

```csharp
NotificationSender emailSender = new EmailSender();
var emailNotification = emailSender.CreateNotification();
emailNotification.Send("Hello, this is an email notification!");

var smsSender = new SmsSender();
var smsNotification = smsSender.CreateNotification();
smsNotification.Send("This is an SMS notification.");
```

This shows how the client depends only on the abstract factory and the common 
interface, not on concrete implementations.

## ✅ Benefits

| Feature                          | Benefit                                                      |
| -------------------------------- | ------------------------------------------------------------ |
| 🔄 Decouples creation from usage | Client code does not need to know which class to instantiate |
| 🧱 Open/Closed Principle         | New types (e.g., `PushNotification`) can be added easily     |
| 🧪 Easier to test and mock       | Factories and interfaces make unit testing simpler           |

