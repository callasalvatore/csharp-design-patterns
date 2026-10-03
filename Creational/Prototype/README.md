# 🧬 Prototype Pattern – Document Templates Example (C#)

This example demonstrates the **Prototype Pattern** in C#.  
New documents are created by **cloning preconfigured templates** (Invoice, Contract) stored in a registry, instead of building them from scratch.

---

## 💡 Intent

> Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

Use it when creating an object is expensive (e.g. loaded from files or a database) or complex to configure, and you need many similar objects.
The client asks for a copy of an existing object and doesn't need to know its concrete class or how it was built.

---

## 🧠 Key Concepts in This Example

| Role               | Class                      | Responsibility                                             |
|--------------------|----------------------------|------------------------------------------------------------|
| Prototype          | `IPrototype<T>`            | Declares the strongly typed `Clone()` method               |
| Concrete Prototype | `Document`                 | Clones itself, including its nested `Style` and `Section`s |
| Prototype Registry | `DocumentTemplateRegistry` | Stores the templates and returns clones by name            |
| Client             | `Program.cs`               | Gets clones from the registry and customizes them          |

---

## 🧪 Example Use Case

A document editor offers templates with a predefined style and sections.  
Every new document starts as a copy of a template and is then customized, while **the template must never change**.

---

## 🔍 Shallow vs Deep Copy

This is the most important detail of the pattern in C#.

- **Shallow copy** (`MemberwiseClone()`): copies the fields as they are. Reference-type fields still point to the **same objects**, so the copy and the original share them.
- **Deep copy**: nested mutable objects are cloned too, so the copy is fully independent.

`Document` contains a mutable `Style` and a `List<Section>`, so it needs a deep copy:

```csharp
public Document Clone() =>
    new(Title, Style.Clone(), Sections.Select(section => section.Clone()));
```

`Style` instead only has value-type and `string` members, so `MemberwiseClone()` is already enough.

---

## 📦 Example Execution

```csharp
// Deep clone from the registry
var invoice = registry.Create("invoice");
invoice.Style.FontSize = 14;
invoice.Sections.Add(new Section("Items", "10 x Consulting hours"));

Console.WriteLine(invoiceTemplate);

// Shallow clone of the same template
var shallowInvoice = invoiceTemplate.ShallowClone();
shallowInvoice.Title = "Invoice #002 - Shallow copy";
shallowInvoice.Style.FontSize = 20;
shallowInvoice.Sections.Add(new Section("Notes", "This section leaks into the template!"));

Console.WriteLine(invoiceTemplate);
```

Output:

```
[Invoice] (Arial, 11pt)
  - Header: Company name and address
  - Payment terms: 30 days from the invoice date

[Invoice] (Arial, 20pt)
  - Header: Company name and address
  - Payment terms: 30 days from the invoice date
  - Notes: This section leaks into the template!
```

After the deep clone the template is unchanged. After the shallow clone the template got the new font size and section.
The title is still `Invoice` because assigning a new `string` replaces the copy's reference without touching the original.

## ✅ Benefits

| Feature                        | Benefit                                                       |
| ------------------------------ | ------------------------------------------------------------- |
| ⚡ Avoids expensive creation    | The template is built once, then copied                       |
| 🙈 Hides concrete classes       | The client only knows the registry and the template's name    |
| 🧩 Runtime configuration        | New templates can be registered without new subclasses        |
| 🔒 Protects the originals       | The registry only hands out clones                            |

## ⚠️ Notes

- **Avoid `ICloneable`**: it returns `object` and doesn't say whether the copy is shallow or deep. Microsoft's guidelines recommend not using it in public APIs. A generic interface like `IPrototype<T>` makes both the type and the contract explicit.
- **Records and `with` are shallow**: `doc with { Title = "New" }` copies the references of mutable members like a `List`, so the copy and the original would share it.
- **Serialization** (e.g. to and from JSON) can produce a deep copy without writing clone methods, but it's slower and only copies what the serializer can see.

## 🔄 Alternatives & Related Patterns

- Use **[Factory Method](../FactoryMethod/README.md)** when creation logic should vary through subclasses instead of copies.
- **[Abstract Factory](../AbstractFactory/README.md)** can store prototypes and clone them instead of instantiating concrete classes.
- Use **[Builder](../Builder/README.md)** when the problem is assembling a complex object step by step, rather than copying an existing one.
