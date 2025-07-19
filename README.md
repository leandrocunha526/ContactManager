# ContactManager

ASP.NET Core MVC web application for contact management with cookie authentication.

---

## Technologies

- ASP.NET Core 9  
- Entity Framework Core with MySQL/MariaDB  
- Cookie Authentication  
- Bootstrap for UI  

---

## Considerations

"Deleted" contacts are marked with IsDeleted = true and can be viewed and restored via the interface.

Authentication protects contact creation, editing, and deletion operations.

Index is accessible to anonymous users.

Other resources only for authenticated users.

NOTE: The current version of Dotnet is recommended on the official Microsoft website (for Debian, for example, and there are no previous versions available to install in the distribution according to the official Microsoft website) and version 9 is provided by the current Visual Studio installation.
All necessary validations have been implemented, and remote database access information has been removed for security reasons. The configuration is now ready for localhost connection, and the application has been tested on both, showing compliance.

## Setup

1. Clone the repository.

2. Run: `dotnet ef database update` to synchronize with the database.

Don't forget to enter the correct password for your MariaDB/MySQL database in `appsettings.json`.

```json
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=contactmanagerdb;user=root;password=password"
  },
```

If you do not run the above command, the code below runs the migration(s):

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();

    dbContext.Database.Migrate();
}
```

Execute with `dotnet run` or `dotnet watch run` (hot reload).

Execute Docker with `docker-compose up --build` to run the application in a container.

In Docker, the application will be available at `http://localhost:8080` and Adminer at `http://localhost:80` or `http://localhost`.

## Authentication

- Email: <admin@email.com>  
- Password: 123456

Fixed user administrator.

**The project is following the instructions sent by email.**
