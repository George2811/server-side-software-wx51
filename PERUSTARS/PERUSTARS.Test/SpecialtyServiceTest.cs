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
    class SpecialtyServiceTest
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public async Task GetAllAsyncWhenNoSpecialtyReturnsSpecialtyNotFoundResponse()
        {
            // Arrange
            var mockSpecialtyRepository = GetDefaultISpecialtyRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var specialtyId = 1;
            mockSpecialtyRepository.Setup(r => r.FindById(specialtyId))
                .Returns(Task.FromResult<Specialty>(null));

            var service = new SpecialtyService(mockSpecialtyRepository.Object, mockUnitOfWork.Object);

            // Act
            SpecialtyResponse result = await service.GetByIdAsync(specialtyId);
            var message = result.Message;
            // Assert
            message.Should().Be("Specialty Not Found");
        }
        private Mock<ISpecialtyRepository> GetDefaultISpecialtyRepositoryInstance()
        {
            return new Mock<ISpecialtyRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
