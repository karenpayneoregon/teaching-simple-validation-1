using System;
using System.Linq;
using System.Text;
using AnnotationsTests.Base;
using ValidatorLibrary;
using AnnotationsTests.Models;
using AnnotationsTests.Models.Normal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NuGetLibrary = ValidatorLibrary.Classes.ValidationHelper;

namespace AnnotationsTests
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

            var customer = FirstCustomer;

            customer.FirstName = "";
            customer.LastName = "";

            // act
            var ( _ , messages) = NuGetLibrary.IsValidEntity(customer);
            
            // assert
            Check.That(messages).ContainsExactly(builder.ToString());
        }


        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void InvalidCustomerTest()
        {
            // arrange
            var customer = FirstCustomer;

            customer.FirstName = "";
            customer.LastName = "";

            // act
            var ( success, _ ) = NuGetLibrary.IsValidEntity(customer);

            // assert
            Check.That(success).IsFalse();
        }

        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void ValidCustomer()
        {
            // arrange

            var customer = FirstCustomer;


            // act

            var (success, _ ) = NuGetLibrary.IsValidEntity(customer);

            // assert
            Check.That(success).IsTrue();

        }

        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void Problems()
        {
            var customer = new Models.Normal.Customer()
            {
                FirstName = "K",
                LastName = "This happens to be a very long name",
                Country = new Models.Normal.Country()
            };

            var (_ , messages) = NuGetLibrary.IsValidEntity(customer);

            Console.WriteLine(messages);

        }

    }
}
