using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RulesLibrary.Classes
{
    /// <summary>
    /// Provides custom rule for phone number rather than using stock <see cref="PhoneAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CheckPhoneValidationAttribute : ValidationAttribute 
    {
        /// <summary>
        ///  Override of <see cref="ValidationAttribute.IsValid(object)" />
        /// </summary>
        public override bool IsValid(object sender)
        {

            static bool IsDigitsOnly(string value)
            {
                return value.All(character => character is >= '0' and <= '9');
            }

            if (sender == null)
            {
                return false;
            }

            string convertedValue = sender.ToString();

            return !string.IsNullOrWhiteSpace(convertedValue) && 
                   IsDigitsOnly(convertedValue) && 
                   convertedValue.Length <= 10;
        }
    }
}