using System;
using TechTalk.SpecFlow;

namespace SpecTest.Event
{
    [Binding]
    public class EventSteps
    {
        [Given(@"I have supplied (.*) as eventId")]
        public void GivenIHaveSuppliedAsEventId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"event required attributes provided")]
        public void WhenEventRequiredAttributesProvided(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"No event supplied All events list should return")]
        public void WhenNoEventSuppliedAllEventsListShouldReturn(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"events details should be")]
        public void ThenEventsDetailsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
