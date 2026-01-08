# JiraLike Backend API

This is the backend API for a Jira-like issue tracking system, built using ASP.NET Core.
The project is designed to practice and demonstrate clean backend architecture, API design, and real-world development patterns.

---

## Overview

The application provides backend services for managing users, projects, and issues.
It follows Clean Architecture principles to keep business logic separate from infrastructure and framework-specific code.

The focus of this project is backend structure, maintainability, and clarity rather than feature completeness.

---

## Architecture

The solution follows a layered Clean Architecture approach.

JiraLikeBE
- JiraLike.Api
- JiraLike.Application
- JiraLike.Application.Abstraction
- JiraLike.Domain
- JiraLike.Infrastructure
- JiraLike.sln

### Layer Responsibilities

**Domain**
- Core business entities
- Domain rules and validations
- No dependency on external libraries or frameworks

**Application**
- Use cases and business logic
- Command and Query handlers (CQRS)
- DTOs and application-level rules

**Application.Abstraction**
- Interfaces for repositories and services
- Contracts used by the Application layer

**Infrastructure**
- Entity Framework Core implementation
- Database context and repository implementations
- External integrations

**API**
- REST endpoints
- Controllers and middleware
- Dependency injection and application configuration

---

## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Clean Architecture
- CQRS pattern
- Dependency Injection

---

## Features

Currently implemented or planned features include:

- User management
- Project management
- Issue / ticket management
- Issue status workflow (To Do, In Progress, Done)
- Role-based authorization
- JWT-based authentication
- Global exception handling
- Logging support

Some features are still under development and will be added incrementally.

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
