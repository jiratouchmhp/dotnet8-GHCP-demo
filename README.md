# .NET 8 Clean Architecture Backend with GitHub Copilot Demo

This project demonstrates a .NET 8 Web API implementation following Clean Architecture principles, integrated with MCP for direct PostgreSQL access and GitHub Copilot for enhanced development experience.

## 🚀 Project Overview

This backend application is built with:
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core with PostgreSQL
- Clean Architecture
- MediatR for CQRS
- FluentValidation
- Mapster
- OpenTelemetry
- Structured Logging (Serilog)
- xUnit for testing
- MCP Server for PostgreSQL access

## 🛠 Prerequisites

- .NET 8 SDK
- Visual Studio Code
- Docker Desktop
- MCP CLI tool
- GitHub Copilot extension
- Git

## 📦 Getting Started

1. Clone the repository:
```bash
git clone <your-repository-url>
cd Backend
```

2. Start PostgreSQL using Docker:
```bash
docker-compose up -d
```

3. Start MCP server:
```bash
mcp start
```

4. Restore dependencies:
```bash
dotnet restore
```

5. Apply database migrations:
```bash
dotnet ef database update
```

6. Run the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5001`

## 🧪 Running Tests

Execute tests using:
```bash
dotnet test
```

## 🤖 GitHub Copilot Integration Guide

### Setting Up GitHub Copilot

1. Install GitHub Copilot in VS Code:
   - Open VS Code
   - Go to Extensions (Ctrl+Shift+X)
   - Search for "GitHub Copilot"
   - Click Install

2. Authenticate with GitHub:
   - After installation, click on the GitHub Copilot icon in the status bar
   - Follow the authentication prompts

### Using Custom Instructions with GitHub Copilot

This project includes custom instructions for GitHub Copilot to ensure consistent code generation following our architecture patterns.

#### Key Custom Instruction Areas:

1. **Architecture Standards**
   - Clean Architecture implementation
   - SOLID principles adherence
   - Domain-Driven Design practices

2. **Code Organization**
   ```
   Backend/
   ├── Controllers/
   ├── Models/
   ├── Dtos/
   ├── Repository/
   ├── DbContext/
   ├── Services/
   ├── Validators/
   └── Tests/
   ```

3. **Best Practices**
   - Input validation using FluentValidation
   - OpenTelemetry integration
   - Structured logging with Serilog
   - Unit testing requirements
   - Dependency injection patterns

### 💡 Copilot Usage Tips

1. **Generate Controllers**
   - Type `// ProductsController` and let Copilot suggest the implementation
   - Copilot will follow the project's CQRS pattern

2. **Create DTOs**
   - Start with `public record ProductDto` and Copilot will suggest properties
   - Copilot maintains naming conventions

3. **Repository Implementation**
   - Type `// IProductRepository interface` for interface suggestions
   - Implementation will include proper OpenTelemetry tracing

4. **Unit Tests**
   - Start with `[Fact]` and let Copilot suggest test cases
   - Follows project's testing patterns with xUnit

### 🔍 Validation

1. **Architecture Compliance**
   - Copilot suggestions maintain separation of concerns
   - Proper dependency injection patterns
   - Clean Architecture layer separation

2. **Code Quality**
   - Maintains consistent naming conventions
   - Includes required logging and tracing
   - Proper exception handling

## 📊 Observability & Monitoring
### OpenTelemetry Integration
1. **Tracing Setup**:
```csharp
services.AddOpenTelemetry()
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation()
        .AddEntityFrameworkCoreInstrumentation()
        .AddNpgsql()
        .AddOtlpExporter());
```

2. **Key Metrics**:
- HTTP request durations
- Database query performance
- Endpoint response times
- Error rates and types

3. **Custom Activity Sources**:
- Service layer operations
- Repository operations
- Business logic execution

### Structured Logging with Serilog
1. **Log Categories**:
- Information: Standard operation logs
- Warning: Potential issues
- Error: Exception details
- Debug: Development information

2. **Context Enrichment**:
- Correlation IDs
- User information
- Request details
- Performance metrics

## 🔐 Validation & Security
### FluentValidation Implementation
1. **Request Validation**:
```csharp
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}
```

2. **Validation Pipeline**:
- Automatic validation triggering
- Custom error responses
- Localized error messages

### API Security
1. **Input Sanitization**:
- Request validation
- Content-type validation
- File upload restrictions

2. **Authentication & Authorization**:
- JWT token validation
- Role-based access control
- API key authentication

## 🐘 PostgreSQL & MCP Integration

### MCP Server Setup

1. Configure MCP (.vscode/mcp.json):
```json
{
  "servers": {
    "postgres": {
      "command": "docker",
      "args": [
        "run",
        "-i",
        "--rm",
        "--network=host",
        "mcp/postgres",
        "postgresql://postgres:postgres123@localhost:5432/backenddb"
      ]
    }
  }
}
```

2. Start MCP server:

3. Connect to PostgreSQL through MCP:

### Using MCP for Database Operations

1. Execute read-only queries:
```sql
-- Example: List all products with their categories
SELECT p.*, c.Name as CategoryName 
FROM Products p 
JOIN Categories c ON p.CategoryId = c.Id;
```

2. Monitor database activity:
```bash
mcp logs postgres
```

### Best Practices for MCP Usage

1. **Query Guidelines**:
   - Use read-only queries for data retrieval
   - Implement proper indexing
   - Follow SQL optimization practices

2. **Security**:
   - Never expose sensitive data in queries
   - Use parameterized queries when possible
   - Follow least privilege principle

3. **Performance**:
   - Keep queries focused and specific
   - Use appropriate WHERE clauses
   - Optimize JOIN operations

## 🖥️ MCP Server Configuration
### Setup and Configuration
1. **MCP Server Configuration** (.vscode/mcp.json):
```json
{
  "servers": {
    "postgres": {
      "command": "docker",
      "args": [
        "run",
        "-i",
        "--rm",
        "--network=host",
        "mcp/postgres",
        "postgresql://{username}:{password}@localhost:5432/{dbname}"
      ]
    }
  }
}
```

### Key Features
- **Containerized PostgreSQL**: Runs in Docker for consistency across environments
- **Network Host Mode**: Direct communication between application and database
- **Automatic Database Provisioning**: Database is created if it doesn't exist

### Development Workflow
1. Start the MCP server:
```bash
mcp start
```

2. Access PostgreSQL through the MCP server:
```bash
mcp connect postgres
```

3. Monitor database logs:
```bash
mcp logs postgres
```

## 🔍 MCP Server Integration
### Query Capabilities
MCP server provides read-only SQL query functionality that allows you to:
- Execute read-only queries against the database
- View query results in a structured format
- Analyze database structure and schema

### Using MCP for Queries
To execute read-only queries:
```sql
-- Example of a read-only query
SELECT * FROM Products WHERE CategoryId = 1;
```

### Best Practices for MCP Queries
1. **Query Optimization**:
   - Write efficient SELECT statements
   - Use appropriate indexing in queries
   - Limit result sets when possible

2. **Security**:
   - Use parameterized queries
   - Follow principle of least privilege
   - Avoid exposing sensitive data in queries

3. **Performance**:
   - Keep queries focused and specific
   - Use appropriate WHERE clauses
   - Optimize JOIN operations

### GitHub Copilot Integration with MCP
GitHub Copilot enhances development with MCP server by:
- Suggesting database queries optimized for PostgreSQL
- Generating Entity Framework configurations
- Providing migration scripts
- Assisting with Docker configurations

### Best Practices
1. **Database Management**:
   - Use migrations for schema changes
   - Follow naming conventions for database objects
   - Implement proper indexing strategies

2. **Security**:
   - Store credentials in user secrets or environment variables
   - Use connection string encryption
   - Implement proper database user permissions

3. **Performance**:
   - Enable connection pooling
   - Use appropriate transaction isolation levels
   - Implement query optimization

## 🚀 API Endpoints
### Products
- GET `/api/products` - List all products
- GET `/api/products/{id}` - Get product by ID
- POST `/api/products` - Create new product
- PUT `/api/products/{id}` - Update product
- DELETE `/api/products/{id}` - Delete product

### Categories
- GET `/api/categories` - List all categories
- GET `/api/categories/{id}` - Get category by ID
- POST `/api/categories` - Create new category
- PUT `/api/categories/{id}` - Update category
- DELETE `/api/categories/{id}` - Delete category

## 🏗 Project Structure

The project follows Clean Architecture with these key components:

- **Controllers**: API endpoints
- **Models**: Domain entities
- **DTOs**: Data transfer objects
- **Repository**: Data access layer
- **Services**: Business logic
- **Validators**: Request validation
- **Tests**: Unit and integration tests

## 📚 Additional Resources

- [Clean Architecture Documentation](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
