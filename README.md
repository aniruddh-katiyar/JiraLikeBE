# JiraLike Project Management Backend API

This repository contains the backend API for a **project management system** built using **ASP.NET Core**.

The project is created to practice and demonstrate **clean backend architecture**, **API design**, and **real-world backend development patterns** commonly used in enterprise applications.

The primary focus is on **code structure, maintainability, and clarity**, rather than UI or feature completeness.

---

## Overview

The application provides backend services for managing:

- Users
- Projects
- Project members
- Tasks within projects
- Task status and workflow

The system is designed using **Clean Architecture principles**, keeping business logic independent from frameworks and infrastructure concerns.  
This helps ensure the codebase remains easy to understand, test, and extend over time.

---

## Architecture

The solution follows a layered Clean Architecture approach.

JiraLikeBE
- JiraLike.Api
- JiraLike.Application
- JiraLike.Domain
- JiraLike.Infrastructure
- JiraLike.sln


---

## Layer Responsibilities

### Domain
- Core business entities such as User, Project, Task, and related models
- Domain rules and invariants
- No dependency on ASP.NET Core, Entity Framework, or external libraries

### Application
- Application use cases
- CQRS command and query handlers
- Request and response DTOs
- Orchestrates domain logic and persistence

### Infrastructure
- Entity Framework Core implementation
- Database context and migrations
- Repository implementations
- Authentication, persistence, and external integrations

### API
- REST endpoints (controllers)
- Middleware and filters
- Dependency injection configuration
- Request handling and response mapping

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

### Implemented / In Progress

- User management
- Project creation and management
- Project member assignment
- Task management within projects
- Task status workflow (To Do, In Progress, Done)
- JWT-based authentication
- Role-based authorization (in progress)
- Global exception handling
- Logging support

Features are implemented **incrementally**, with a strong focus on correctness and clean design.

---
