using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RulesUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using RulesUnitTestProject.Classes;

namespace RulesUnitTestProject
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public partial class CustomerYearRangeTest : TestBase
    {

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void ValidYearTest()
        {
            // arrange
            var customer = Customer;

            // act
            var (success, _) = ValidationOperations.IsValidEntity(customer);

            // assert

            Check.That(success).IsTrue();
        }

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void InValidMinimumYearTest()
        {
            // arrange
            var customer = Customer;

            customer.BirthDate = new DateTime(1930, 1, 1);

            // act
            var (success, _) = ValidationOperations.IsValidEntity(customer);

            // assert

            Check.That(success).IsFalse();
        }

        [TestMethod]
        [TestTraits(Trait.CustomAnnotationAttribute)]
        public void InValidMaxYearTest()
        {
            // arrange
            var customer = Customer;

            customer.BirthDate = new DateTime(2030, 1, 1);

            // act
            var (success, _) = ValidationOperations.IsValidEntity(customer);

            // assert

            Check.That(success).IsFalse();
        }
    }

}