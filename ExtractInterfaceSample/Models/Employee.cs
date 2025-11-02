namespace ExtractInterfaceSample.Models;

public class Employee 
{
    public int Id { get; set; }
    public DateOnly HiredDate { get; set; }
    public required string Position { get; set; }
}