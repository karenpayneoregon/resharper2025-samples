
namespace ExtractInterfaceSample.Models1;
public class Person
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public int EmployeeKey { get; set; }
    public DateOnly HiredDate { get; set; }
    public required string Position { get; set; }
}

public class Manager
{
    public int Id { get; set; }
    public int ManagerKey { get; set; }
    public required string Department { get; set; }
}