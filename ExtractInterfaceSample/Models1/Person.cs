
namespace ExtractInterfaceSample.Models1;
public abstract class Person
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; }
}

public class Employee : Person
{
    public int EmployeeKey { get; set; }
    public DateOnly HiredDate { get; set; }
    public required string Position { get; set; }
}