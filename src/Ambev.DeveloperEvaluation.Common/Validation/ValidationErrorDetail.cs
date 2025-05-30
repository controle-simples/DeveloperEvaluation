using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Common.Validation;

/// <summary>
/// Represents a validation error detail with property name, error code, and message.
/// </summary>
public class ValidationErrorDetail
{
    /// <summary>
    /// Gets or sets the name of the property that failed validation.
    /// </summary>
    public string PropertyName { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the validation error code (e.g., "NotEmptyValidator").
    /// </summary>
    public string Error { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the detailed validation error message.
    /// </summary>
    public string Detail { get; init; } = string.Empty;

    /// <summary>
    /// Converts a FluentValidation ValidationFailure into a ValidationErrorDetail.
    /// </summary>
    /// <param name="validationFailure">The validation failure to convert.</param>
    public static explicit operator ValidationErrorDetail(ValidationFailure validationFailure)
    {
        return new ValidationErrorDetail
        {
            PropertyName = validationFailure.PropertyName,
            Error = validationFailure.ErrorCode,
            Detail = validationFailure.ErrorMessage
        };
    }
}
