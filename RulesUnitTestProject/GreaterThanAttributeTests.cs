using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BaseDataValidatorLibrary.CommonRules;
using BaseDataValidatorLibrary.Helpers;
using RulesUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using RulesUnitTestProject.Models;

namespace RulesUnitTestProject
{
    /// <summary>
    /// 
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
            FinancialCycleInventoryTurn item = new () { Days = -12 };
            // act
            var (success, messages) = ValidationHelper.IsValidEntity(item);
            // assert
            Check.That(success).IsFalse();
        }

    }

}