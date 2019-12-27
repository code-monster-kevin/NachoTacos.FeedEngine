# Setup Swagger
## Add Packages (Core 3.0)
1. Swashbuckle.AspNetCore -Version 5.0.0-rc5 (include pre-release)

## Startup.cs
1. Add the following code in ConfigureServices
```
services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "NachoTacos FeedEngine API", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
```

2. Add the following code in Configure
```
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "NachosTacos FeedEngine API");
    c.RoutePrefix = string.Empty;
});
```

## Enable XML File Documentation
Open the API Project Properties, in the build tab >> output path, enable the XML Documentation checkbox

If you don't want any warnings for documentation, from the project file, add a <NoWarn> tag in the XML documentation property
```
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DocumentationFile>C:\sandbox\NachoTacos.FeedEngine\NachoTacos.FeedEngine.Api\NachoTacos.FeedEngine.Api.xml</DocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
 </PropertyGroup>
```
