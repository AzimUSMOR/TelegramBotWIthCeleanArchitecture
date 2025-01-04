# Telegram Bot with clean architecture

This project was created to showcase what a project looks like from the perspective of our programming department, specifically as envisioned by my mentor, Absatar uulu Myktibek.

---

## **Table of Contents**
- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

---

## **Overview**

This project is designed to demonstrate a high-quality software application adhering to the principles of software craftsmanship. It incorporates modern development techniques, ensures scalability, and provides a clean structure for enterprise-level development.

---

## **Features**

- **SOLID Principles**: A clean, maintainable, and scalable codebase.
- **Domain-Driven Design (DDD)**: Focuses on organizing business logic effectively.
- **Entity Framework Core**: Database abstraction for seamless interaction with MS SQL and MySQL.
- **RESTful API**: Exposes application functionality through a robust API interface.
- **AutoMapper**: Simplifies the mapping between domain models and Data Transfer Objects (DTOs).
- **Swagger**: Provides interactive API documentation for developers.
- **Dependency Injection**: Powered by `Microsoft.Extensions.DependencyInjection`.
- **Unit Testing**: Ensures code reliability and consistency through comprehensive test coverage.

---

## **Technologies Used**

### **Core Technologies**
- **C#**: The primary programming language.
- **.NET**: The framework used for building the application.

### **Design and Architectural Patterns**
- **SOLID Principles**:
  - Single Responsibility Principle
  - Open-Closed Principle
  - Liskov Substitution Principle
  - Interface Segregation Principle
  - Dependency Inversion Principle
- **Domain-Driven Design (DDD)**:
  - Focus on entities, aggregates, and value objects.
  - Separation of concerns with Application, Domain, and Infrastructure layers.

### **Database**
- **Entity Framework Core**:
  - Code-first migrations for schema evolution.
  - Supports both MS SQL and MySQL.

### **API Design**
- **REST API**:
  - Adheres to RESTful principles for clean, stateless communication.
  - Fully documented using Swagger.

### **Other Tools and Libraries**
- **AutoMapper**: To map domain models to DTOs and vice versa.
- **Swagger/OpenAPI**: Interactive API documentation for easy testing and exploration.
- **Microsoft.Extensions.DependencyInjection**: Built-in dependency injection for decoupled components.
- **xUnit/NUnit/MSTest**: Unit testing frameworks for ensuring code reliability.

---

## **Architecture**

The project follows a clean and modular architecture based on Domain-Driven Design (DDD):

- **Application Layer**: Handles use cases and orchestrates domain operations.
- **Domain Layer**: Contains business logic, entities, and value objects.
- **Infrastructure Layer**: Manages database interactions, repositories, and external services.
- **API Layer**: Exposes application functionality via REST endpoints.

---

## **Setup and Installation**

### Prerequisites
- .NET 6 SDK or higher
- MS SQL Server or MySQL
- Visual Studio or any preferred IDE

### Installation Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/project-name.git