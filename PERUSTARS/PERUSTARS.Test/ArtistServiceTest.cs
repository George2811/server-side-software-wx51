using NUnit.Framework;
using Moq;
using FluentAssertions;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PERUSTARS.Test
{
    public class ArtistServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoArtistReturnsArtistNotFoundResponse()
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
            message.Should().Be("Artist Not Found");
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