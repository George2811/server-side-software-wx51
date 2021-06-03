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
        private readonly IArtistRepository _artistRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClaimTicketService(IClaimTicketRepository claimTicketRepository, IUnitOfWork unitOfWork, IArtistRepository artistRepository, IHobbyistRepository hobbyistRepository)
        {
            _claimTicketRepository = claimTicketRepository;
            _unitOfWork = unitOfWork;
            _artistRepository = artistRepository;
            _hobbyistRepository = hobbyistRepository;
        }

        public async Task<ClaimTicketResponse> DeleteByArtistIdAsync(long artistId, long claimTicketId)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);

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

        public async Task<ClaimTicketResponse> DeleteByHobbyistIdAsync(long hobbyistId, long claimTicketId)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);

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

        public async Task<ClaimTicketResponse> GetByIdAndArtistIdAsync(long artistId, long claimTicketId)
        {
            var existingArtist = await _artistRepository.FindById(artistId);
            if (existingArtist == null)
                return new ClaimTicketResponse("Artist not found");

            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);
            if (existingClaimTicket == null)
                return new ClaimTicketResponse("Claim Ticket not found");

            if (!existingArtist.ClaimTickets.Contains(existingClaimTicket))
                return new ClaimTicketResponse("Claim Ticket not found by Artist with Id: " + artistId);

            return new ClaimTicketResponse(existingClaimTicket);
        }

        public async Task<ClaimTicketResponse> GetByIdAndHobbyistIdAsync(long hobbyistId, long claimTicketId)
        {
            var existingHobbyist = await _hobbyistRepository.FindById(hobbyistId);
            if (existingHobbyist == null)
                return new ClaimTicketResponse("Hobbyist not found");

            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);
            if (existingClaimTicket == null)
                return new ClaimTicketResponse("Claim Ticket not found");

            if (!existingHobbyist.ClaimTickets.Contains(existingClaimTicket))
                return new ClaimTicketResponse("Claim Ticket not found by Hobbyist with Id: " + hobbyistId);

            return new ClaimTicketResponse(existingClaimTicket);
        }

        public async Task<IEnumerable<ClaimTicket>> ListAsync()
        {
            return await _claimTicketRepository.ListAsync();
        }

        public async Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long personId)
        {
            return await _claimTicketRepository.ListByPersonIdAsync(personId);
        }

        public async Task<ClaimTicketResponse> SaveByArtistIdAsync(long artistId, ClaimTicket claimTicket)
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

        public async Task<ClaimTicketResponse> SaveByHobbyistIdAsync(long hobbyistId, ClaimTicket claimTicket)
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

        public async Task<ClaimTicketResponse> UpdateByArtistIdAsync(long artistId, long claimTicketId, ClaimTicket claimTicket)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);

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

        public async Task<ClaimTicketResponse> UpdateByHobbyistIdAsync(long hobbyistId, long claimTicketId, ClaimTicket claimTicket)
        {
            var existingClaimTicket = await _claimTicketRepository.FindById(claimTicketId);

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