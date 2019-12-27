# Packages for this project
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools

# Add Reference to Project
1. NachoTacos.FeedEngine.Domain


# Create the migration script and database objects
## From the API Project
1. Add reference to NachoTacos.FeedEngine.Domain & NachoTacos.FeedEngine.Data
2. Add package Microsoft.EntityFrameworkCore.Design
3. At the Startup.cs ConfigureServices function, add the following code:
```
NachoTacos.FeedEngine.Data.Startup.ConfigureServices(services, Configuration.GetConnectionString("FeedEngineConnection"));
```

## From Package Manager Console
Make sure the default project is pointing to NachoTacos.FeedEngine.Data
```
> add-migration data-model-001
> update-database
```

