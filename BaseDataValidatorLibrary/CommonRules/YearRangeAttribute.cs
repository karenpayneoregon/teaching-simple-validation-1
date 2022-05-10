using System;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        ///  Override of <see cref="ValidationAttribute.IsValid(object)" />
        /// </summary>
        public override bool IsValid(object sender)
        {
            var value = (DateTime)sender;
            return value.Year >= MinimumYear && value.Year <= MaximumYear;
        }
    }
}