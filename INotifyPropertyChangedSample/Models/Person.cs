using System.ComponentModel;

namespace INotifyPropertyChangedSample.Models;


public class Person : INotifyPropertyChanged
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; }
    public required Language Language { get; set; }
}