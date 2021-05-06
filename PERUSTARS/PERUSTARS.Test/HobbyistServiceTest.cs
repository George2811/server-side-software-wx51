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
    class HobbyistServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetAllAsyncWhenNoHobbyistReturnsHobbyistNotFoundResponse()
        {
            // Arrange
            var mockHobbyistRepository = GetDefaultIHobbyistRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var hobbyistId = 1;
            mockHobbyistRepository.Setup(r => r.FindById(hobbyistId))
                .Returns(Task.FromResult<Hobbyist>(null));

            var service = new HobbyistService(mockHobbyistRepository.Object, mockUnitOfWork.Object);

            // Act
            HobbyistResponse result = await service.GetByIdAsync(hobbyistId);
            var message = result.Message;
            // Assert
            message.Should().Be("Hobbyist Not Found");
        }
        private Mock<IHobbyistRepository> GetDefaultIHobbyistRepositoryInstance()
        {
            return new Mock<IHobbyistRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
