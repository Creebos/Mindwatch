# Architecture Overview

## .NET Core Web Backend API

Due to the pre-existing knowledge of C# and the .NET Core Framework, this projects backend will be implemented with such. I have minimal experience in setting up a Project from scratch and designing a clean architecture. Therefore it is expected that there will be some design flaws.

This project follows the Onion Architecture (also known as Clean Architecture) to ensure a clean, scalable, and maintainable codebase. The main goal of this architecture is to create a decoupled system that promotes separation of concerns, where the core logic is independent of external frameworks and technologies, such as databases or third-party APIs.

### Project Structure

- **KR.Hanyang.Mindwatch.Api**: The API layer handles HTTP requests and routes them to the appropriate application services.

- **KR.Hanyang.Mindwatch.Application**: Contains business logic, service interfaces, and orchestrates use cases. It interacts with both the Domain and Infrastructure layers.

- **KR.Hanyang.Mindwatch.Domain**: The core layer defining business entities and rules, free from any dependencies on external systems.

- **KR.Hanyang.Mindwatch.Infrastructure.Persistence**: Implements repository interfaces from the Domain layer and handles data persistence using Entity Framework Core.

- **docker-compose**: Contains Docker configurations for containerizing and running the application.

## Vue 3 Frontend

---

# Notes on encountered Problems:

- Docker setup with Vuejs changes applying instantly with vite
- Setup with OIDC and Github as Authentication (invested 2 hours so far)
- API to Db Connection (connectionstring network name instead of localhost lol)
