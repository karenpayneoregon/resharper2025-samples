using AnonymousToNameTypeSample.Models;

namespace AnonymousToNameTypeSample.Classes;
internal class MemberOperations
{

    /// <summary>
    /// Identifies duplicate active members from the provided list of members.
    /// </summary>
    /// <param name="list">
    /// A collection of <see cref="Member"/> objects to be analyzed for duplicates.
    /// </param>
    /// <remarks>
    /// This method groups members by their first name, surname, and active status.
    /// It filters groups where the active status is true and the group contains more than one member.
    /// The result is a list of anonymous objects containing the full name and the list of duplicate members.
    ///
    /// --> Original method using anonymous types
    /// </remarks>
    public static void GetDuplicateActiveMembers(IEnumerable<Member> list)
    {
        var duplicates = list
            .GroupBy(member => new { member.FirstName, member.SurName, member.Active })
            .Where(group => group.Key.Active && group.Count() > 1)
            .Select(group => new
            {
                FullName = $"{group.Key.FirstName} {group.Key.SurName}",
                Members = group.ToList()
            })
            .ToList();
    }

    /// <summary>
    /// Identifies duplicate active members from the provided list of members and returns them as named groups.
    /// </summary>
    /// <param name="list">
    /// A collection of <see cref="Member"/> objects to be analyzed for duplicates.
    /// </param>
    /// <returns>
    /// A list of <see cref="GroupMember"/> objects, where each group represents a set of duplicate active members
    /// with the same first name and surname.
    /// </returns>
    /// <remarks>
    /// This method groups members by their first name, surname, and active status. It filters groups where the active
    /// status is true and the group contains more than one member. The result is a list of <see cref="GroupMember"/>
    /// objects containing the full name and the list of duplicate members.
    ///
    /// --> Refactored method using named types using ReSharper's "Convert anonymous type to named type" feature.
    /// 
    /// </remarks>
    public static List<GroupMember> GetDuplicateActiveMembersDone(IEnumerable<Member> list) =>
        list
            .GroupBy(member => (Name: member.FirstName, member.SurName, member.Active))
            .Where(group =>
            {
                if (!group.Key.Active) return false;
                return group.Count() > 1;

            })
            .Select(item =>
                new GroupMember($"{item.Key.Name} {item.Key.SurName}", [.. item]))
            .ToList();
}
