using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ValidatorLibrary.Classes;
using ValidatorLibraryTestProject.Base;
using ValidatorLibraryTestProject.Models;
using static ValidatorLibrary.Classes.ValidationHelper;

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
            Customer customer = new();

            // act
            var ( _  , messages) = IsValidEntity(customer);

            // assert
            Check.That(messages).ContainsExactly(builder.ToString());

        }

        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void ValidCustomerTest()
        {
            // arrange
            Customer customer = new() { FirstName = "Karen", LastName = "Payne" };

            // act
            var (success, messages) = IsValidEntity(customer);

            // assert
            Check.That(success).IsTrue();
        }

        #region https://stackoverflow.com/questions/72213023/validation-in-winform-using-data-annotations
        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void InvalidReaderSettingTest()
        {
            // arrange
            ReaderSetting readerSetting = new() { RfidAddress = "abcd" };

            // act
            var (success, messages) = IsValidEntity(readerSetting);
            // assert
            Check.That(success).IsFalse();
        }
        [TestMethod]
        [TestTraits(Trait.AnnotationAttribute)]
        public void validReaderSettingTest()
        {
            // arrange
            ReaderSetting readerSetting = new() { RfidAddress = "abc" };

            // act
            var (success, messages) = IsValidEntity(readerSetting);

            // assert
            Check.That(success).IsTrue();
        }

        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void ReaderSettingsRaw()
        {
            ReaderSetting readerSetting = new() { RfidAddress = "abcd" };
            EntityValidator<ReaderSetting> validator = new EntityValidator<ReaderSetting>();
            EntityValidationResult result = validator.Validate(readerSetting);
            Assert.IsFalse(result.IsValid);

            if (result.IsValid)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                result.Errors.ToList().ForEach(x => Console.WriteLine(x.ErrorMessage));
            }
           
        }

        #endregion
    }
}
