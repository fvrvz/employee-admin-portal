# Employee Admin Portal

## Description
This is the backend API for the **Employee Admin Portal** application, developed using **ASP.NET Core 8**. The backend provides basic CRUD operations for managing employee data.

It uses **PostgreSQL** as the database for data storage and **Entity Framework Core** for ORM. This API is accessible via **Swagger UI** for easy testing and viewing of endpoints.

## Features
- 🧑‍💼 Employee management (CRUD operations)
- 🔒 Simple Web API with no authentication or authorization
- 📝 Swagger UI for API testing and documentation
- 🗄️ Uses PostgreSQL for data storage

## Prerequisites

- 🖥️ **.NET 8 SDK** or later
- 🐘 **PostgreSQL** database server
- 📱 **Postman** or any HTTP client for testing endpoints (optional)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/fvrvz/employee-admin-portal.git
cd employee-admin-portal
```

### 2. Set Up PostgreSQL Database

- Install **PostgreSQL** on your machine if you haven't already. You can download it from [here](https://www.postgresql.org/download/).

- Create a new database for the application:

```sql
CREATE DATABASE employee;
```

- Add the connection string to `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Username=your_username;Password=your_password;Database=employee"
}
```

### 3. Install Dependencies

Make sure you have all required dependencies installed. Run:

```bash
dotnet restore
```

### 4. Apply Migrations

You mentioned you used the **NuGet Package Manager Console** to generate the migration, and applied it with `update-database`. Ensure that the migrations are applied correctly by running:

```bash
update-database
```

This will apply the migration to your PostgreSQL database and create the necessary tables.

### 5. Run the Application

To start the backend API, use the following command:

```bash
dotnet run
```

The API should now be running on `http://localhost:5239` (default). You can configure it to run on another port if necessary in `appsettings.json`.

## Swagger UI

Once the API is running, you can test and explore all available API endpoints using **Swagger UI**. Open your browser and navigate to:

[http://localhost:5239/swagger/index.html](http://localhost:5239/swagger/index.html)

Swagger UI will provide interactive documentation for all the endpoints.

## Error Handling

⚠️ Error handling in this application is simple. The API returns appropriate HTTP status codes for each operation (e.g., `200 OK` for successful requests). For any issues, you will typically get responses with standard `IActionResult` methods, such as `Ok()`, `NotFound()`, etc.

## Testing

You can use tools like **Postman** or **curl** to test the API endpoints. Here's an example of how to test the `/api/employees` endpoint using `curl`:

```bash
curl -X GET http://localhost:5239/api/v1/Employees
```

## Contributing

💡 If you'd like to contribute to this project, please fork the repository, make your changes, and create a pull request.

## License

📄 This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

### 📬 Contact Information

**Author**: Faraaz Khan  
**Email**: [codefaraaz@gmail.com](mailto:codefaraaz@gmail.com)  
**GitHub**: [github.com/fvrvz](https://github.com/fvrvz)
