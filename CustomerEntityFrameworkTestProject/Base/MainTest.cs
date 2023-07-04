using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoreLibrary.Models;


// ReSharper disable once CheckNamespace - do not change
namespace CustomerEntityFrameworkTestProject
{
    public partial class MainTest
    {
        /// <summary>
        /// Perform initialization before test runs using assertion on current test name.
        /// </summary>
        [TestInitialize]
        public void Initialization()
        {

        }

        /// <summary>
        /// Perform cleanup after test runs using assertion on current test name.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {

        }
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        public Customer CustomerValid => new()
        {
            FirstName = "Karen",
            LastName = "Payne",
            BirthDate = new DateTime(1956, 1, 1)
        };

        public Customer CustomerInvalid => new();
    }
}
