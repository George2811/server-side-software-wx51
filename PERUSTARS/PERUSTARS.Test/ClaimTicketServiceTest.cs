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
    class ClaimTicketServiceTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public async Task GetByIdAsyncWhenValidClaimTicketReturnsClaimTicket()
        {
            var mockClaimTicketRepository = GetDefaultIClaimTicketRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var claimTicketId = 1;
            ClaimTicket claimTicket = new ClaimTicket();
            claimTicket.ClaimId = claimTicketId;
            mockClaimTicketRepository.Setup(r => r.FindById(claimTicketId))
                .Returns(Task.FromResult(claimTicket));

            var service = new ClaimTicketService(mockClaimTicketRepository.Object, mockUnitOfWork.Object);

            // Act
            ClaimTicketResponse result = await service.GetByIdAsync(claimTicketId);
            var claimTicketResult = result.Resource;
            // Assert
            claimTicketResult.Should().Be(claimTicket);
        }
        [Test]
        public async Task GetByIdAsyncWhenNoClaimTicketReturnsClaimTicketNotFoundResponse()
        {
            // Arrange
            var mockClaimTicketRepository = GetDefaultIClaimTicketRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var claimTicketId = 1;
            mockClaimTicketRepository.Setup(r => r.FindById(claimTicketId))
                .Returns(Task.FromResult<ClaimTicket>(null));

            var service = new ClaimTicketService(mockClaimTicketRepository.Object, mockUnitOfWork.Object);

            // Act
            ClaimTicketResponse result = await service.GetByIdAsync(claimTicketId);
            var message = result.Message;
            // Assert
            message.Should().Be("Claim Ticket not found");
        }
        private Mock<IClaimTicketRepository> GetDefaultIClaimTicketRepositoryInstance()
        {
            return new Mock<IClaimTicketRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
