using Sales.Application.Validation;

namespace Sales.Api.Common;

public class ApiResponse
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public IEnumerable<ValidationErrorDetail> Errors { get; init; } = [];
}
