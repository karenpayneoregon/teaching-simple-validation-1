using System.ComponentModel.DataAnnotations;

namespace CustomersAddressApp.Models;

#pragma warning disable CS8632
public class Address
{
    [Required(ErrorMessage = "{0} is mandatory")]
    public string City { get; set; }
    [Required(ErrorMessage = "{0} is mandatory")]
    public string State { get; set; }
    [Required(ErrorMessage = "{0} is mandatory")]
    public string Street { get; set; }
}