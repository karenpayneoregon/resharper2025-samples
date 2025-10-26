namespace AnonymousToNameTypeSample.Models;
public class GroupMember
{
    public string FullName { get; }
    public List<Member> Lists { get; }

    public GroupMember(string name, List<Member> items)
    {
        FullName = name;
        Lists = items;
    }
    public override string ToString() => FullName;

}