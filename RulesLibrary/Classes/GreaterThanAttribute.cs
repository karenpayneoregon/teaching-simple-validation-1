using System;
using System.ComponentModel.DataAnnotations;

namespace RulesLibrary.Classes
{
    /// <summary>
    /// Provides rule to ensure property value is greater than a given value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        /// <summary>
        /// Assert a value is greater than <see cref="Maximum"/>
        /// </summary>
        /// <param name="maximum">value to validate</param>
        public GreaterThanAttribute(int maximum)
        {
            Maximum = maximum;
        }
        /// <summary>
        /// Max value
        /// </summary>
        public int Maximum { get; set; }
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = "is unacceptable";
            }

            return $"{name} must be greater than {Maximum}";

        }

        public override bool IsValid(object sender)
        {
            if (sender is not null)
            {
                return sender is int value && value > Maximum;
            }

            return false;
        }
    }
}