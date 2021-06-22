using NUnit.Framework;
using Moq;
using FluentAssertions;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Services;
using System.Threading.Tasks;

namespace PERUSTARS.Test
{
    class ArtworkServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        // GET BY ID
        [Test]
        public async Task GetByIdWhenValidArtworkReturnsArtwork()
        {
            // Arrange
            var mockArtworkRepository = GetDefaultIArtworkRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var favoriteArtworkRepository = new Mock<IFavoriteArtworkRepository>();
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();
            var artworkId = 1;

            Artwork artwork = new Artwork();
            artwork.ArtworkId = artworkId;
            mockArtworkRepository.Setup(r => r.FindById(artworkId))
                .Returns(Task.FromResult(artwork));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object, favoriteArtworkRepository.Object, mockArtistRepository.Object);

            // Act
            ArtworkResponse result = await service.GetByIdAsync(artworkId);
            var artworkResult = result.Resource;
            // Assert
            artworkResult.Should().Be(artwork);
        }
       
        [Test]
        public async Task GetByIdWhenNoArtworkReturnsArtworkNotFoundResponse()
        {
            // Arrange
            var mockArtworkRepository = GetDefaultIArtworkRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var favoriteArtworkRepository = new Mock<IFavoriteArtworkRepository>();
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();
            var artworkId = 1;
            mockArtworkRepository.Setup(r => r.FindById(artworkId))
                .Returns(Task.FromResult<Artwork>(null));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object, favoriteArtworkRepository.Object, mockArtistRepository.Object);

            // Act
            ArtworkResponse result = await service.GetByIdAsync(artworkId);
            var message = result.Message;

            // Assert
            message.Should().Be("Artwork not found");
        }


        //REPITE TITULO DE OBRA

        [Test]
        public async Task GetIsSameTitleWhenArtistRepitTitle()
        {
            //Arrange
            var mockArtworkRepository = GetDefaultIArtworkRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var favoriteArtworkRepository = new Mock<IFavoriteArtworkRepository>();
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();

            Artist artist = new Artist();
            artist.Id = 1;
            artist.Firstname = "Sebastian";
            artist.Lastname = "Gonzales";
            artist.BrandName = "SebasGx";

            Artwork artwork1 = new Artwork(); ;
            artwork1.ArtworkId = 1;
            artwork1.ArtistId = 1;
            artwork1.ArtTitle = "hola";

            Artwork artwork2 = new Artwork(); ;
            artwork2.ArtworkId = 2;
            artwork2.ArtistId = 1;
            artwork2.ArtTitle = "adios";




            mockArtworkRepository.Setup(r => r.isSameTitle("hola", 1))
                  .Returns(Task.FromResult(true));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object, favoriteArtworkRepository.Object, mockArtistRepository.Object);


            //Act


            bool result = await service.isSameTitle("hola", 1);


            //Assert
            Assert.IsTrue(result);
        }


        //NO REPITE TITULO DE OBRA

        [Test]
        public async Task GetIsSameTitleWhenArtistNOTRepitTitle()
        {
            //Arrange
            var mockArtworkRepository = GetDefaultIArtworkRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var favoriteArtworkRepository = new Mock<IFavoriteArtworkRepository>();
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();

            Artist artist = new Artist();
            artist.Id = 1;
            artist.Firstname = "Sebastian";
            artist.Lastname = "Gonzales";
            artist.BrandName = "SebasGx";

            Artwork artwork1 = new Artwork(); ;
            artwork1.ArtworkId = 1;
            artwork1.ArtistId = 1;
            artwork1.ArtTitle = "hola";

            Artwork artwork2 = new Artwork(); ;
            artwork2.ArtworkId = 2;
            artwork2.ArtistId = 1;
            artwork2.ArtTitle = "adios";




            mockArtworkRepository.Setup(r => r.isSameTitle("titulo", 1))
                  .Returns(Task.FromResult(false));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object, favoriteArtworkRepository.Object);


            //Act


            bool result = await service.isSameTitle("titulo", 1);


            //Assert
            Assert.AreEqual(result, false);
        }








        private Mock<IArtworkRepository> GetDefaultIArtworkRepositoryInstance()
        {
            return new Mock<IArtworkRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private Mock<IArtistRepository> GetDefaultIArtistRepositoryInstance()
        {
            return new Mock<IArtistRepository>();
        }
    }
}
