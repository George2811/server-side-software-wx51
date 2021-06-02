using System;
using TechTalk.SpecFlow;

namespace SpecTest.Specialty
{
    [Binding]
    public class SpecialtySteps
    {
        [Given(@"I have supplied (.*) as specialtyId")]
        public void GivenIHaveSuppliedAsSpecialtyId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"No specialty supplied All specialty list should return")]
        public void WhenNoSpecialtySuppliedAllSpecialtyListShouldReturn(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"specialty details should be")]
        public void ThenSpecialtyDetailsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
