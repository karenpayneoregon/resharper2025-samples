using AnonymousToNameTypeSample.Models;

namespace AnonymousToNameTypeSample.Classes;
internal class MockedData
{
    public static IEnumerable<Member> MembersList1() =>
    [
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female},
        new() { Id = 2, Active = false, FirstName = "Sue", SurName = "Williams", Gender = Gender.Female},
        new() { Id = 3, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 4, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 5, Active = true, FirstName = "Clair", SurName = "Smith",Gender = Gender.Other},
        new() { Id = 6, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female },
        new() { Id = 7, Active = true, FirstName = "Sue", SurName = "Miller", Gender = Gender.Female }
    ];
}
