-- #region cs snippet 1
[TestMethod]
[TestTraits(Trait.AnnotationAttribute)]
public void InvalidCustomerNoFirstOrLastNameTest()
{
    // arrange
    StringBuilder builder = new();
    builder.AppendLine("First name is required");
    builder.AppendLine("Last name is required");
    Customer customer = new ();
    // act
    var (success, messages) = IsValidEntity(customer);

    // assert
    Check.That(messages).ContainsExactly(builder.ToString());
}

[TestMethod]
[TestTraits(Trait.AnnotationAttribute)]
public void ValidCustomerTest()
{
    // arrange
    Customer customer = new() {FirstName = "Karen", LastName = "Payne"};

    // act
    var (success, messages) = IsValidEntity(customer);

    // assert
    Check.That(success).IsTrue();
}

-- #endregion

-- #region cs snippet 2

private void ValidateButton_Click(object sender, EventArgs e)
{
    if (_customerBindingSource.Current is null)
    {
        Dialogs.Information(this, "Customer is in an invalid state");
    }
    else
    {
        var customer = _customerBindingSource.Customer();

        customer.NotesList = Operations.CreateNotes(Convert.ToInt32(NotesComboBox.Text));
        var (success, errorMessages) = IsValidEntity(customer);

        if (!success)
        {
            FunStuff.Shake(this);
            SetResultTextInChildWindow(errorMessages);
        }
        else
        {
            SetResultTextInChildWindow();
            Dialogs.Information(this, "Valid");
        }
    }

}
-- #endregion