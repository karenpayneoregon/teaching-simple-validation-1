using System;
using System.ComponentModel.DataAnnotations;

namespace RulesLibrary.Classes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        public GreaterThanAttribute(string otherProperty) : base("{0} must be greater than {1}")
        {
            OtherProperty = otherProperty;
        }

        /// <summary>
        /// Value for comparing
        /// </summary>
        public string OtherProperty { get; set; }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name) 
            => string.Format(ErrorMessageString, name, OtherProperty);

        /// <summary>
        ///  Override of <see cref="ValidationAttribute.IsValid(object)" />
        /// </summary>
        protected override ValidationResult IsValid(object firstValue, ValidationContext validationContext)
        {
            var firstComparable = firstValue as IComparable;
            var secondComparable = GetSecondComparable(validationContext);

            if (firstComparable != null && secondComparable != null)
            {
                if (firstComparable.CompareTo(secondComparable) > 0)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// Comparer for use in comparision 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected IComparable GetSecondComparable(ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (propertyInfo != null)
            {
                var secondValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
                return secondValue as IComparable;
            }

            return null;
        }
    }
}
