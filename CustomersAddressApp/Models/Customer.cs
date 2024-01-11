using CustomersAddressApp.Classes;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
#pragma warning disable CS8632

namespace CustomersAddressApp.Models;
public partial class Customer
{
    [Required(ErrorMessage = "{0} is mandatory")]
    [MaxLength(10, ErrorMessage = "The {0} can not have more than {1} characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "{0} is mandatory")]
    [MaxLength(20, ErrorMessage = "The {0} can not have more than {1} characters")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "{0} is mandatory")]
    public Address Address { get; set; }
    [Required(ErrorMessage = "{0} is mandatory"), DataType(DataType.Text)]
    [StringLength(12, MinimumLength = 6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "{0} is mandatory"), DataType(DataType.Text)]
    [Compare("Password", ErrorMessage = "Passwords do not match, please try again")]
    [StringLength(12, MinimumLength = 6)]
    public string PasswordConfirmation { get; set; }

    [Required]
    [NotEqualTo("Password")]
    [Display(Name = "New Password")]
    public string NewPassword { get; set; }


}