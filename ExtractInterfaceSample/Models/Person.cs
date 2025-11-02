
namespace ExtractInterfaceSample.Models;


public class Person : IIdentity, IPerson
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; }
}

