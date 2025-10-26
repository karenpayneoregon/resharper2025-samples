using MoveTypesIntoMatchingFiles.Classes;
using Spectre.Console;
using SpectreConsoleLibrary;

namespace MoveTypesIntoMatchingFiles;
internal partial class Program
{
    static void Main(string[] args)
    {
        var people = MockedData.People.Take(3);
        
        var personsDump = ObjectDumper.Dump(people);

        AnsiConsole.MarkupLine(personsDump.Replace("new", "[hotpink2]new[/]"));
        
        SpectreConsoleHelpers.ExitPrompt();
    }
}
