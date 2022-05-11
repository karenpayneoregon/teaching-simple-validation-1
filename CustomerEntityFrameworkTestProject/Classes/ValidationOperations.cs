using System.Linq;
using System.Text;
using BaseDataValidatorLibrary.Helpers;

namespace CustomerEntityFrameworkTestProject.Classes
{
    public class ValidationOperations
    {
        /// <summary>
        /// Validate entity
        /// </summary>
        /// <param name="entity">Customer instance</param>
        /// <returns>success and if not valid error messages</returns>
        public static (bool success, string errorMessages) IsValidEntity<T>(T entity) where T : class
        {
            var result = ValidationHelper.ValidateEntity(entity);

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

