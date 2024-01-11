using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using RulesUnitTestProject.Base;
using RulesUnitTestProject.Models;
using BaseDataValidatorLibrary.Helpers;

namespace RulesUnitTestProject
{
    [TestClass]
    public partial class ExistingFileNameAttributeTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void FileAttachmentTest()
        {
            // arrange
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShakeMe1.gif");
            FileAttachment attachment = new ()
            {
                FileName = fileName,
                Description = "Shake me"
            };

            // act
            var (success, _ ) = ValidationHelper.IsValidEntity(attachment);

            // assert

            Check.That(success).IsTrue();

        }

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void FileAttachmentMissingDescriptionTest()
        {
            // arrange
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShakeMe1.gif");
            FileAttachment attachment = new()
            {
                FileName = fileName,
                Description = null
            };

            // act
            var (success, _) = ValidationHelper.IsValidEntity(attachment);

            // assert

            Check.That(success).IsFalse();
        }

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void FileAttachmentFileExistsTest()
        {
            // arrange
            var expected = "Sorry but there is already an file with this name please rename your file";
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShakeMe.gif");
            FileAttachment attachment = new()
            {
                FileName = fileName,
                Description = "Whatever"
            };

            // act
            var ( _ , errorMessages) = ValidationHelper.IsValidEntity(attachment);
            Console.WriteLine(errorMessages);
            // assert
            Check.That(errorMessages).Contains(expected);
        }

    }
}
