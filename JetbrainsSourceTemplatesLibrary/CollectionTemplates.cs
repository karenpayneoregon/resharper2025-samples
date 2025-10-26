namespace JetbrainsSourceTemplatesLibrary;
public static class CollectionTemplates
{
    /// <summary>
    /// Iterates over a collection of items and provides a template for processing each item.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the collection.
    /// </typeparam>
    /// <param name="items">
    /// The collection of items to iterate over.
    /// </param>
    [SourceTemplate]
    [Macro(Target = "item", Expression = "suggestVariableName()")]
    public static void iterateCollection<T>(this IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            AnsiConsole.MarkupLine($"[cyan]$END$[/]");
        }
        //$ $END$
    }

    /// <summary>
    /// Iterates over a collection of items, providing both the index and the item for processing.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the collection.
    /// </typeparam>
    /// <param name="items">
    /// The collection of items to iterate over.
    /// </param>
    [SourceTemplate]
    [Macro(Target = "item", Expression = "suggestVariableName()")]
    public static void iterateWithIndex<T>(this IEnumerable<T> items)
    {

        foreach (var (index, item) in items.Index())
        {
            AnsiConsole.MarkupLine($"[cyan]{index,-5}{item}[/]");
        }
        //$ $END$
    }
}

