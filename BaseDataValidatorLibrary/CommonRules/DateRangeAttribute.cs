using System;
using System.ComponentModel.DataAnnotations;
using BaseDataValidatorLibrary.LanguageExtensions;

namespace BaseDataValidatorLibrary.CommonRules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateRangeAttribute : ValidationAttribute
    {
        public DateRangeAttribute(int maximumYear)
        {
            MaximumDate = maximumYear;
        }
        /// <summary>
        /// Maximum permitted year
        /// </summary>
        public int MaximumDate { get; }
        /// <summary>
        /// Minimum permitted year
        /// </summary>
        public int MinimumDate { get; set; }
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage is null && ErrorMessageResourceName is null)
            {
                ErrorMessage = "'Year {0}' and/or year '{1}' are invalid";
            }

            return $"{name} year must be between {MinimumDate} and {MaximumDate}";

        }

        public override bool IsValid(object sender)
            => ((DateTime)sender).Year.Between(MinimumDate, MaximumDate);
    }
}