# ZimLabs.NancyFx.RestHelper

This project provides some helper functions for the interaction with the [metadata module package of nancy](https://www.nuget.org/packages/Nancy.Metadata.Modules/).

## Usage

**Installation**
```
PM> Install-Package ZimLabs.NancyFx.RestHelper -Version 1.0.1
```

The RouteDescriptionAttribute is read from the MetadataBase class. The information read out is then linked to the available routes.

### Structure
```
+- Project
|   +- Metadata
|   |   +- MainMetadataModule.cs
|   +- Modules
|       +- MainModule.cs
+- Program.cs
```

### Module class
```csharp
// The main module which provides your end points / modules
public sealed class MainModule : NancyModule
{
    [RouteDescription("RouteName", "Description of the reoute", "Return type")]
    public MainModule()
    {
        Get("/", _ => "Hello World!", name: "RouteName");
    }
}
```

### Metadata module
```csharp
// The meta data class
public sealed class MainMetadataModule : MetadataBase<Modules.MainModule>
{
    // Nothing to do here. Everything is managed by the "MetadataBase"
}
```

### Provide the metadata
```csharp
/// <summary>
/// Represents the documentation route of the REST service
/// </summary>
public sealed class DocsModule : NancyModule
{
    [RouteDescription("main", "Returns this document.", "HTML / JSON according to the given type (optional)")]
    public DocsModule(IRouteCacheProvider cacheProvider) : base("/docs")
    {
        Get("/", _ =>
        {
            var metaData = cacheProvider.GetCache().RetrieveMetadata<CustomMetadata>().Where(w => w != null)
                .ToList();

            return View["info.html", metaData];
        }, name: "main");
    }
}
```

### View
For the view you can use the [Super Simple View Engine](https://github.com/NancyFx/Nancy/wiki/The-Super-Simple-View-Engine) to provide your information as a HTML document.