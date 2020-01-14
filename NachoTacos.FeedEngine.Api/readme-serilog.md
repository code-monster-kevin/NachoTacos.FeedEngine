# Setup Serilog
This setup is to save logs to file

## Add Packages
1. Serilog.AspNetCore
2. Serilog.Sinks.File

## Program.cs
Add the following code in the Main function
```
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
```

Add the service in Host.CreateDefaultBuilder

```
...
.UseSerilog()
...
```
## Configure Serilog settings
From appsettings.json, add the following configuration settings
```
"Serilog": {    
    "Using": [ "Serilog.Sinks.File" ],
    "MinimumLevel": "Debug",
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": "logs\\log-.txt",
          "rollingInterval": "Day"
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ]
  }
```

## Startup.cs
1. Add the following code in ConfigureServices
```
services.AddLogging();
```