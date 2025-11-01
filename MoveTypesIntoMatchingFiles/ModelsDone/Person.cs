namespace MoveTypesIntoMatchingFiles.ModelsDone;
public class Person
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required Address Address { get; set; }
}