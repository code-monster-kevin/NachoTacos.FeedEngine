# Setup Hangfire
To schedule background jobs

## Add Packages
1. Hangfire


## Startup.cs
1. Add the following code in ConfigureServices
```
services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("FeedEngineConnection")));
services.AddHangfireServer();
```

2. Add the following code in Configure
```
app.UseHangfireDashboard();
```