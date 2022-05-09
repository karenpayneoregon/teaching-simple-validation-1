using System;
using System.ComponentModel.DataAnnotations;

namespace BaseDataValidatorLibrary.CommonRules
{
    /// <summary>
    /// Custom rule for third digit
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ValidKeyAttribute : ValidationAttribute
    {
        public override bool IsValid(object sender)
        {
            string value = Convert.ToString(sender);

            if (value!.Length < 9)
            {
                return false;
            }

            return value[2] == '0' || value[2] == '3';
        }
    }
}