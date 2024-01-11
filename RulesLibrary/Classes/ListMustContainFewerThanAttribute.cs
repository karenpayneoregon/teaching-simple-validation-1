using System.Collections;
using System.ComponentModel.DataAnnotations;
using RulesLibrary.LanguageExtensions;

namespace RulesLibrary.Classes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class ListMustContainFewerThanAttribute : ValidationAttribute
{
    public ListMustContainFewerThanAttribute(int maximum)
    {
        Maximum = maximum;
    }

    /// <summary>
    /// Maximum allowed value
    /// </summary>
    public int Maximum { get; set; }

    /// <summary>
    /// Applies formatting to an error message, based on the data field where the error occurred.
    /// </summary>
    /// <param name="name">The name to include in the formatted message.</param>
    /// <returns>An instance of the formatted error message.</returns>
    public override string FormatErrorMessage(string name)
    {
        if (ErrorMessage == null && ErrorMessageResourceName == null)
        {
            ErrorMessage = "is unacceptable";
        }

        return $"{name.SplitCamelCase()} count must be less than {Maximum}";

    }
    /// <summary>
    ///  Override of <see cref="ValidationAttribute.IsValid(object)" />
    /// </summary>
    public override bool IsValid(object sender)
    {
        if (sender is null)
        {
            return false;
        }

        if (sender.IsList())
        {
            var result = ((IEnumerable)sender).Cast<object>().ToList();
            return result.Count < 5;
        }
        else
        {
            return false;
        }

    }
}