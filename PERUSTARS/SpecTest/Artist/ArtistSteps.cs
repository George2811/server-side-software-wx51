using System;
using TechTalk.SpecFlow;

namespace SpecTest.Artist
{
    [Binding]
    public class ArtistSteps
    {
        [Given(@"I have supplied (.*) as artist Id")]
        public void GivenIHaveSuppliedAsArtistId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"No artist supplied All Artist list should return")]
        public void WhenNoArtistSuppliedAllArtistListShouldReturn(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"artist details should be")]
        public void ThenArtistDetailsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
