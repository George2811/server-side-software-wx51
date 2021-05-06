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
            var artworkId = 1;
            Artwork artwork = new Artwork();
            artwork.ArtworkId = artworkId;
            mockArtworkRepository.Setup(r => r.FindById(artworkId))
                .Returns(Task.FromResult(artwork));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object);

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
            var artworkId = 1;
            mockArtworkRepository.Setup(r => r.FindById(artworkId))
                .Returns(Task.FromResult<Artwork>(null));

            var service = new ArtworkService(mockArtworkRepository.Object, mockUnitOfWork.Object);

            // Act
            ArtworkResponse result = await service.GetByIdAsync(artworkId);
            var message = result.Message;

            // Assert
            message.Should().Be("Artwork not found");
        }
        private Mock<IArtworkRepository> GetDefaultIArtworkRepositoryInstance()
        {
            return new Mock<IArtworkRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
