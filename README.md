# Dotnet Core API Project

Welcome to the Dotnet Core API project! This repository serves as the foundation for building a robust and scalable API using the .NET Core framework. The project adheres to clean and modular architecture principles, separating concerns for enhanced maintainability.

## Project Structure

The project is organized into various directories to ensure a clear structure and separation of concerns:

- **core-api/Context**: Contains the database context for Entity Framework.
- **core-api/Controllers**: API controllers handling HTTP requests.
- **core-api/Dto**: Data Transfer Objects (DTOs) for seamless data exchange.
- **core-api/Helpers**: Utility classes and helper functions for common tasks.
- **core-api/Models**: Definitions for data models used throughout the application.
- **core-api/Services**: Service interfaces and implementations for business logic.

Additional directories include:

- **core-api/Repositories**: Repository interfaces and implementations for data access.
- **core-api/Migrations**: Database migration scripts for evolving the database schema.
- **core-api/Properties**: Project-related properties and configurations.
- **core-api/Repository**: Deprecated; consider renaming to "Repositories."
- **core-api/Service**: Deprecated; consider renaming to "Services."

## Repository Components

### QuestionRepository

The `QuestionRepository` provides methods to interact with questions in the database, offering functionalities such as retrieval by quiz, by ID, addition, update, and deletion.

### QuizRepository

The `QuizRepository` facilitates operations related to quizzes, including retrieval by category, active quizzes, active quizzes by category, by ID, addition, update, and deletion.

### RoleRepository

The `RoleRepository` handles roles, providing functionalities like role retrieval, addition, update, and deletion.

### UserRepository

The `UserRepository` manages user-related database operations, including retrieval by ID or username, addition, update, and deletion.

## Service Components

The services layer contains implementations for various business logic:

- **CategoryService**: Manages categories, allowing addition, update, and retrieval of categories. It is responsible for handling business logic related to categories.

- **QuestionService**: Handles questions, providing functionalities like addition, update, retrieval, deletion, and retrieving questions associated with a quiz.

- **QuizService**: Manages quizzes, supporting operations such as addition, update, retrieval, deletion, retrieval by category, active quizzes, and active quizzes by category.

- **UserDetailsService**: Provides user-related details, such as loading a user by username. This service is crucial for authentication and user-related operations.

- **UserService**: Implements user-related operations, including user creation and retrieval. It is responsible for creating users, assigning roles, and retrieving user details.

## Controllers

- **AuthService.cs**: Handles authentication-related API endpoints. This includes user authentication and authorization processes.

## Models

The Models directory contains the data models used throughout the application. These models define the structure of your data and are used by the repositories and services.

## Context

The Context directory hosts the database context for Entity Framework. This context manages database connections, schema, and migrations.

## DTOs

The DTOs directory stores Data Transfer Objects used for efficient data exchange between layers:

- **CategoryDto**: Represents category data for communication between services and controllers.

- **QuestionDto**: Represents question data for communication between services and controllers.

- **QuizDto**: Represents quiz data for communication between services and controllers.

- **UserDto**: Represents user data for communication between services and controllers.

## Helpers

The Helpers directory contains utility classes and functions used across the application. These may include common functionalities shared among different parts of the codebase.

## Getting Started

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/your-username/dotnet-core-api.git
   cd dotnet-core-api
   ```

2. **Build and Run:**

   Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.

   ```bash
   dotnet build
   dotnet run
   ```

3. **Explore Endpoints:**

   Open your browser or API testing tool and navigate to `https://localhost:5001` to explore the available API endpoints.
