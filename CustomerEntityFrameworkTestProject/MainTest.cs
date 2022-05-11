using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BaseDataValidatorLibrary.Classes;
using BaseDataValidatorLibrary.CommonRules;
using CustomerEntityFrameworkTestProject.Base;
using CustomerEntityFrameworkTestProject.Classes;
using EntityFrameworkCoreLibrary.Classes;
using EntityFrameworkCoreLibrary.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using EntityFrameworkCoreLibrary.Models;

namespace CustomerEntityFrameworkTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Comment out ignore, run to create/recreate the database
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.EntityFrameworkValidationAnnotations)]
        public async Task CreateDatabaseTest()
        {
            // arrange
            var (success, exception) = await CreateOperations.NewExampleDatabase();
            Check.That(success).IsTrue();
        }

        [TestMethod]
        [TestTraits(Trait.Tinkering)]
        public void GetDisplayName()
        {
            Console.WriteLine(CustomerValid.GetNameForProperty(customer => customer.FirstName));
            
            // without an instance
            //Console.WriteLine(CustomerValid.GetNameForProperty(customer => customer.BirthDate));
            //PropertyInfo result = typeof(Customer).GetProperty(nameof(Customer.BirthDate));
            //Console.WriteLine(ExtractDisplayHelpers.TryGetDisplayPrompt(result));

            var prompt = CustomerValid.GetAttributeFrom<DisplayAttribute>(nameof(CustomerValid.BirthDate)).Prompt;
            Console.WriteLine(prompt);
            var name = CustomerValid.GetAttributeFrom<DisplayAttribute>(nameof(CustomerValid.BirthDate)).Name;
            Console.WriteLine(name);

            var minimumYear = CustomerValid.GetAttributeFrom<YearRangeAttribute>(nameof(CustomerValid.BirthDate)).MinimumYear;
            Console.WriteLine(minimumYear);
            var maximumYear = CustomerValid.GetAttributeFrom<YearRangeAttribute>(nameof(CustomerValid.BirthDate)).MaximumYear;
            Console.WriteLine(maximumYear);
        }

        /// <summary>
        /// Mockup on how validation can be done with EF Core with a valid <see cref="Customer"/>
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void AddCustomerRecordValidTest()
        {
            var (success,  _) = ValidationOperations.IsValidEntity(CustomerValid);

            if (success)
            {
                using var context = new ExampleContext();
                context.Add(CustomerValid);
                Check.That(context.SaveChanges()).Equals(1);
            }
        }


        [TestMethod]
        [TestTraits(Trait.EntityFrameworkValidationAnnotations)]
        public void InvalidCustomerNoValidationTest()
        {
            using var context = new ExampleContext();
            context.Add(CustomerInvalid);
            try
            {
                var count = context.SaveChanges();
                Console.WriteLine(count);
            }
            catch (Exception e)
            {
                Check.That(e.Message)
                    .ContainsExactly(
                        "An error occurred while updating the entries. See the inner exception for details.");
            }
        }

        /// <summary>
        /// Not a conventional test. We are validating an invalid <see cref="Customer"/> and
        /// while doing this show the path to valid, add record, invalid, acknowledge invalid model state.
        /// </summary>
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
                // If model valid we add the a new record
            }
            else
            {
                // assert
                // can not add record, validation failed
                Check.That(messages).ContainsExactly(builder.ToString());
            }

        }
        [TestMethod]
        [TestTraits(Trait.EntityFrameworkValidationAnnotations)]
        public void InvalidCustomerMinBirthDateYearValidationTest()
        {

            // arrange

            Customer customer = CustomerValid;
            customer.BirthDate = new DateTime(1930, 1, 1);

            // act
            var ( _ , messages) = ValidationOperations.IsValidEntity(customer);

            // assert
            Check.That(messages).Equals("BirthDate year must be between 1932 and 2022");

        }
    }
}
