using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
#pragma warning disable CA1869

namespace JetbrainsSourceTemplatesLibrary;

public static class CommonTemplates
{
    /// <summary>
    /// Retrieves the connection string named "MainConnection" from the application's configuration.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> instance used to access the application's configuration.
    /// </param>
    [SourceTemplate]
    public static void connectstring(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("MainConnection");
    }

    
    /// <summary>
    /// Serializes the provided collection of items into a JSON string with indented formatting.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the collection to be serialized.
    /// </typeparam>
    /// <param name="sender">
    /// The collection of items to serialize.
    /// </param>
    [SourceTemplate]
    [Macro(Target = "T")]
    public static void serialize<T>(this IEnumerable<T> sender)
    {
        JsonSerializer.Serialize(sender, new JsonSerializerOptions() {WriteIndented = true});
        //$ $END$
    }

    /// <summary>
    /// Serializes the provided collection of items into a JSON file.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the collection to be serialized.
    /// </typeparam>
    /// <param name="sender">
    /// The collection of items to serialize.
    /// </param>
    [SourceTemplate]
    public static void serializeToFile<T>(this IEnumerable<T> sender)
    {
        File.WriteAllText("$END$.json", JsonSerializer.Serialize(sender, new JsonSerializerOptions()));
    }

    [SourceTemplate]
    [Macro(Target = "T")]
    [Macro(Target = "list")]
    [Macro(Target = "fileName")]
    public static void deserialize<T>(this T sender, string fileName)
    {
        List<T> list = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(fileName))!;
    }

    private static string FileName => "appsettings.json";

    /// <summary>
    /// Determines whether a specified property exists within a given section of the appsettings.json file.
    /// </summary>
    /// <param name="section">The name of the section in the appsettings.json file to search for.</param>
    /// <param name="propertyName">The name of the property to check for within the specified section.</param>
    /// <returns>
    /// <see langword="true"/> if the specified property exists within the given section; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="FileNotFoundException">Thrown if the appsettings.json file is not found.</exception>
    /// <exception cref="JsonException">Thrown if the appsettings.json file contains invalid JSON.</exception>
    public static bool propExists(string section, string propertyName)
    {
        string jsonContent = File.ReadAllText(FileName);
        using JsonDocument doc = JsonDocument.Parse(jsonContent);
        return doc.RootElement.TryGetProperty(section, out JsonElement sectionElement) &&
               sectionElement.TryGetProperty(propertyName, out _);
    }

    /// <summary>
    /// Attempts to parse the provided string into the specified enum type.
    /// </summary>
    /// <typeparam name="T">
    /// The enum type to which the string should be parsed. Must be a value type.
    /// </typeparam>
    /// <param name="sender">
    /// The string to be parsed into the enum type.
    /// </param>
    /// <param name="type">
    /// A placeholder parameter representing the target enum type. This parameter is not used directly in the method logic.
    /// </param>
    /// <remarks>
    /// If the string can be successfully parsed into the specified enum type, the parsed value is assigned to a variable.
    /// </remarks>
    [SourceTemplate]
    [Macro(Target = "T")]
    [Macro(Target = "varName")]
    public static void parser<T>(this string sender, T type) where T : struct
    {
        
        if (Enum.TryParse(sender, true, out T varName))
        {
            //$ $END$
        }
        else
        {

        }
    }
}
