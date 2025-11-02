namespace ExtractInterfaceSample.Models;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
    Gender Gender { get; set; }
}