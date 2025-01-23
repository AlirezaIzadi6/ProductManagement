using FluentValidation.Results;

namespace Application.Mappers;

public static class ValidationFailureToString
{
    public static List<string> GetList(List<ValidationFailure> errors)
    {
        var result = new List<string>();
        foreach (var error in errors)
        {
            result.Add(error.ErrorMessage);
        }
        return result;
    }
}
