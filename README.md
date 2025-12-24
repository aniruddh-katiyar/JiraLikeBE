# JiraLike Backend API

A Jira-like issue tracking backend application built using **ASP.NET Core** following **Clean Architecture** principles.  
This project is created to demonstrate enterprise-level backend development, clean code practices, and scalable architecture.

---

## Overview

This project aims to build a simplified Jira-like backend system where users can manage projects and track issues (tickets).

The application is structured using **Clean Architecture**, ensuring:
- Clear separation of concerns
- High maintainability
- Easy testing
- Independence from frameworks and infrastructure

---

## Architecture

The solution follows **Clean Architecture** and is divided into the following layers:

JiraLikeBE/
├─ JiraLike.Api/
├─ JiraLike.Application/
├─ JiraLike.Application.Abstraction/
├─ JiraLike.Domain/
├─ JiraLike.Infrastructure/
├─ JiraLike.sln
└─ README.md


### Layer Responsibilities

- **Domain**
  - Core business entities
  - Domain rules and validations
  - No dependency on external frameworks

- **Application**
  - Business use cases
  - CQRS (Commands & Queries)
  - DTOs and application-level logic

- **Application.Abstraction**
  - Interfaces for repositories and services
  - Contracts used by the Application layer

- **Infrastructure**
  - Entity Framework Core
  - Database context and migrations
  - Repository implementations

- **API**
  - RESTful endpoints
  - Controllers and middleware
  - Dependency injection and configuration

---

## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Clean Architecture
- CQRS Pattern
- Dependency Injection

---

## Features

### Implemented / Planned

- User Management
- Project Management
- Issue / Ticket Management
- Issue Status Workflow (To Do, In Progress, Done)
- Comments on Issues
- Role-Based Authorization
- JWT Authentication
- Pagination & Filtering
- Global Exception Handling
- Logging and Auditing

---

## How to Run the Project

### Prerequisites
- .NET SDK (Latest LTS)
- SQL Server
- Visual Studio or VS Code

### Steps

1. Clone the repository
   ```bash
   git clone https://github.com/aniruddh-katiyar/JiraLikeBE.git

1. Clone the repository
   ```bash
   git clone https://github.com/aniruddh-katiyar/JiraLikeBE.git
   
2. Open the solution file
    JiraLike.sln
   
4. Update the connection string in appsettings.json
5. Apply database migrations (when added)

6. dotnet ef database update

7. Run the application
   dotnet run

**Future Enhancements**
1. Unit and Integration Testing
2. Swagger API Documentation
3. Redis Caching
4. Docker Support
5. CI/CD Pipeline
6. Microservices-based scaling
