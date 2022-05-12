using System.ComponentModel.DataAnnotations;
using BaseDataValidatorLibrary.CommonRules;

namespace RulesUnitTestProject.Models
{
    public class FinancialCycleInventoryTurn
    {
        [GreaterThan(-1)]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Days { get; set; }
        public Period[] Period { get; set; }
    }
}