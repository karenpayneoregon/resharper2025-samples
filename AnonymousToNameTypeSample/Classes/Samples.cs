using AnonymousToNameTypeSample.Models;
using CommonHelpersLibrary;
using Spectre.Console;
using SpectreConsoleLibrary;

namespace AnonymousToNameTypeSample.Classes;
internal class Samples
{
    public static void GroupBySample()
    {
        SpectreConsoleHelpers.PrintPink();
        
        List<GroupMember> groups = MemberOperations.GetDuplicateActiveMembersDone(MockedData.MembersList1());
        
        foreach (GroupMember groupMember in groups)
        {
            AnsiConsole.MarkupLine($"[cyan]{groupMember}[/]");
            foreach (Member member in groupMember.Lists)
            {
                Console.WriteLine($"\tId: {member.Id,-3} Active: {member.Active.ToYesNo()}");
            }
        }
    }
}
