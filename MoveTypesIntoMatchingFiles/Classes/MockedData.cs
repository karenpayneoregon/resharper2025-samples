using MoveTypesIntoMatchingFiles.Models;

namespace MoveTypesIntoMatchingFiles.Classes;
public static class MockedData
{
    public static List<Person> People =>
    [
        new Person
        {
            Id = 1,
            Active = true,
            FirstName = "John",
            LastName = "Doe",
            Gender = Gender.Male,
            Address = new Address { Id = 1, Street = "123 Main St", City = "Portland", State = "OR" }
        },

        new Person
        {
            Id = 2,
            Active = true,
            FirstName = "Jane",
            LastName = "Smith",
            Gender = Gender.Female,
            Address = new Address { Id = 2, Street = "456 Oak Ave", City = "Salem", State = "OR" }
        },

        new Person
        {
            Id = 3,
            Active = false,
            FirstName = "Robert",
            LastName = "Johnson",
            Gender = Gender.Male,
            Address = new Address { Id = 3, Street = "789 Pine Rd", City = "Eugene", State = "OR" }
        },

        new Person
        {
            Id = 4,
            Active = true,
            FirstName = "Emily",
            LastName = "Davis",
            Gender = Gender.Female,
            Address = new Address { Id = 4, Street = "101 Birch Blvd", City = "Bend", State = "OR" }
        },

        new Person
        {
            Id = 5,
            Active = true,
            FirstName = "Michael",
            LastName = "Brown",
            Gender = Gender.Male,
            Address = new Address { Id = 5, Street = "202 Cedar Ln", City = "Medford", State = "OR" }
        },

        new Person
        {
            Id = 6,
            Active = false,
            FirstName = "Laura",
            LastName = "Wilson",
            Gender = Gender.Female,
            Address = new Address { Id = 6, Street = "303 Maple St", City = "Albany", State = "OR" }
        },

        new Person
        {
            Id = 7,
            Active = true,
            FirstName = "William",
            LastName = "Taylor",
            Gender = Gender.Male,
            Address = new Address { Id = 7, Street = "404 Spruce Ct", City = "Corvallis", State = "OR" }
        },

        new Person
        {
            Id = 8,
            Active = true,
            FirstName = "Olivia",
            LastName = "Anderson",
            Gender = Gender.Female,
            Address = new Address { Id = 8, Street = "505 Elm Dr", City = "Hillsboro", State = "OR" }
        },

        new Person
        {
            Id = 9,
            Active = false,
            FirstName = "James",
            LastName = "Martinez",
            Gender = Gender.Male,
            Address = new Address { Id = 9, Street = "606 Fir Way", City = "Gresham", State = "OR" }
        },

        new Person
        {
            Id = 10,
            Active = true,
            FirstName = "Sophia",
            LastName = "Thomas",
            Gender = Gender.Female,
            Address = new Address { Id = 10, Street = "707 Walnut Pl", City = "Beaverton", State = "OR" }
        }
    ];
}