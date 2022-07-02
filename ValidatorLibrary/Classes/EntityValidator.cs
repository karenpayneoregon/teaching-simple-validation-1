using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidatorLibrary.Classes
{
    /// <summary>
    /// Wrapper for generic validator
    /// </summary>
    /// <typeparam name="T"><see cref="T"/></typeparam>
    public class EntityValidator<T> where T : class
    {
        /// <summary>
        /// Used to validate a model
        /// </summary>
        /// <param name="entity">instance of model</param>
        /// <returns><see cref="EntityValidationResult"/></returns>
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }
}
