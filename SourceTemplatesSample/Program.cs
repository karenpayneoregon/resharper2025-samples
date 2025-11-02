using System.Text.Json;
using JetbrainsSourceTemplatesLibrary;
using SourceTemplatesSample.Classes;
using SourceTemplatesSample.Classes.Configuration;

namespace SourceTemplatesSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        
        var people = MockedData.PeopleList();
        
        SpectreConsoleHelpers.ExitPrompt();
    }
}
