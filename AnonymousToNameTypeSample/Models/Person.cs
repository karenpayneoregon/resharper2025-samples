using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousToNameTypeSample.Models;
internal class Person
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
}
public enum Gender
{
    Male,
    Female,
    Other
}