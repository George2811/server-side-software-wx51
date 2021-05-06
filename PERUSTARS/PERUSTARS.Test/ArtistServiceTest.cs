using NUnit.Framework;
using Moq;
using FluentAssertions;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Services;
using System.Threading.Tasks;
using System.Collections;

namespace PERUSTARS.Test
{
    public class ArtistServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        // GET BY ID
        [Test]
        public async Task GetByIdAsyncWhenValidArtistReturnsArtist()
        {
            // Arrange
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var artistId = 1;
            Artist artist = new Artist();
            artist.Id = artistId;
            mockArtistRepository.Setup(r => r.FindById(artistId))
                .Returns(Task.FromResult(artist));

            var service = new ArtistService(mockArtistRepository.Object, mockUnitOfWork.Object);

            // Act
            ArtistResponse result = await service.GetByIdAsync(artistId);
            var artistResult = result.Resource;
            // Assert
            artistResult.Should().Be(artist);
        }
        [Test]
        public async Task GetByIdAsyncWhenNoArtistFoundReturnsArtistNotFoundResponse()
        {
            // Arrange
            var mockArtistRepository = GetDefaultIArtistRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var artistId = 1;
            mockArtistRepository.Setup(r => r.FindById(artistId))
                .Returns(Task.FromResult<Artist>(null));

            var service = new ArtistService(mockArtistRepository.Object, mockUnitOfWork.Object);

            // Act
            ArtistResponse result = await service.GetByIdAsync(artistId);
            var message = result.Message;
            // Assert
            message.Should().Be("Artist not found");
        }

        private Mock<IArtistRepository> GetDefaultIArtistRepositoryInstance()
        {
            return new Mock<IArtistRepository>(); 
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}