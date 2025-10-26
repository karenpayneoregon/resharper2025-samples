using ExtractInterfaceSample.Classes.Configuration;
using static SpectreConsoleLibrary.SpectreConsoleHelpers;

namespace ExtractInterfaceSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        DataOperations.GetSettings();
        ExitPrompt();
    }
}
