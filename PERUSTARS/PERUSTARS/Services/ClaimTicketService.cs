using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Domain.Services;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Services
{
    public class ClaimTicketService : IClaimTicketService
    {
        private readonly IClaimTicketRepository _claimTicketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClaimTicketService(IClaimTicketRepository claimTicketRepository, IUnitOfWork unitOfWork)
        {
            _claimTicketRepository = claimTicketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClaimTicketResponse> DeleteAsync(long id)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(id);

            if (existingClaimTicket == null)
                return new ClaimTicketResponse("Claim Ticket not found");

            try
            {
                _claimTicketRepository.Remove(existingClaimTicket);
                await _unitOfWork.CompleteAsync();

                return new ClaimTicketResponse(existingClaimTicket);
            }
            catch (Exception ex)
            {
                return new ClaimTicketResponse($"An error ocurred while deleting the Claim Ticket: {ex.Message}");
            }
        }

        public async Task<ClaimTicketResponse> GetByIdAsync(long id)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(id);

            if (existingClaimTicket == null)
                return new ClaimTicketResponse("Claim Ticket not found");
            return new ClaimTicketResponse(existingClaimTicket);
        }

        public async Task<IEnumerable<ClaimTicket>> ListAsync()
        {
            return await _claimTicketRepository.ListAsync();
        }

        public async Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long Id)
        {
            return await _claimTicketRepository.ListByPersonIdAsync(Id);
        }

        public async Task<ClaimTicketResponse> SaveAsync(ClaimTicket claimTicket)
        {
            try
            {
                await _claimTicketRepository.AddAsync(claimTicket);
                await _unitOfWork.CompleteAsync();

                return new ClaimTicketResponse(claimTicket);
            }
            catch (Exception ex)
            {
                return new ClaimTicketResponse($"An error ocurred while saving the Claim Ticket: {ex.Message}");
            }
        }

        public async Task<ClaimTicketResponse> UpdateAsync(long id, ClaimTicket claimTicket)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(id);

            if (existingClaimTicket == null)
                return new ClaimTicketResponse("Claim Ticket not found");

            existingClaimTicket.ClaimDescription = claimTicket.ClaimDescription;
            existingClaimTicket.ClaimSubject = claimTicket.ClaimSubject;
            existingClaimTicket.IncedentDate = claimTicket.IncedentDate;
            existingClaimTicket.ReportedPerson = claimTicket.ReportedPerson;

            try
            {
                _claimTicketRepository.Update(existingClaimTicket);
                await _unitOfWork.CompleteAsync();

                return new ClaimTicketResponse(existingClaimTicket);
            }
            catch (Exception ex)
            {
                return new ClaimTicketResponse($"An error ocurred while updating the Claim Ticket: {ex.Message}");
            }
        }
    }
}