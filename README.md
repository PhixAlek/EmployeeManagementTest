
# Employee Management Test - ASP.NET MVC

> A technical assessment solution developed in **ASP.NET Core MVC (.NET 8)** to demonstrate clean software architecture, SOLID principles, and pragmatic coding for scalable enterprise applications.

---

## 🧭 Overview

This project is a technical test designed to consume external REST APIs and present employee information through a web-based MVC application. It is engineered with **clean architecture**, **separation of concerns**, and **best practices** for maintainability and scalability.

---

## 📌 Project Objectives

- Consume the API endpoints:
  - `https://dummy.restapiexample.com/api/v1/employees` (all employees)
  - `https://dummy.restapiexample.com/api/v1/employee/{id}` (single employee)
- Present employee data using:
  - Razor views with search and tabular result display
  - Cleanly separated layers: Presentation, Business, Data Access
- Calculate and display the **Annual Salary**
- Handle not-found or missing employee data
- Apply **SOLID**, **DRY**, **KISS**, and **Separation of Concerns**

---

## 🧱 Project Structure

```
EmployeeManagementTest/
│
├── Controllers/              # Handles routing and request/response logic
│
├── Views/                    # Razor pages for UI interaction (Index, Details, NotFound, AllEmployees)
│
├── Business/
│   ├── Models/               # Core business entities (e.g., Employee)
│   ├── Interfaces/           # Business contracts (IEmployeeService)
│   └── Services/             # Business logic (salary calculation, DTO transformation)
│
├── DataAccess/
│   ├── Dtos/                 # Data Transfer Objects representing API responses
│   ├── Interfaces/           # Abstractions for data access (IEmployeeApiClient)
│   └── Clients/              # API HTTP clients with Polly for retry/resilience
│
├── wwwroot/                  # Static assets (CSS, JS, images)
│
├── Program.cs                # Application startup configuration and middleware
├── appsettings.json          # App configuration file
└── EmployeeManagementTest.sln # Solution file
```

---

## 💡 Key Features

| Feature                             | Description |
|------------------------------------|-------------|
| 🔍 Search Employee by ID           | Via input box on the homepage (`/`) |
| 📋 List All Employees              | Accessed via `/employees`, includes calculated annual salary |
| ⚠️ Not Found View                  | Gracefully handles missing or invalid employee IDs |
| ♻️ Retry HTTP Policies             | Built-in retry logic with Polly to handle transient API failures |
| 🎯 Clean Routing                   | RESTful, human-readable routes |
| 💡 Computed Business Logic         | Annual salary calculated dynamically in the model |

---

## 📐 Principles & Practices Applied

- **SOLID Principles**  
  - **S**: Each class has a single responsibility  
  - **O**: API Clients and Services are open for extension  
  - **L**: Interfaces abstract dependencies  
  - **I**: Fine-grained interfaces (`IEmployeeService`, `IEmployeeApiClient`)  
  - **D**: Dependency injection used throughout

- **Clean Code & Architecture**  
  - Descriptive class and method names  
  - DTO → Domain model transformation to decouple layers  
  - View logic separated from controller logic  
  - UI structured in modular Razor Views

- **Resilience with Polly**  
  - Retry policy with exponential backoff for API rate limits and outages

---

## 🚀 How to Run

### Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or Visual Studio Code

### Steps

```bash
git clone https://github.com/PhixAlek/EmployeeManagementTest.git
cd EmployeeManagementTest
dotnet restore
dotnet run
```

### 3. Open browser at:
```
https://localhost:7138/
```

---

## 🧹 Clean-Up / Removed Default Template Files

To maintain focus and clarity, the following default scaffolding files were removed:

- `Views/Home/Privacy.cshtml`
- `Views/Shared/Error.cshtml`
- `Views/Shared/_ValidationScriptsPartial.cshtml`
- Default `WeatherForecast` models and controllers

---

## 🧪 Optional Extension

This project is ready for unit testing. Suggested next step:

- Create a `Tests` project
- Add a unit test for `Employee.EmployeeAnnualSalary` logic
- Use **xUnit**, **MSTest**, or **NUnit**

---

## ✅ Project Status

| Status         | Detail                                     |
|----------------|--------------------------------------------|
| ✔️ Functional   | Fully implemented, working as expected     |
| ✔️ Clean        | SOLID principles and Clean Code applied    |
| ✔️ Ready        | Meets technical test specifications        |
| ✔️ Scalable     | Easily extendable and maintainable         |

---

## 📅 Date

**2025-04-10**
