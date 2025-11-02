using Microsoft.EntityFrameworkCore;
using EntityCoreFileLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// ReSharper disable UnusedMember.Global
// ReSharper disable IDE1006

namespace JetbrainsSourceTemplatesLibrary;

/// <summary>
/// Provides a set of extension methods and templates for configuring and managing 
/// Entity Framework Core <see cref="DbContext"/> instances in ASP.NET Core applications.
/// </summary>
/// <remarks>
/// DbContextToFileLogger https://www.nuget.org/packages/EntityCoreFileLogger/
/// </remarks>
public static class EntityFrameworkCoreTemplates
{
    /// <summary>
    /// Configures the Entity Framework Core <see cref="DbContext"/> of type <typeparamref name="T"/> 
    /// for the provided <see cref="WebApplicationBuilder"/> instance.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="DbContext"/> to be configured. Must inherit from <see cref="DbContext"/>.
    /// </typeparam>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> instance to which the <typeparamref name="T"/> 
    /// <see cref="DbContext"/> configuration will be applied.
    /// </param>
    [SourceTemplate]
    [Macro(Target = "Context", Expression = "suggestVariableName()")]
    [Macro(Target = "T")]
    [Macro(Target = "DefaultConnection", Expression = "suggestVariableName()")]
    public static void efConfigure<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        builder.Services.AddDbContext<T>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("$DefaultConnection$"))
                .LogTo(new DbContextToFileLogger().Log, 
                    [DbLoggerCategory.Database.Command.Name], LogLevel.Information));
    }

    /// <summary>
    /// Ensures that the database for the provided <see cref="DbContext"/> instance is deleted and then recreated.
    /// </summary>
    /// <param name="dbContext">
    /// The <see cref="DbContext"/> instance whose database will be deleted and recreated.
    /// </param>
    [SourceTemplate]
    public static void create(this DbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
}
