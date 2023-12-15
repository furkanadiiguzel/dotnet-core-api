# Dotnet Core API Project

Welcome to the Dotnet Core API project! This project is designed to provide a solid foundation for building a modular and scalable API using the .NET Core framework. Below, you'll find an in-depth overview of the project structure, key components, and how to get started.

## Project Structure

The project is organized following a clean and modular architecture, separating concerns between repositories and services.

- **core-api/Repositories**: Contains repository interfaces and implementations for data access.
- **core-api/Services**: Houses service interfaces and their respective implementations.
- **core-api/Services/impl**: Implements the service interfaces.

## Repositories

### QuestionRepository

Handles data access operations for managing questions related to quizzes. Implements the `IQuestionRepository` interface.

#### Methods

- `GetQuestionsByQuizAsync(Quiz quiz)`: Retrieves questions associated with a specific quiz.
- `GetQuestionByIdAsync(long id)`: Retrieves a question by its unique identifier.
- `AddQuestionAsync(Question question)`: Adds a new question to the database.
- `UpdateQuestionAsync(Question question)`: Updates an existing question.
- `DeleteQuestionAsync(long id)`: Deletes a question by its unique identifier.

### QuizRepository

Manages data access operations for quizzes. Implements the `IQuizRepository` interface.

#### Methods

- `GetQuizzesByCategoryAsync(Category category)`: Retrieves quizzes based on a specified category.
- `GetActiveQuizzesAsync()`: Retrieves all active quizzes.
- `GetActiveQuizzesByCategoryAsync(Category category)`: Retrieves active quizzes within a specific category.
- `GetQuizByIdAsync(long id)`: Retrieves a quiz by its unique identifier.
- `AddQuizAsync(Quiz quiz)`: Adds a new quiz to the database.
- `UpdateQuizAsync(Quiz quiz)`: Updates an existing quiz.
- `DeleteQuizAsync(long id)`: Deletes a quiz by its unique identifier.

### RoleRepository

Manages roles within the application, providing CRUD operations for roles. Implements the `IRoleRepository` interface.

#### Methods

- `GetRoleByIdAsync(long id)`: Retrieves a role by its unique identifier.
- `GetAllRolesAsync()`: Retrieves all roles in the system.
- `AddRoleAsync(Role role)`: Adds a new role to the database.
- `UpdateRoleAsync(Role role)`: Updates an existing role.
- `DeleteRoleAsync(long id)`: Deletes a role by its unique identifier.

### UserRepository

Deals with user-related data access operations, including CRUD operations and user retrieval. Implements the `IUserRepository` interface.

#### Methods

- `GetUserByIdAsync(long id)`: Retrieves a user by their unique identifier.
- `GetUserByUsernameAsync(string username)`: Retrieves a user by their username.
- `AddUserAsync(User user)`: Adds a new user to the database.
- `UpdateUserAsync(User user)`: Updates an existing user.
- `DeleteUserAsync(long id)`: Deletes a user by their unique identifier.

## Services

### ICategoryService

Provides services related to category management, such as adding, updating, and deleting categories.

#### Methods

- `AddCategory(Category category)`: Adds a new category.
- `UpdateCategory(Category category)`: Updates an existing category.
- `GetCategories()`: Retrieves all categories.
- `GetCategoryById(long id)`: Retrieves a category by its unique identifier.
- `DeleteCategoryById(long id)`: Deletes a category by its unique identifier.

### IQuestionService

Manages operations related to questions, including adding, updating, and deleting questions.

#### Methods

- `AddQuestion(Question question)`: Adds a new question.
- `UpdateQuestion(Question question)`: Updates an existing question.
- `GetQuestions()`: Retrieves all questions.
- `GetQuestion(long id)`: Retrieves a question by its unique identifier.
- `DeleteQuestionById(long id)`: Deletes a question by its unique identifier.
- `GetQuestionsOfQuiz(Quiz quiz)`: Retrieves all questions associated with a specific quiz.

### IQuizService

Handles quiz-related operations, offering functionalities like adding quizzes, updating, and deleting.

#### Methods

- `AddQuiz(Quiz quiz)`: Adds a new quiz.
- `UpdateQuiz(Quiz quiz)`: Updates an existing quiz.
- `GetQuizzes()`: Retrieves all quizzes.
- `GetQuizById(long id)`: Retrieves a quiz by its unique identifier.
- `DeleteQuizById(long id)`: Deletes a quiz by its unique identifier.
- `GetQuizzesByCategory(Category category)`: Retrieves quizzes based on a specified category.
- `GetActiveQuizzes()`: Retrieves all active quizzes.
- `GetActiveQuizzesOfCategory(Category category)`: Retrieves active quizzes within a specific category.

### IUserDetailsService

Focuses on user details retrieval, particularly loading a user by their username.

#### Methods

- `LoadUserByUsername(string username)`: Loads a user by their username.

### IUserService

Deals with user-related services, including user creation and retrieval.

#### Methods

- `CreateUserAsync(ApplicationUser user, List<string> roles, string password)`: Creates a new user with the specified roles and password.
- `GetUserByUsernameAsync(string username)`: Retrieves a user by their username.

## Service Implementations

### CategoryServiceImpl

Implements the `ICategoryService` interface, providing concrete functionality for category-related operations.

#### Methods

- `AddCategory(Category category)`: Adds a new category.
- `UpdateCategory(Category category)`: Updates an existing category.
- `GetCategories()`: Retrieves all categories.
- `GetCategoryById(long id)`: Retrieves a category by its unique identifier.
- `DeleteCategoryById(long id)`: Deletes a category by its unique identifier.

### QuestionServiceImpl

Implements the `IQuestionService` interface, offering services for managing questions and quizzes.

#### Methods

- `AddQuestion(Question question)`: Adds a new question.
- `UpdateQuestion(Question question)`: Updates an existing question.
- `GetQuestions()`: Retrieves all questions.
- `GetQuestion(long id)`: Retrieves a question by its unique identifier.
- `DeleteQuestionById(long id)`: Deletes a question by its unique identifier.
- `GetQuestionsOfQuiz(Quiz quiz)`: Retrieves all questions associated with a specific quiz.

### QuizServiceImpl

Implements the `IQuizService` interface, providing functionalities for quiz-related operations.

#### Methods

- `AddQuiz(Quiz quiz)`: Adds a new quiz.
- `UpdateQuiz(Quiz quiz)`: Updates an existing quiz.
- `GetQuizzes()`: Retrieves all quizzes.
- `GetQuizById(long id)`: Retrieves a quiz by its unique identifier.
- `DeleteQuizById(long id)`: Deletes a quiz by its unique identifier.
- `GetQuizzesByCategory(Category category)`: Retrieves quizzes based on a specified category.
- `GetActiveQuizzes()`: Retrieves all active quizzes.
- `GetActiveQuizzesOfCategory(Category category)`: Retrieves active quizzes within a specific category.

### UserDetailsServiceImpl

Implements the `IUserDetailsService` interface, focusing on loading user details by username.

#### Methods

- `LoadUserByUsername(string username)`: Loads a user by their username.

### UserServiceImpl

Implements the `IUserService` interface

, offering user-related services such as user creation and retrieval.

#### Methods

- `CreateUserAsync(ApplicationUser user, List<string> roles, string password)`: Creates a new user with the specified roles and password.
- `GetUserByUsernameAsync(string username)`: Retrieves a user by their username.

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
