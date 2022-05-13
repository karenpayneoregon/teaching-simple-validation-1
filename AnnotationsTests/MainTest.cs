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


            // act


            // assert

        }

        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void ValidCustomer()
        {
            // arrange


            // act


            // assert

        }

        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void Problems()
        {
            var customer = new Models.Normal.Customer()
            {
                FirstName = "K",
                LastName = "12345678901",
                Country = new Models.Normal.Country()
            };

            var (_ , messages) = NuGetLibrary.IsValidEntity(customer);

            Console.WriteLine(messages);

        }

    }
}
