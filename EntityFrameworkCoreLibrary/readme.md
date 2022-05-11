# About

For use with data annotation validations in `CustomerEntityFrameworkTestProject`.

```csharp
[TestMethod]
[TestTraits(Trait.EntityFrameworkValidationAnnotations)]
public void InvalidCustomerWithValidationTest()
{

    // arrange
    StringBuilder builder = new();
    builder.AppendLine("First name is required");
    builder.AppendLine("Last name is required");
    builder.AppendLine("BirthDate year must be between 1932 and 2022");

    // act
    var (success, messages) = ValidationOperations.IsValidEntity(CustomerInvalid);
    if (success)
    {
        // If model valid we add the a new record but it is not valid
    }
    else
    {
        // assert
        Check.That(messages).ContainsExactly(builder.ToString());
    }

}
```