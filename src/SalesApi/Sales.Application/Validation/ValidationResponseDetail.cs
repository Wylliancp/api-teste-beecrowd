using FluentValidation.Results;

namespace Sales.Application.Validation;

public class ValidationResponseDetail
{
    
    public bool IsValid { get; set; }
    public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];

    public ValidationResponseDetail()
    {
        
    }

    public ValidationResponseDetail(ValidationResult validationResult)
    {
        IsValid = validationResult.IsValid;
        Errors = validationResult.Errors.Select(o => (ValidationErrorDetail)o);
    }
}

