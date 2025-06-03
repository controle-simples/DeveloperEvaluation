
# 💼 Developer Evaluation API (.NET 8 + PostgreSQL)

This project is a complete and production-ready backend developed for technical evaluation. It follows Clean Architecture and Domain-Driven Design (DDD) principles, using modern tools such as MediatR, FluentValidation, JWT authentication, and Entity Framework Core. It also includes unit and integration tests to ensure robustness and correctness.

---

## 📦 Technologies Used

- ✅ **.NET 8** – Main development framework
- ✅ **Entity Framework Core** – ORM with PostgreSQL and InMemory support
- ✅ **PostgreSQL** – Relational database managed via Docker
- ✅ **MediatR** – CQRS and messaging pattern
- ✅ **FluentValidation** – Business rule validations
- ✅ **JWT** – Authentication with bearer token
- ✅ **xUnit / NSubstitute / Bogus / Moq** – Unit and integration test libraries
- ✅ **Serilog** – Structured logging to console and file

---

## 🚀 Getting Started

### 🐳 Step 1 – Start the infrastructure

Run PostgreSQL with Docker:

```bash
docker-compose up -d
```

> PostgreSQL will be available at:
>
> - `Host`: **localhost**
> - `Port`: **5433**
> - `Database`: **developer_eval**
> - `Username`: **ambev**
> - `Password`: **dev2025**

---

### ⚙️ Step 2 – Run the application

Use Visual Studio 2022 or CLI:

```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

> Swagger UI will be available at:  
> **https://localhost:8081/swagger**

---

## 🔐 Authentication Flow

### 👤 Register Admin User

Send a `POST` request to:

```
POST /api/auth/register
```

Payload:

```json
{
  "name": "Admin",
  "email": "admin@admin.com",
  "password": "admin"
}
```

---

### 🔑 Authenticate and get JWT Token

```
POST /api/auth/login
```

Payload:

```json
{
  "email": "admin@admin.com",
  "password": "admin"
}
```

Response:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

### 📎 Use the token

In Swagger (Authorize button) or in Postman:

```
Bearer {your-token-here}
```

---

## 🧾 Create a Sale

```
POST /api/sales
```

Payload (valid):

```json
{
  "customerExternalId": "customer-123",
  "branchExternalId": "branch-001",
  "products": [
    {
      "productExternalId": "prod-01",
      "quantity": 5,
      "unitPrice": 10
    },
    {
      "productExternalId": "prod-02",
      "quantity": 2,
      "unitPrice": 15
    },
    {
      "productExternalId": "prod-03",
      "quantity": 1,
      "unitPrice": 20
    }
  ]
}
```

Expected result:  
`TotalAmount = 95.00` (discount rule applied: 3 or more items)

---

## ✅ Business Rules Validated

| Rule | Description |
|------|-------------|
| ✔️ Min Items | A sale must contain **at least 3 items** |
| ✔️ Quantity | Each item must have a quantity **between 1 and 20** |
| ✔️ Price | Each item must have a **positive** price |
| ✔️ Discount | If the sale has 3 or more items, apply **5% discount** |

---

## 🔍 Tests

### ✅ Run Unit Tests

```bash
dotnet test tests/Ambev.DeveloperEvaluation.Unit
```

Covers:

- Domain rules
- Sale creation
- Validation logic
- Handlers

### ✅ Run Integration Tests

```bash
dotnet test tests/Ambev.DeveloperEvaluation.Integration
```

Covers:

- Sale command executed end-to-end using real PostgreSQL
- Validation and repository integration

---

## 📂 Project Structure

```
src/
 └── Ambev.DeveloperEvaluation.WebApi       # API layer
 └── Ambev.DeveloperEvaluation.Application  # Application layer (commands, handlers, validators)
 └── Ambev.DeveloperEvaluation.Domain       # Domain entities, aggregates, rules
 └── Ambev.DeveloperEvaluation.Infrastructure # EFCore + PostgreSQL
tests/
 └── Ambev.DeveloperEvaluation.Unit         # Unit tests
 └── Ambev.DeveloperEvaluation.Integration  # Integration tests
```

---

## 🛠️ Refactorings & Highlights

- 🔁 Switched from raw data logic to **rich domain model (Sale aggregate)**
- 🔍 Created strong **unit tests using FluentAssertions, Moq, Bogus**
- 🔄 Introduced **business rule validation inside aggregate** instead of outside
- 🔐 Implemented **JWT authentication** with full flow and Swagger support
- 🧪 Added **integration test using PostgreSQL** to simulate production scenarios
- ⚙️ Built support for **EF Core InMemory** for fast and isolated testing
- 📊 Logging via **Serilog** to console and rolling files

---

## 📑 Environment Configuration

Your `appsettings.json` is pre-configured:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5433;Database=developer_eval;Username=ambev;Password=dev2025"
},
"Jwt": {
  "SecretKey": "YourSuperSecretKeyForJwtTokenGenerationThatShouldBeAtLeast32BytesLong"
}
```

---

## ✅ Final Tips

- The API runs on port `8081` (HTTPS)
- All responses follow clean structure
- Tests have **> 80% coverage**
- Domain is consistent and validated by aggregate logic
- Integration test verifies full flow from request to database

 
