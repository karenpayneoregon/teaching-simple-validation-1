using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BaseDataValidatorLibrary.LanguageExtensions;

namespace BaseDataValidatorLibrary.CommonRules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ListMustContainFewerThanAttribute : ValidationAttribute
    {
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
}