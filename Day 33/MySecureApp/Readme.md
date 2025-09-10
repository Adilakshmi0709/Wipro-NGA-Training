Here’s your document **with all emojis removed** and rephrased to make it plagiarism-free while keeping the structure and meaning intact:

---

# Secure Login & Role-Based Access System

An ASP.NET Core MVC application that implements authentication and role-based authorization for secure access control.

## Features

* Secure login system with password hashing
* Role-based access control (Admin and User roles)
* HTTPS redirection for all requests
* CSRF protection with AntiForgeryToken
* SQL Server database integration using Entity Framework

## Prerequisites

* .NET 6.0 or higher
* SQL Server LocalDB
* Visual Studio or VS Code

## Installation

1. **Download or clone the project**

   ```bash
   git clone <your-repo-url>
   cd MySecureApp
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Create the database and apply migrations**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the application**

   ```bash
   dotnet run
   ```

5. **Open in browser**

   * Navigate to: `https://localhost:7000` or `http://localhost:5000`

## Default User Accounts

### Administrator

* **Username:** `admin`
* **Password:** `Admin@123`
* **Access:** Admin Dashboard + User Profile

### Standard User

* **Username:** `user1`
* **Password:** `User@123`
* **Access:** User Profile only

## Project Structure

```
MySecureApp/
├── Controllers/
│   ├── AccountController.cs   // Login & Logout
│   ├── AdminController.cs     // Admin-only features
│   └── UserController.cs      // User profile
├── Models/
│   ├── ApplicationUser.cs     // Custom user model
│   └── DbInitializer.cs       // Database seed logic
├── Views/
│   ├── Account/Login.cshtml   // Login page
│   ├── Admin/Dashboard.cshtml // Admin dashboard
│   └── User/Profile.cshtml    // User profile page
├── Data/
│   └── ApplicationDbContext.cs // EF Core DB context
└── Program.cs                 // Application entry point
```

## Security Features

* Password hashing via ASP.NET Identity
* Role-based authorization with `[Authorize(Roles = "Admin")]`
* Enforced HTTPS redirection
* Anti-forgery token validation for all forms
* Secure cookie management
* Protection against SQL injection through Entity Framework

## Pages and Access

### Public Pages

* `/Home/Index` – Home page
* `/Account/Login` – Login page

### Protected Pages

* `/Admin/Dashboard` – Accessible only by administrators (includes user management)
* `/User/Profile` – Accessible by any authenticated user

## Database Details

* **Type:** SQL Server LocalDB
* **Instance:** `(localdb)\mssqllocaldb`
* **Name:** `MySecureAppDb`
* **Auto-created:** Yes, on first run

### Tables

* `AspNetUsers` – Stores user accounts
* `AspNetRoles` – Stores roles
* `AspNetUserRoles` – Links users to roles
* `AspNetLogins` – Tracks login data

## Testing Instructions

1. **Admin Login**

   * Go to `/Account/Login`
   * Credentials: `admin` / `Admin@123`
   * Redirects to `/Admin/Dashboard`
   * Access to both Admin and User sections

2. **User Login**

   * Credentials: `user1` / `User@123`
   * Redirects to `/User/Profile`
   * Access denied for `/Admin/Dashboard`

3. **Security Validation**

   * Try accessing `/Admin/Dashboard` without login → redirected to login page
   * Try as a user → shows "Access Denied"

## Configuration

### Database Connection (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MySecureAppDb;Trusted_Connection=true;"
  }
}
```

### HTTPS Setup (Program.cs)

```csharp
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});
```

## Troubleshooting

### Common Issues

1. **Connection refused**

   * Ensure the app is running (`dotnet run`)
   * Try alternate ports: `https://localhost:7000` or `http://localhost:5000`

2. **Database not created**

   ```bash
   dotnet ef database update
   ```

3. **Build errors**

   ```bash
   dotnet clean
   dotnet build
   ```

4. **Database not visible in SQL Server**

   * Connect using `(localdb)\mssqllocaldb`
   * Database name: `MySecureAppDb`

## License

This project is intended for learning purposes as part of ASP.NET Core security practice.

## Support

If you face issues:

1. Review the troubleshooting section
2. Confirm all prerequisites are installed
3. Reapply migrations if necessary

---
An ASP.NET Core MVC application that implements authentication and role-based authorization for secure access control. This guide is supported with screenshots for better understanding.


Built with ASP.NET Core MVC and Identity Framework.

