using System.Text.RegularExpressions;

namespace ToGeneratedRegexSample.Classes1;
public class Validator
{
    public bool IsEmailValid(string email) 
        => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
}