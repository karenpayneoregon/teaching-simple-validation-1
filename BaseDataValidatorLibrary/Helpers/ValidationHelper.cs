using System.Diagnostics;
using System.Text;

namespace BaseDataValidatorLibrary.Helpers;

public class ValidationHelper
{
    /// <summary>
    /// Validate entity against validation rules
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static EntityValidationResult ValidateEntity<T>(T entity) where T : class
    {
        return (new EntityValidator<T>()).Validate(entity);
    }

    /// <summary>
    /// Validate entity
    /// </summary>
    /// <param name="entity">Customer instance</param>
    /// <returns>success and if not valid error messages</returns>
    public static (bool success, string errorMessages) IsValidEntity<T>(T entity) where T : class
    {
        var result = ValidateEntity(entity);

        if (result.IsNotValid)
        {
            StringBuilder builder = new();
            if (result.Errors.Count == 1)
            {
                return (false, result.Errors.FirstOrDefault()!.ErrorMessage);
            }
            else
            {
                foreach (var resultError in result.Errors)
                {
                    Debug.WriteLine($"{resultError.MemberNames.FirstOrDefault()}  {resultError.ErrorMessage}");
                }
                result.Errors.ToList().ForEach(x => builder.AppendLine(x.ErrorMessage));
                return (false, builder.ToString());
            }

        }
        else
        {
            return (true, null);
        }
    }
    public static (bool success, List<ErrorContainer> container) IsValidEntityList<T>(T entity) where T : class
    {
        List<ErrorContainer> list = new();
        var result = ValidateEntity(entity);

        if (result.IsNotValid)
        {
            if (result.Errors.Count == 1)
            {
                //return (false, result.Errors.FirstOrDefault()!.ErrorMessage);
                list.Add(new ErrorContainer()
                {
                    Name = result.Errors.FirstOrDefault()!.MemberNames.FirstOrDefault(),
                    Description = result.Errors.FirstOrDefault()!.ErrorMessage
                });
                return (false, list);
            }
            else
            {
                foreach (var resultError in result.Errors)
                {
                    list.Add(new ErrorContainer()
                    {
                        Name = resultError.MemberNames.FirstOrDefault(),
                        Description = resultError.ErrorMessage
                    });
                }

                return (false,list);
            }

        }
        else
        {
            return (true, null);
        }
    }
}

public class ErrorContainer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public override string ToString() => Name;

}