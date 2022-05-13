using System.Linq;
using System.Text;
using AnnotationsTests.Base;
using ValidatorLibrary;
using AnnotationsTests.Models;
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
    }
}
