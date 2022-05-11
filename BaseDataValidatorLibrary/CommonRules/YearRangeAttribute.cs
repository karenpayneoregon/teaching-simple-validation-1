using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using BaseDataValidatorLibrary.LanguageExtensions;

namespace BaseDataValidatorLibrary.CommonRules
{
    /// <summary>
    /// Custom attribute for year range, could also use <see cref="RangeAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class YearRangeAttribute : ValidationAttribute
    {
        public YearRangeAttribute(int maximumYear)
        {
            MaximumYear = maximumYear;
        }

        /// <summary>
        /// Maximum acceptable year
        /// </summary>
        public int MaximumYear { get; }

        /// <summary>
        /// Minimum acceptable year
        /// </summary>
        public int MinimumYear { get; set; }
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = "'{0}' and '{1}' do not match.";
            }

            return $"{name} year must be between {MinimumYear} and {MaximumYear}";

        }
        /// <summary>
        ///  Override of <see cref="ValidationAttribute.IsValid(object)" />
        /// </summary>
        /// <remarks>
        /// We could combine value with the return, that makes debugging impossible.
        /// </remarks>
        public override bool IsValid(object sender)
        {
            var value = (DateTime)sender;
            return value.Year.Between(MinimumYear, MaximumYear);
        }
    }
}