using CustomersAddressApp.Models;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace CustomersAddressApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Customer customer = new()
        {
            FirstName = "Karen",
            LastName = "Payne",
            Password = "password",
            PasswordConfirmation = "password",
            NewPassword = "Password",
            Address = new Address()
            {
                Street = "802 Wyndmoor ave", 
                City = "Wyndmoor",
                State = "Pennsylvania"
            }
        };

        IEnumerable<ValidationResult> result = customer.Validate();


        ValidationResult[] validationResults = result as ValidationResult[] ?? result.ToArray();

        if (validationResults.Any())
        {
            AnsiConsole.MarkupLine("[yellow]invalidate[/]");
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[yellow]Validate[/]");
        }


        Console.ReadLine();
    }
}