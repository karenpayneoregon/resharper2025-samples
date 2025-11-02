using SourceTemplatesSample.Models;

namespace SourceTemplatesSample.Classes;
public static class MockedData
{
    /// <summary>
    /// Provides a list of predefined <see cref="Person"/> objects with associated details.
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> of <see cref="Person"/> objects, each containing information such as
    /// ID, first name, last name, birth date, and address.
    /// </returns>
    public static List<Person> PeopleList()
        =>
        [
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1985, 5, 23),
                Address = new Address
                {
                    Street = "123 Maple St",
                    City = "Portland",
                    State = "OR",
                    ZipCode = "97205"
                }
            },

            new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateOnly(1990, 11, 14),
                Address = new Address
                {
                    Street = "456 Oak Ave",
                    City = "Eugene",
                    State = "OR",
                    ZipCode = "97401"
                }
            },

            new Person
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Johnson",
                BirthDate = new DateOnly(1978, 3, 9),
                Address = new Address
                {
                    Street = "789 Pine Rd",
                    City = "Salem",
                    State = "OR",
                    ZipCode = "97301"
                }
            }
        ];
}
