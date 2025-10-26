using CommonHelpersLibrary;
using MoveTypesIntoMatchingFiles.Classes.Configuration;
using SpectreConsoleLibrary;

namespace MoveTypesIntoMatchingFiles;
internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Info.GetCopyright());
        SpectreConsoleHelpers.ExitPrompt();
    }
}
