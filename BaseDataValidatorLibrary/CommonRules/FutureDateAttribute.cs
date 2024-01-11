#nullable enable
using System.ComponentModel.DataAnnotations;

namespace BaseDataValidatorLibrary.CommonRules;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// [FutureDate(Utc = false)]
/// public DateTime ScheduleDate { get; set; }
/// </remarks>
public class FutureDateAttribute : ValidationAttribute
{
    public bool Utc { get; set; } = true;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        var now = Utc ? DateTime.UtcNow : DateTime.Now;

        return (DateTime)value <= now
            ? new ValidationResult("The selected date must be in the future.")
            : ValidationResult.Success;
    }
}
