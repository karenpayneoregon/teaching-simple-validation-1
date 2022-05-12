using BaseDataValidatorLibrary.CommonRules;

namespace RulesUnitTestProject.Models
{
    public class FinancialCycleInventoryTurn
    {
        [GreaterThan(0)]
        public int Days { get; set; }
        public Period[] Period { get; set; }
    }
}