using System.Text.RegularExpressions;

namespace ToGeneratedRegexSample.Classes2;


public partial class Validator // Note: The class must be partial
{
    public bool IsEmailValid(string email) 
        => EmailRegex().IsMatch(email);

    // ReSharper generates this attribute and partial method definition
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegex();
}