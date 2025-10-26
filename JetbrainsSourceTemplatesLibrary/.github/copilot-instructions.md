# Copilot Instructions for JetbrainsSourceTemplatesLibrary

## Project Overview
- This is a C#/.NET 9.0 class library providing reusable source templates for JetBrains Rider/Resharper, focused on ASP.NET Core, Entity Framework Core, logging, and collection processing.
- Templates are implemented as static extension methods, decorated with `[SourceTemplate]` and `[Macro]` attributes for IDE integration.
- The library is intended to accelerate common patterns in .NET web and data projects, especially for rapid prototyping and consistent code generation.

## Key Components
- **CollectionTemplates.cs**: Iteration and index-aware collection processing templates using Spectre.Console for output.
- **EntityFrameworkCoreTemplates.cs**: Templates for configuring EF Core `DbContext` with SQL Server and file-based logging (uses `EntityCoreFileLogger`).
- **LoggingTemplates.cs**: Templates for configuring Serilog for both development (console) and production (file) environments.
- **CommonTemplates.cs**: Miscellaneous helpers, e.g., connection string retrieval, JSON serialization.
- **Stubs/Context.cs**: Minimal stub for `DbContext` to support template code.
- **GlobalUsings.cs**: Project-wide global usings for JetBrains.Annotations and Spectre.Console.

## Build & Usage
- Build with standard .NET commands: `dotnet build` (no custom build steps).
- No tests or test projects are present.
- The library targets .NET 9.0 and references:
  - JetBrains.Annotations
  - Serilog.AspNetCore
  - Microsoft.EntityFrameworkCore.SqlServer
  - EntityCoreFileLogger
  - Spectre.Console
- No external configuration or environment variables are required for building.

## Patterns & Conventions
- All templates are static extension methods in public static classes, decorated with `[SourceTemplate]` and (optionally) `[Macro]`.
- Template methods often use `$END$` markers for IDE cursor placement.
- Logging and EF Core templates assume usage within ASP.NET Core's `WebApplicationBuilder`.
- File and directory structure is flat, except for the `Stubs` folder for minimal type stubs.
- No custom analyzers, code generation, or build scripts are present.

## Integration Points
- Designed for use with JetBrains Rider/Resharper's Source Templates feature.
- Integrates with ASP.NET Core and EF Core via extension methods.
- Uses Spectre.Console for console output in templates.

## Examples
- See `CollectionTemplates.cs` for iteration patterns:
  ```csharp
  items.iterateCollection();
  items.iterateWithIndex();
  ```
- See `EntityFrameworkCoreTemplates.cs` for EF Core setup:
  ```csharp
  builder.efConfigure<MyDbContext>();
  ```
- See `LoggingTemplates.cs` for Serilog setup:
  ```csharp
  builder.serilogConfigure();
  ```

## Recommendations for AI Agents
- When adding new templates, follow the static extension method + `[SourceTemplate]` pattern.
- Place stubs for types only in the `Stubs` folder if needed for template compilation.
- Keep all templates concise and focused on common .NET patterns.
- Avoid introducing runtime logic or dependencies not already present in the project.
