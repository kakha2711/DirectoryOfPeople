using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DirectoryOfPeopel.Validation;

public class EnglishOrGeorgian : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //if(String.IsNullOrEmpty(value.ToString())) throw new ArgumentNullException("value");

        if (value is string name)
        {
            string ENAlphabetic = @"^[a-zA-Z]+$";
            string GEOAlphabetic = @"^[ა-ჰ]+$";

            if (Regex.IsMatch(name, ENAlphabetic) || Regex.IsMatch(name, GEOAlphabetic))
                return ValidationResult.Success;
        }

        return new ValidationResult("The string contains Georgian and English alphabets, the string must consist of any single alphabet.");
    }
}