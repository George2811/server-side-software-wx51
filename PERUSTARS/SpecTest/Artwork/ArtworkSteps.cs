using System;
using TechTalk.SpecFlow;

namespace SpecTest.Artwork
{
    [Binding]
    public class ArtworkSteps
    {
        [Given(@"I have supplied (.*) as artworkId")]
        public void GivenIHaveSuppliedAsArtworkId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"artwork required attributes provided")]
        public void WhenArtworkRequiredAttributesProvided(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"No artwork supplied All artworks list should return")]
        public void WhenNoArtworkSuppliedAllArtworksListShouldReturn(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"artwork details should be")]
        public void ThenArtworkDetailsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
