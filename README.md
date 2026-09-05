# ☕ Cafe CRUD

A web-based **Cafe Management System** built with **ASP.NET Core MVC**, designed to manage cafe-related data through a database-driven CRUD application.

The project focuses on implementing the core operations required in a cafe management system while practicing the **MVC architectural pattern**, database interaction, server-side rendering, and modern .NET web development.

---

## 📌 Overview

**Cafe CRUD** is an ASP.NET Core MVC application that provides a structured interface for managing cafe information.

The project was developed to practice building a complete database-backed web application rather than implementing isolated CRUD operations.

The application follows the traditional MVC request flow:

```text
User
 │
 ▼
Browser
 │
 ▼
Controller
 │
 ▼
Model / Entity
 │
 ▼
Entity Framework Core
 │
 ▼
Database
```

The result is a web application where users can interact with persistent data through a clean MVC-based interface.

---

# 🎯 Project Objectives

The main objectives of the project are:

* Learn and apply ASP.NET Core MVC
* Implement database-backed CRUD operations
* Work with Entity Framework Core
* Design and use application models
* Create MVC Controllers
* Build Razor Views
* Connect an ASP.NET application to a relational database
* Understand the MVC request lifecycle
* Practice server-side form handling and validation
* Work with Entity Framework Core migrations

---

# ✨ Core Functionality

The application is centered around the standard CRUD workflow:

### ➕ Create

Create new cafe records through an MVC form.

```text
Form
 ↓
POST Request
 ↓
Controller
 ↓
Entity Framework Core
 ↓
Database
```

### 👁️ Read

Retrieve and display stored records through MVC views.

### ✏️ Update

Edit existing records and persist the changes to the database.

### 🗑️ Delete

Remove existing records from the database.

Together, these operations form the core of the application's data-management workflow.

---

# 🏗️ Architecture

The project follows the **Model-View-Controller (MVC)** pattern.

```text
                    ┌──────────────┐
                    │    Browser   │
                    └──────┬───────┘
                           │
                           │ HTTP
                           ▼
                  ┌─────────────────┐
                  │   Controller    │
                  └────────┬────────┘
                           │
                           ▼
                  ┌─────────────────┐
                  │     Model       │
                  └────────┬────────┘
                           │
                           ▼
                  ┌─────────────────┐
                  │ Entity Framework│
                  │      Core       │
                  └────────┬────────┘
                           │
                           ▼
                  ┌─────────────────┐
                  │    Database     │
                  └─────────────────┘
```

### Model

Represents the application's data and domain entities.

### View

Responsible for displaying data and providing forms for user interaction.

### Controller

Handles HTTP requests, communicates with the data layer, and selects the appropriate View.

---

# 🗄️ Database

The project uses a relational database to persist application data.

**Entity Framework Core** acts as the ORM between the C# application and the database.

This allows application entities to be represented as C# classes while EF Core handles database communication.

The general flow is:

```text
C# Entity
   │
   ▼
EF Core
   │
   ▼
Relational Table
```

---

# 🔄 CRUD Lifecycle

A typical update operation follows:

```text
User opens Edit page
        │
        ▼
GET /Entity/Edit/{id}
        │
        ▼
Controller retrieves entity
        │
        ▼
Entity displayed in View
        │
        ▼
User modifies data
        │
        ▼
POST /Entity/Edit
        │
        ▼
Controller validates input
        │
        ▼
EF Core updates entity
        │
        ▼
SaveChanges()
        │
        ▼
Database updated
```

The same MVC pattern is used for the Create, Read, and Delete operations.

---

# 🛠️ Technology Stack

| Technology                | Purpose                    |
| ------------------------- | -------------------------- |
| **C#**                    | Programming language       |
| **ASP.NET Core MVC**      | Web application framework  |
| **Entity Framework Core** | ORM / database access      |
| **Razor**                 | Server-side HTML rendering |
| **HTML5**                 | Application structure      |
| **CSS3**                  | Styling                    |
| **JavaScript**            | Client-side interactions   |
| **SQL Database**          | Data persistence           |
| **Bootstrap**             | UI / responsive design     |

---

# 📁 Project Structure

A typical structure of the MVC application is:

```text
Cafe-CRUD/
│
├── Cafe/
│   │
│   ├── Controllers/
│   │
│   ├── Models/
│   │
│   ├── Views/
│   │   ├── Shared/
│   │   └── ...
│   │
│   ├── Data/
│   │
│   ├── Migrations/
│   │
│   ├── wwwroot/
│   │   ├── css/
│   │   ├── js/
│   │   └── lib/
│   │
│   ├── Properties/
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── Cafe.csproj
│
└── ...
```

---

# 🔗 MVC Request Flow

The application's architecture can be understood through the following flow:

```text
                HTTP Request
                     │
                     ▼
              ┌─────────────┐
              │ Controller  │
              └──────┬──────┘
                     │
                     ▼
              ┌─────────────┐
              │   Model     │
              └──────┬──────┘
                     │
                     ▼
             ┌──────────────┐
             │    EF Core   │
             └──────┬───────┘
                    │
                    ▼
              ┌─────────────┐
              │  Database   │
              └──────┬──────┘
                     │
                     ▼
              Controller
                     │
                     ▼
                  View
                     │
                     ▼
                 Browser
```

This separation makes it easier to understand how data moves through an MVC application.

---

# 📝 Forms & Validation

CRUD applications rely heavily on user input.

The application therefore demonstrates the process of:

```text
User Input
    ↓
HTTP Form
    ↓
Model Binding
    ↓
Validation
    ↓
Controller
    ↓
Database
```

Server-side validation is particularly important because client-side validation alone cannot guarantee that invalid data will not reach the backend.

---

# 🧩 Entity Framework Core

Entity Framework Core provides the application's database abstraction layer.

Instead of manually writing SQL for every operation, application code can work with strongly typed entities.

For example:

```csharp
db.Cafes.Add(cafe);

await db.SaveChangesAsync();
```

This approach simplifies database interaction while keeping the application code closely aligned with the domain model.

---

# 🔄 Migrations

Entity Framework Core migrations allow database schema changes to be tracked alongside application code.

Typical commands include:

```bash
dotnet ef migrations add InitialCreate
```

and:

```bash
dotnet ef database update
```

This provides a reproducible way to create and update the database schema during development.

---

# ⚙️ Getting Started

## Prerequisites

Install the following:

* .NET SDK
* SQL Server or compatible relational database
* Git
* Visual Studio / VS Code / JetBrains Rider

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

## Restore Dependencies

```bash
dotnet restore
```

---

## Configure the Database

Update the database connection string inside:

```text
Cafe/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

> ⚠️ Never commit production database credentials or passwords to source control.

---

## Apply Migrations

If the project contains Entity Framework Core migrations:

```bash
dotnet ef database update
```

---

## Build

```bash
dotnet build
```

---

## Run

```bash
dotnet run --project Cafe
```

The application will display the local HTTP/HTTPS address in the terminal.

Open that address in your browser.

---

# 🧪 Testing the CRUD Workflow

After starting the application, the basic workflow is:

```text
1. Open the application
        ↓
2. Navigate to the relevant entity
        ↓
3. Create a new record
        ↓
4. Verify the record
        ↓
5. Open the Edit page
        ↓
6. Modify the record
        ↓
7. Save changes
        ↓
8. Verify the updated data
        ↓
9. Delete the record
        ↓
10. Verify deletion
```

This provides a complete end-to-end test of the CRUD lifecycle.

---

# 💡 What I Learned From This Project

This project provides practical experience with several important backend/web-development concepts:

### ASP.NET Core

* MVC architecture
* Routing
* Controllers
* Actions
* Model binding
* Dependency injection
* Configuration

### Entity Framework Core

* DbContext
* Entities
* LINQ queries
* CRUD operations
* Change tracking
* Migrations
* Database persistence

### Web Development

* HTTP request/response lifecycle
* Razor Views
* HTML forms
* Server-side validation
* Client/server interaction

### Database

* Relational data
* Tables
* Primary keys
* Entity relationships
* Persistent storage

---

# 🧠 Why CRUD Is Important

CRUD operations may appear simple, but they form the foundation of many real-world business applications.

Most enterprise applications contain some variation of:

```text
Create
Read
Update
Delete
```

Examples include:

* Inventory systems
* E-commerce platforms
* Customer management systems
* Hospital management systems
* Student management systems
* Restaurant and cafe systems
* Administration dashboards

This project provided hands-on experience with the complete lifecycle of database-backed web operations.

---

# 🚧 Current Limitations

This project is primarily focused on learning and implementing MVC + CRUD concepts.

For a production-ready system, several areas could be improved:

* [ ] Authentication
* [ ] Authorization
* [ ] Role-based access control
* [ ] DTOs / ViewModels
* [ ] Service layer
* [ ] Global exception handling
* [ ] Structured logging
* [ ] Automated tests
* [ ] Unit tests
* [ ] Integration tests
* [ ] Advanced validation
* [ ] Pagination
* [ ] Search and filtering
* [ ] Sorting
* [ ] Docker support
* [ ] CI/CD pipeline
* [ ] Production deployment

---

# 🔮 Future Improvements

A future version could evolve into a complete cafe management platform.

Possible features:

```text
Cafe
 │
 ├── Products
 │
 ├── Categories
 │
 ├── Orders
 │
 ├── Customers
 │
 ├── Employees
 │
 ├── Inventory
 │
 ├── Payments
 │
 └── Reports
```

Additional functionality could include:

* Order management
* Product inventory
* Sales reporting
* Customer management
* Employee management
* Authentication and authorization
* Admin dashboard
* Real-time order tracking
* Payment integration

---

# 📊 Project Scope

The project demonstrates the complete path from a user's browser to persistent database storage:

```text
┌───────────────┐
│     User      │
└───────┬───────┘
        │
        ▼
┌───────────────┐
│   Razor UI    │
└───────┬───────┘
        │
        ▼
┌───────────────┐
│  Controller   │
└───────┬───────┘
        │
        ▼
┌───────────────┐
│     Model     │
└───────┬───────┘
        │
        ▼
┌───────────────┐
│    EF Core    │
└───────┬───────┘
        │
        ▼
┌───────────────┐
│   Database    │
└───────────────┘
```

---

# 📌 Project Status

🚧 **Completed Educational Project**

This project was developed to gain practical experience with:

**ASP.NET Core MVC + Entity Framework Core + Database-driven CRUD**

It serves as a foundation for moving toward larger backend systems and more advanced software architecture.

---

# 👨‍💻 Author

**Sobhan Khedry**

GitHub:

https://github.com/Sobhankhedry
