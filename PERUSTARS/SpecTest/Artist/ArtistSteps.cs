using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Net;
using System.Collections.Generic;

/*****************************************************************************/
                            /*INSTRUCTIONS*/
/*****************************************************************************/

/*1-You must have run the main project at least once without creating any artist. 
    Otherwise, if you have created any artist, you must delete the database 
    and recreate it so that the IDs match the IDs of these tests. */

/*2-First run the test that initializes some artist instances. Then run 1 test at a 
    time. In order as the scenarios have been created. Scenario 1 first, then Scenario 
    2, and so on. Don't run them in the order they appear in the test explorer.*/

namespace SpecTest.Artist
{
    [Binding]
    public class ArtistSteps : BaseTest
    {
        private string ArtistEndPoint { get; set; }

        public ArtistSteps()
        {
            ArtistEndPoint = $"{ApiUri}api/artists";
        }



        /**************************************************/
          /*INITIALIZING TEST WITH SOME ARTISTS INSTANCES*/
        /**************************************************/

        [When(@"artists required attributes provided to initialize instances")]
        public void WhenArtistsRequiredAttributesProvidedToInitializeInstances(Table dtos)
        {
            foreach (var row in dtos.Rows)
            {
                try
                {
                    var artist = row.CreateInstance<PERUSTARS.Domain.Models.Artist>();
                    var data = JsonData(artist);
                    var result = Task.Run(async () => await Client.PostAsync(ArtistEndPoint, data)).Result;
                    Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Add Artist Integration Test Completed");
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false, ex.Message);
                }
            }
        }




        /************************************/
                    /*SCENARY 1*/
        /************************************/

        [When(@"artist required attributes provided")]
        public void WhenArtistRequiredAttributesProvided(Table dto)
        {
            try
            {
                var artist = dto.CreateInstance<PERUSTARS.Domain.Models.Artist>();
                var data = JsonData(artist);
                var result = Task.Run(async () => await Client.PostAsync(ArtistEndPoint, data)).Result;
                Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Add Artist Integration Test Completed");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }



        /************************************/
                    /*SCENARY 2*/
        /************************************/

        [Given(@"I have supplied (.*) as artist Id")]
        public void GivenIHaveSuppliedAsArtistId(long artistId)
        {
            var result = Task.Run(async () => await Client.GetAsync($"{ArtistEndPoint}/{artistId}")).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Get Artist Integration Test Completed");
        }
        
        [Then(@"artist details should be")]
        public void ThenArtistDetailsShouldBe(Table dto)
        {
            var artist = dto.CreateInstance<PERUSTARS.Domain.Models.Artist>();
            var result = Task.Run(async () => await Client.GetAsync($"{ArtistEndPoint}/{artist.Id}")).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Artist Details Integration Test Completed");
            var artistToCompare = ObjectData<PERUSTARS.Domain.Models.Artist>(result.Content.ReadAsStringAsync().Result);
            Assert.IsTrue(dto.IsEquivalentToInstance(artistToCompare));
        }



        /************************************/
                    /*SCENARY 3*/
        /************************************/

        [When(@"No artist supplied All Artist list should return")]
        public void WhenNoArtistSuppliedAllArtistListShouldReturn(Table dto)
        {
            var result = Task.Run(async () => await Client.GetAsync(ArtistEndPoint)).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Get All Artists Integration Test Completed");
            var artists = ObjectData<List<PERUSTARS.Domain.Models.Artist>>(result.Content.ReadAsStringAsync().Result);
            Assert.IsTrue(dto.RowCount == artists.Count, "Input and Out artist count matched");
        }




        /************************************/
                    /*SCENARY 4*/
        /************************************/

        [When(@"I have supplied (.*) as artist Id and update details provided")]
        public void WhenIHaveSuppliedAsArtistIdAndUpdateDetailsProvided(long artistId, Table dto)
        {
            try
            {
                var artist = dto.CreateInstance<PERUSTARS.Domain.Models.Artist>();
                var data = JsonData(artist);
                var result = Task.Run(async () => await Client.PutAsync($"{ArtistEndPoint}/{artistId}", data)).Result;
                Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Update Artist Integration Test Completed");
                var artistToCompare = ObjectData<PERUSTARS.Domain.Models.Artist>(result.Content.ReadAsStringAsync().Result);
                Assert.IsTrue(dto.IsEquivalentToInstance(artistToCompare));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }



        /************************************/
                    /*SCENARY 5*/
        /************************************/

        //Given function is in scenary 2 section -> [Given(@"I have supplied (.*) as artist Id")]
        //                                          public void GivenIHaveSuppliedAsArtistId(long artistId)

        [Then(@"remove artist with Id (.*) and removed artist details should be")]
        public void ThenRemoveArtistWithIdAndRemovedArtistDetailsShouldBe(int artistId, Table dto)
        {
            try
            {
                var result = Task.Run(async () => await Client.DeleteAsync($"{ArtistEndPoint}/{artistId}")).Result;
                Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Update Artist Integration Test Completed");
                var artistToCompare = ObjectData<PERUSTARS.Domain.Models.Artist>(result.Content.ReadAsStringAsync().Result);
                Assert.IsTrue(dto.IsEquivalentToInstance(artistToCompare));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }

    }
}
