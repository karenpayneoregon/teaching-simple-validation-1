using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationsTests.Classes;
using AnnotationsTests.Models;


// ReSharper disable once CheckNamespace - do not change
namespace AnnotationsTests
{
    public partial class MainTest
    {
        private List<Customer> Customers;
        private Customer FirstCustomer;
        [TestInitialize]
        public void Initialization()
        {
            Customers = Operations.Customers;
            FirstCustomer = Customers.FirstOrDefault();
        }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
    }
}
