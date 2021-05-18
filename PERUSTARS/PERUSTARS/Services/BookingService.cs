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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<BookingResponse> AssignBookingAsync(long HobbyistId, long EventId, DateTime attendance)
        {
            try
            {
                await _bookingRepository.AssignBooking(HobbyistId, EventId, attendance);
                await _unitOfWork.CompleteAsync();
                Booking booking = await _bookingRepository.FindByHobbyistIdAndEventIdAsync(HobbyistId, EventId);
                return new BookingResponse(booking);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error ocurred while assigning a Booking: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await _bookingRepository.ListAsync();
        }

        public async Task<IEnumerable<Booking>> ListAsyncByHobbyistId(long Id)
        {
            return await _bookingRepository.ListByHobbyistIdAsync(Id);
        }

        public async Task<BookingResponse> UnassignBookingAsync(long HobbyistId, long EventId)
        {
            try
            {
                Booking booking = await _bookingRepository.FindByHobbyistIdAndEventIdAsync(HobbyistId, EventId);
                await _bookingRepository.UnassignBooking(HobbyistId, EventId);
                await _unitOfWork.CompleteAsync();
                return new BookingResponse(booking);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error ocurred while unassigning a Booking: {ex.Message}");
            }
        }
    }
}