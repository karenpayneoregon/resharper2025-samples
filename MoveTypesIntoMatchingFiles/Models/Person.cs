namespace MoveTypesIntoMatchingFiles.Models;
public class Person
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required Address Address { get; set; }
}
public class Address
{
    public int Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
}
public enum Gender
{
    Male,
    Female,
    Other
}