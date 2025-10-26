using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable InconsistentNaming
namespace JetbrainsSourceTemplatesLibrary;
/// <summary>
/// 
/// </summary>
/// <remarks>
/// All connection strings assume ApplicationConnections
/// </remarks>
public static class AspNetCoreTemplates
{
    [SourceTemplate]
    public static void connectstring(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection");
    }

    [SourceTemplate]
    [Macro(Target = "Context", Expression = "suggestVariableName()")]
    [Macro(Target = "T")]
    public static void connectionpool<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        builder.Services.AddDbContextPool<T>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("ApplicationConnection")));
    }

    [SourceTemplate]
    [Macro(Target = "Context", Expression = "suggestVariableName()")]
    [Macro(Target = "T")]
    public static void connection<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        builder.Services.AddDbContext<T>(options =>
            options.UseSqlServer(
                builder.Configuration
                    .GetConnectionString("ApplicationConnection")));
    }
}