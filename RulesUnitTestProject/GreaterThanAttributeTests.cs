using BaseDataValidatorLibrary.Helpers;
using RulesUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using RulesUnitTestProject.Models;

namespace RulesUnitTestProject
{
    /// <summary>
    /// Here we are working with two attributes, one stock one custom.
    /// - Stock, no extra work but not fully clear
    /// - Custom, write code but is clear
    /// </summary>
    [TestClass]
    public partial class GreaterThanAttributeTests : TestBase
    {

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void ValidDays()
        {
            // arrange
            FinancialCycleInventoryTurn item = new () { Days = 6 };
            // act
            var (success, messages) = ValidationHelper.IsValidEntity(item);

            // assert
            Check.That(success).IsTrue();
        }
        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void InValidDays()
        {
            // arrange
            FinancialCycleInventoryTurn item = new () { Days = -1 };
            // act
            var (success, messages) = ValidationHelper.IsValidEntity(item);
            var result = (new EntityValidator<FinancialCycleInventoryTurn>()).Validate(item);
            if (result.IsValid)
            {
                Console.WriteLine("Is");
            }
            else
            {
                Console.WriteLine("Not");
            }

            // assert
            Check.That(success).IsFalse();
        }

    }

}