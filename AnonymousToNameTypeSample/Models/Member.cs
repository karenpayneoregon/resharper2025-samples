
namespace AnonymousToNameTypeSample.Models;

public class Member
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public override string ToString() => Id.ToString();
}