using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ValidatorLibrary.Classes;
using ValidatorLibraryTestProject.Base;
using ValidatorLibraryTestProject.Models;

namespace ValidatorLibraryTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
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
            var (success, messages) = ValidationHelper.IsValidEntity(customer);

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
            var (success, messages) = ValidationHelper.IsValidEntity(customer);

            // assert
            Check.That(success).IsTrue();
        }
    }
}
