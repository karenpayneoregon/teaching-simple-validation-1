using System.ComponentModel.DataAnnotations;

namespace ValidatorLibrary.Classes;

/// <summary>
/// Container for validation results
/// </summary>
public class EntityValidationResult
{
    /// <summary>
    /// List of validation errors
    /// </summary>
    public IList<ValidationResult> Errors { get; set; }

    /// <summary>
    /// Model has errors
    /// </summary>
    public bool HasError => Errors.Count > 0;

    /// <summary>
    /// Model state is valid
    /// </summary>
    public bool IsValid => Errors.Count == 0;

    /// <summary>
    /// Model state is invalid
    /// </summary>
    public bool IsNotValid => Errors.Count > 0;

    /// <summary>
    /// Get any validation errors
    /// </summary>
    /// <param name="errors">List of <see cref="ValidationResult"/></param>
    public EntityValidationResult(IList<ValidationResult> errors = null)
    {
        Errors = errors ?? new List<ValidationResult>();
    }
}