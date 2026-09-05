# ☕ Cafe Management System

A **console-based Cafe Management System** developed with **C# and .NET 8**, focused on implementing data persistence and CRUD-style operations using **plain text files instead of a traditional database**.

The project was created to practice **file handling, object-oriented programming, authentication logic, data parsing, and managing application data through `.txt` files**.

---

## 📌 Overview

This project simulates the core functionality of a small cafe management system.

Instead of using SQL Server, Entity Framework, SQLite, or another database management system, the application stores its data directly in **text files**.

The application supports two main types of users:

* 👤 **Customer / User**
* 👨‍💼 **Admin**

Users can log in, browse cafe items, place orders, and store their purchases.

Administrators have additional capabilities such as managing cafe items, purchasing ingredients, viewing customers, and calculating the cafe's financial result.

---

## ✨ Features

### 🔐 Authentication

The application provides a simple file-based authentication system.

Users can:

* Sign up
* Log in
* Store username and password
* Store email address
* Be assigned a role
* Authenticate against records stored in `Customers.txt`

New users are appended directly to the customer text file using `StreamWriter`. During login, the application reads the file and parses the stored records to verify the provided username and password.

---

## 👤 User Features

After successfully logging in as a normal user, the user can:

### 🛒 Place an Order

The user can:

1. View available cafe items
2. Select an item
3. Enter the desired quantity
4. Calculate the total price
5. Store the order in the user cart file

The order information includes:

* Order ID
* User ID
* Item ID
* Item name
* Quantity
* Total item price

Orders are persisted in `UserCart.txt`.

---

## 👨‍💼 Admin Features

Administrators have access to additional functionality.

### ➕ Add Cafe Items

An administrator can add a new item by entering:

* Item name
* Item price

The item is then appended to `Items.txt`.

Each item is stored with an ID, name, and price.

Example format:

```text
ID : 1, Name : Coffee, Price : 100
ID : 2, Name : Cake, Price : 150
```

---

### 🗑️ Delete Items

Administrators can delete items from the cafe menu.

The application:

1. Reads all lines from `Items.txt`
2. Searches for the requested item
3. Removes the matching line
4. Writes the modified collection back to the file

This demonstrates how a **delete operation can be implemented using a text file as the data store**.

---

### 🧂 Purchase Ingredients

Administrators can view available ingredients and purchase required quantities.

Ingredient information is read from `Ingrediants.txt`.

The application parses:

* Ingredient ID
* Ingredient name
* Ingredient price

The selected ingredients and calculated costs are then stored in `IngrediantCart.txt`.

---

### 👥 View Customers

Administrators can display the stored customer records by reading `Customers.txt` using `StreamReader`.

---

### 💰 Financial Calculation

The system can calculate the cafe's financial result by comparing:

**Income**

from customer orders stored in:

```text
UserCart.txt
```

with

**Expenses**

from purchased ingredients stored in:

```text
IngrediantCart.txt
```

The application calculates:

```text
Profit = Income - Expenses
```

or, if expenses are higher:

```text
Loss = Expenses - Income
```

The result is then displayed in the console.

---

# 📁 Data Storage

One of the main purposes of this project is demonstrating how application data can be persisted **without using a database**.

The application uses several text files as its data store.

```text
┌─────────────────────┐
│    Customers.txt    │
│                     │
│ Users & credentials │
└──────────┬──────────┘
           │
           │
┌──────────▼──────────┐
│      Items.txt      │
│                     │
│ Cafe menu & prices  │
└──────────┬──────────┘
           │
           │
┌──────────▼──────────┐
│   UserCart.txt      │
│                     │
│ Customer orders     │
└─────────────────────┘


┌─────────────────────┐
│   Ingrediants.txt   │
│                     │
│ Available materials │
└──────────┬──────────┘
           │
           ▼
┌─────────────────────┐
│ IngrediantCart.txt  │
│                     │
│ Purchased materials │
└─────────────────────┘
```

The file paths are currently defined directly in `Program.cs`.

---

# 💾 File Handling

File I/O is the core concept of this project.

The application uses several classes and methods from `System.IO`.

### Reading Files

For reading complete files:

```csharp
File.ReadAllLines(filePath);
```

For sequential reading:

```csharp
StreamReader sr = new StreamReader(filePath);

string line = sr.ReadLine();

while (line != null)
{
    // Process line

    line = sr.ReadLine();
}

sr.Close();
```

The project uses both approaches depending on the operation being performed.

---

### Writing to Files

New records are appended using:

```csharp
StreamWriter sw = File.AppendText(filePath);

sw.Write(...);

sw.Close();
```

This approach allows new customers, items, and orders to be added without overwriting existing records.

---

### Updating Files

Because text files do not provide database-style update operations, the application can modify data by:

```text
Read file
   ↓
Load lines into memory
   ↓
Modify the collection
   ↓
Write the modified collection
   ↓
Replace the original file content
```

For example, deleting an item is implemented by reading all lines into a `List`, removing the matching entry, and calling:

```csharp
File.WriteAllLines(filePath, lines);
```

---

# 🧩 Text-Based Data Format

The application stores structured information as plain text.

For example, customer records follow a format similar to:

```text
ID : 0, Role : User, Username : Sobhan, Password : 1234, Email : example@gmail.com
```

Items are stored in a similar format:

```text
ID : 1, Name : Coffee, Price : 100
```

Orders contain several fields:

```text
ID : 1, UserID : 2, ItemID : 1, ItemName : Coffee, Qty : 2, ItemPrice : 200
```

The application reconstructs the required information by splitting each line using delimiters such as:

```csharp
line.Split(',')
```

and then extracting individual values from each section.

---

# 🔄 Application Flow

The general application flow is:

```text
                    ┌───────────────┐
                    │    Program    │
                    └───────┬───────┘
                            │
                            ▼
                  ┌──────────────────┐
                  │ Login / Sign Up  │
                  └────────┬─────────┘
                           │
                ┌──────────┴──────────┐
                │                     │
                ▼                     ▼
          ┌───────────┐         ┌───────────┐
          │   Admin   │         │   User    │
          └─────┬─────┘         └─────┬─────┘
                │                     │
        ┌───────┼────────┐            │
        │       │        │            │
        ▼       ▼        ▼            ▼
      Items  Ingredients Customers   Orders
        │       │        │            │
        ▼       ▼        ▼            ▼
     Items.txt  │   Customers.txt UserCart.txt
                │
                ▼
       IngrediantCart.txt
```

---

# 🏗️ Project Structure

The project is organized around a main console program and model classes.

```text
Cafe-CRUD/
│
├── Cafe/
│   │
│   ├── Models/
│   │   ├── Customer.cs
│   │   ├── Ingredients.cs
│   │   ├── IngrediantsCart.cs
│   │   └── UserCart.cs
│   │
│   ├── Program.cs
│   └── Cafe.csproj
│
├── Cafe.sln
├── .gitignore
└── README.md
```

> The exact files and model names should be kept synchronized with the repository as the project evolves.

---

# 🧱 Main Models

The application uses model classes to represent the main entities of the system.

### Customer

Represents a cafe customer/user.

Relevant information includes:

* ID
* Username
* Password
* Email
* Role

---

### Ingredients

Represents ingredients available for purchase.

Information includes:

* Ingredient ID
* Ingredient name
* Price

---

### IngrediantsCart

Represents ingredients purchased by the cafe.

It is used when calculating the cafe's expenses.

---

### UserCart

Represents items purchased by customers.

It stores information such as:

* User ID
* Item ID
* Item name
* Quantity
* Total price

The model is populated while processing customer orders and then persisted in `UserCart.txt`.

---

# 🛠️ Technology Stack

| Technology              | Usage                         |
| ----------------------- | ----------------------------- |
| **C#**                  | Main programming language     |
| **.NET 8**              | Application framework/runtime |
| **Console Application** | User interface                |
| **System.IO**           | File handling and persistence |
| **TXT Files**           | Data storage                  |
| **OOP**                 | Domain modeling               |

The project targets **.NET 8** and is configured as an executable application.

---

# 📚 Concepts Demonstrated

This project focuses primarily on fundamental programming and data-persistence concepts.

### C# Programming

* Classes
* Objects
* Properties
* Methods
* Lists
* Dictionaries
* Loops
* Conditional statements
* String manipulation
* Type conversion

### File Handling

* `File.ReadAllLines()`
* `File.WriteAllLines()`
* `File.AppendText()`
* `StreamReader`
* `StreamWriter`
* Reading line by line
* Appending records
* Rewriting file contents

### Data Processing

* String splitting
* Parsing structured text
* Extracting IDs
* Extracting prices
* Converting strings to numeric values
* Searching records

### Application Logic

* Authentication
* Role-based functionality
* Shopping cart
* Order processing
* Inventory/ingredient purchasing
* Income calculation
* Expense calculation
* Profit/loss calculation

---

# 🔄 CRUD Operations with Text Files

Although the application does not use a relational database, it demonstrates the fundamental CRUD concepts.

| CRUD       | Implementation                                                 |
| ---------- | -------------------------------------------------------------- |
| **Create** | Append a new record to a `.txt` file                           |
| **Read**   | Read records using `File.ReadAllLines` / `StreamReader`        |
| **Update** | Modify records in memory and rewrite the file                  |
| **Delete** | Remove records from the loaded collection and rewrite the file |

For example:

```text
CREATE
   │
   ▼
StreamWriter
   │
   ▼
Append record
   │
   ▼
TXT File
```

While deletion follows:

```text
TXT File
   │
   ▼
Read all lines
   │
   ▼
List<string>
   │
   ▼
Remove record
   │
   ▼
File.WriteAllLines()
   │
   ▼
Updated TXT File
```

This makes the project useful for understanding the difference between **application-level CRUD logic** and the capabilities normally provided by a database.

---

# ⚠️ Limitations

Using text files as a data store is useful for learning and small educational applications, but it has several limitations compared with a real database.

### Current limitations include:

* Data is stored as unstructured text
* File paths are currently hard-coded
* No database engine
* No transaction management
* No concurrent access control
* Limited validation
* Passwords are stored as plain text
* Parsing depends on the exact text format
* Searching requires reading through file contents
* Updating records requires rewriting file contents
* No database indexing
* No relational constraints
* No automated tests

These limitations are intentional trade-offs for a project focused on learning **file-based persistence and data handling**.

---

# 🚀 Future Improvements

Possible improvements include:

### 1. Better File Storage

Replace hard-coded paths with configurable paths:

```text
Data/
├── Customers.txt
├── Items.txt
├── Ingredients.txt
├── IngredientCart.txt
└── UserCart.txt
```

### 2. Better Data Serialization

Instead of manually parsing comma-separated strings, the project could use:

* JSON
* XML
* CSV

For example:

```json
{
  "id": 1,
  "name": "Coffee",
  "price": 100
}
```

### 3. Password Security

Passwords should be hashed instead of being stored directly as plain text.

### 4. Separation of Responsibilities

The current implementation contains much of the application logic inside `Program.cs`.

A future version could separate:

```text
UI
 │
 ▼
Services
 │
 ▼
Repositories
 │
 ▼
File Storage
```

For example:

```text
CustomerService
ItemService
OrderService
IngredientService
       │
       ▼
FileRepository
       │
       ▼
TXT Files
```

### 5. Database Migration

As the application grows, the text-file persistence layer could eventually be replaced with:

* SQL Server
* SQLite
* PostgreSQL

without changing the overall business concepts.

---

# 🎯 Project Goals

The main goal of this project was to understand how a real application can manage persistent data using **basic file I/O instead of a database**.

Specifically, the project demonstrates:

* How data can be persisted between application executions
* How records can be represented as text
* How structured information can be extracted from strings
* How CRUD operations can be implemented manually
* How different text files can represent different entities
* How application logic can operate on file-based data
* How user roles can affect available functionality

---

# 📖 What I Learned

Through this project, I practiced:

* C# fundamentals
* Object-oriented programming
* File system operations
* Text-file persistence
* Reading and writing structured text
* Parsing strings
* Implementing authentication logic
* Designing role-based application flows
* Implementing CRUD operations without a database
* Managing relationships between users, items, orders, and ingredients
* Calculating business-level metrics such as income, expenses, profit, and loss

---

# ▶️ Getting Started

## Prerequisites

Make sure you have:

* .NET 8 SDK
* Visual Studio / VS Code / JetBrains Rider
* Git

---

## Clone the Repository

```bash
git clone https://github.com/Sobhankhedry/Cafe-CRUD.git
```

Navigate into the project:

```bash
cd Cafe-CRUD
```

---

## Run the Application

```bash
dotnet run --project Cafe
```

The application runs as a console program and presents the available options directly in the terminal.

---

# ⚠️ Important Configuration Note

The current version of the application contains **absolute Windows file paths** inside `Program.cs`, for example:

```text
C:\Users\...\Customers.txt
```

Therefore, before running the application on another machine, these paths need to be changed to valid paths on that machine.

A future version should use relative paths such as:

```text
Data/Customers.txt
```

to make the project portable.

---

# 👨‍💻 Author

**Sobhan Khedry**

Computer Engineering Graduate Student
Backend Development Enthusiast

GitHub: [@Sobhankhedry](https://github.com/Sobhankhedry)

---

# ⭐ Project Summary

**Cafe Management System** is an educational C# console application that demonstrates how a small business-management system can be implemented using **plain text files as persistent storage**.

The project combines:

```text
C#
+
OOP
+
File I/O
+
Text-Based Persistence
+
Authentication
+
CRUD
+
Order Management
+
Financial Calculation
```

The main learning focus is understanding **how data storage and CRUD operations work at a lower level before introducing a dedicated database system**.
