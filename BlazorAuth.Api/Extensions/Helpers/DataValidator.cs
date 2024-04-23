
using System.ComponentModel.DataAnnotations;

namespace BlazorAuth.Api.Helpers;

public static class DataValidator
{
    public static List<string> Validate(this object obj)
    {
        var errors = new List<string>();

        if (obj == null) return errors;

        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults, true))
        {
            errors = validationResults.Select(x => x.ErrorMessage!).ToList();
        }

        return errors;
    }
}