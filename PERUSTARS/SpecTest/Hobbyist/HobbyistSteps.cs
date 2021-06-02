using System;
using TechTalk.SpecFlow;

namespace SpecTest.Hobbyist
{
    [Binding]
    public class HobbyistSteps
    {
        [Given(@"I have supplied (.*) as hobbyistId")]
        public void GivenIHaveSuppliedAsHobbyistId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"hobbyist required attributes provided")]
        public void WhenHobbyistRequiredAttributesProvided(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"No hobbyist supplied All hobbyist list should return")]
        public void WhenNoHobbyistSuppliedAllHobbyistListShouldReturn(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"hobbyist details should be")]
        public void ThenHobbyistDetailsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
