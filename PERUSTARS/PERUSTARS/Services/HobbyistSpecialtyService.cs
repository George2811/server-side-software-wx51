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
    public class HobbyistSpecialtyService : IHobbyistSpecialtyService
    {
        private readonly IHobbyistSpecialtyRepository _hobbyistSpecialtyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HobbyistSpecialtyService(IHobbyistSpecialtyRepository hobbyistSpecialtyRepository, IUnitOfWork unitOfWork)
        {
            _hobbyistSpecialtyRepository = hobbyistSpecialtyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<HobbyistSpecialtyResponse> AssignHobbyistSpecialtyAsync(long HobbyistId, long SpecialtyId)
        {
            try
            {
                await _hobbyistSpecialtyRepository.AssignHobbyistSpecialty(HobbyistId, SpecialtyId);
                await _unitOfWork.CompleteAsync();
                HobbyistSpecialty hobbyistSpecialty = await _hobbyistSpecialtyRepository.FindByHobbyistIdAndSpecialtyId(HobbyistId, SpecialtyId);
                return new HobbyistSpecialtyResponse(hobbyistSpecialty);
            }
            catch (Exception ex)
            {
                return new HobbyistSpecialtyResponse($"An error ocurred while assignig Specialty to Hobbyist: {ex.Message}");
            }
        }

        public async Task<IEnumerable<HobbyistSpecialty>> ListAsync()
        {
            return await _hobbyistSpecialtyRepository.ListAsync();
        }

        public async Task<IEnumerable<HobbyistSpecialty>> ListByHobbyistsIdAsync(long HobbyistId)
        {
            return await _hobbyistSpecialtyRepository.ListByHobbyistIdAsync(HobbyistId);
        }

        public async Task<HobbyistSpecialtyResponse> UnassignHobbyistSpecialtyAsync(long HobbyistId, long SpecialtyId)
        {
            try
            {
                HobbyistSpecialty hobbyistSpecialty = await _hobbyistSpecialtyRepository.FindByHobbyistIdAndSpecialtyId(HobbyistId, SpecialtyId);
                _hobbyistSpecialtyRepository.UnassignHobbyistSpecialty(HobbyistId, SpecialtyId);
                await _unitOfWork.CompleteAsync();
                return new HobbyistSpecialtyResponse(hobbyistSpecialty);
            }
            catch (Exception ex)
            {
                return new HobbyistSpecialtyResponse($"An error ocurred while unassignig Specialty to Hobbyist: {ex.Message}");
            }
        }
    }
}
