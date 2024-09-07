# Practice 4
Topics worked:
- LINQ
- SQL
## Don't forget to include `appsettings.json` in the bin/Debug/net8.x with the proper ConnectionString
Example configuration with Trust Server Auth enabled, no username and passwd running on local
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDatabaseName;TrustServerCertificate=True; Integrated Security=True;"
  }
}