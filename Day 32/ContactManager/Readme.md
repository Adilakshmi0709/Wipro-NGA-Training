<!-- # 📞 Contact Manager


Deep Seek Used here 


https://chat.deepseek.com/a/chat/s/7e4843fe-f1d2-4030-8854-2d6d23f27939

A secure ASP.NET Core web application for managing contacts with role-based authorization and user authentication.

## 🚀 Features

- **🔐 User Authentication** - Register and login system
- **👥 Role-Based Authorization** - Three security levels:
  - **Users** - Can view approved contacts and manage their own
  - **Managers** - Can approve/reject contact submissions
  - **Administrators** - Full control over all contacts
- **📊 Contact Management** - Create, read, update, and delete contacts
- **🛡️ Data Security** - Users can only access their own data
- **💾 SQL Server Database** - Local database storage

## 🏗️ Technology Stack

- **ASP.NET Core 6.0**
- **Entity Framework Core**
- **SQL Server / LocalDB**
- **Bootstrap 5** - Modern UI styling
- **FontAwesome** - Icons
- **ASP.NET Core Identity** - Authentication & Authorization

## 📦 Installation

1. **Clone or download the project**
   ```bash
   git clone <your-repo-url>
   cd ContactManager
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Setup database**
   ```bash
   dotnet ef database update
   ```

4. **Set up secret password** (for seed data)
   ```bash
   dotnet user-secrets set SeedUserPW "YourStrongPassword123!"
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

## 👤 Default Test Accounts

The application comes with pre-configured test accounts:

| Email | Password | Role | Permissions |
|-------|----------|------|-------------|
| `admin@contoso.com` | Your set password | Administrator | Full access - approve/reject, edit/delete all contacts |
| `manager@contoso.com` | Your set password | Manager | Can approve/reject contacts |
| (Any registered user) | User-chosen password | User | View approved contacts, manage own contacts |

## 🎯 How to Use

1. **Register** a new account or use the test accounts
2. **Login** with your credentials
3. **Navigate** to "Contacts" in the navigation menu
4. **Create** new contacts (will be in "Submitted" status initially)
5. **Managers/Admins** can approve/reject contacts in the details view
6. **Users** can only edit/delete their own contacts

## 📁 Project Structure

```
ContactManager/
├── Pages/
│   ├── Contacts/          # Contact management pages
│   │   ├── Index.cshtml   # Contact list
│   │   ├── Create.cshtml  # Add new contact
│   │   ├── Edit.cshtml    # Edit contact
│   │   ├── Delete.cshtml  # Delete contact
│   │   └── Details.cshtml # View contact details
│   ├── Account/           # Authentication pages
│   └── Shared/            # Layout and partial views
├── Models/
│   └── Contact.cs         # Contact data model
├── Authorization/         # Custom authorization handlers
├── Data/
│   ├── ApplicationDbContext.cs # Database context
│   └── SeedData.cs        # Test data initialization
└── wwwroot/
    └── css/
        └── site.css       # Custom styling
```

## 🔧 Customization

### Modify UI Styling
Edit `wwwroot/css/site.css` for custom styles
Edit `Pages/Shared/_Layout.cshtml` for layout changes

### Add New Roles
Update the `Constants` class in `Authorization/ContactOperations.cs`

### Modify Contact Fields
Edit `Models/Contact.cs` and create new migration:
```bash
dotnet ef migrations add UpdateContactModel
dotnet ef database update
```

## 🛠️ Development

### Create New Migration
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Run in Development Mode
```bash
dotnet watch run
```

### Build for Production
```bash
dotnet publish -c Release
```

## 📋 Contact Status Types

- **Submitted** - Waiting for manager approval
- **Approved** - Visible to all users
- **Rejected** - Not visible to regular users

## 🔒 Security Features

- Password hashing and salting
- CSRF protection
- XSS prevention
- SQL injection protection
- Role-based access control
- User-specific data isolation

## 🌟 Future Enhancements

- [ ] Contact import/export functionality
- [ ] Contact categories/tags
- [ ] Advanced search and filtering
- [ ] Contact sharing between users
- [ ] API endpoints for mobile access
- [ ] Email notifications for status changes

## 📝 License

This project is created for educational purposes as part of ASP.NET Core learning.

## 🆘 Support

If you encounter any issues:
1. Check that the database is properly migrated
2. Verify the secret password is set correctly
3. Ensure all NuGet packages are restored

---
ID : admin@contoso.com
PAssword For Admin : AdminPassword123!



**Happy Coding!** 🎉 -->