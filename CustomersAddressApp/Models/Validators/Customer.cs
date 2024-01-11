using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

// ReSharper disable once CheckNamespace
namespace CustomersAddressApp.Models;
public partial class Customer
{
    public IEnumerable<ValidationResult> Validate()
    {
        var results = new List<ValidationResult>();

        Validator.TryValidateProperty(FirstName,
            new ValidationContext(this, null, null) { MemberName = nameof(FirstName) }, results);

        Validator.TryValidateProperty(LastName,
            new ValidationContext(this, null, null) { MemberName = nameof(LastName) }, results);

        Validator.TryValidateProperty(Password,
            new ValidationContext(this, null, null) { MemberName = nameof(Password) }, results);

        Validator.TryValidateProperty(PasswordConfirmation,
            new ValidationContext(this, null, null) { MemberName = nameof(PasswordConfirmation) }, results);

        Validator.TryValidateProperty(NewPassword,
            new ValidationContext(this, null, null) { MemberName = nameof(NewPassword) }, results);

        Validator.TryValidateProperty(Address.City,
            new ValidationContext(Address, null, null) { MemberName = nameof(Address.City) }, results);

        Validator.TryValidateProperty(Address.State,
            new ValidationContext(Address, null, null) { MemberName = nameof(Address.State) }, results);

        return results;
    }
}
