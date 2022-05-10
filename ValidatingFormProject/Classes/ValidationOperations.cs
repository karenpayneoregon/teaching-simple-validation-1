using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationValidationLibrary.Models;
using BaseDataValidatorLibrary.Helpers;

namespace ValidatingFormProject.Classes
{
    public class ValidationOperations
    {
        public static (bool success, string errorMessages) IsValidCustomer(Customer customer)
        {
            var result = ValidationHelper.ValidateEntity(customer);
            if (result.IsNotValid)
            {
                StringBuilder builder = new ();
                result.Errors.ToList().ForEach(x => builder.AppendLine(x.ErrorMessage));
                return (false, builder.ToString());
            }
            else
            {
                return (true, null);
            }


        }
    }
}

