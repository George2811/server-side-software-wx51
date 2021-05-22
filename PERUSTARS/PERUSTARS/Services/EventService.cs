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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventAssistanceRepository _eventAssistanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IEventRepository eventRepository, IEventAssistanceRepository eventAsisstanceRepository, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _eventAssistanceRepository = eventAsisstanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EventResponse> DeleteAsync(long id)
        {
            var existingEvent = await _eventRepository.FindById(id);

            if (existingEvent == null)
                return new EventResponse("Event not found");

            try
            {
                _eventRepository.Remove(existingEvent);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(existingEvent);
            }
            catch (Exception ex)
            {
                return new EventResponse($"An error ocurred while deleting the Event: {ex.Message}");
            }
        }

        public async Task<EventResponse> GetByIdAsync(long id)
        {
            var existingEvent = await _eventRepository.FindById(id);

            if (existingEvent == null)
                return new EventResponse("Event not found");
            return new EventResponse(existingEvent);
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _eventRepository.ListAsync();
        }

        public async Task<IEnumerable<Event>> ListAsyncByArtistId(long Id)
        {
            return await _eventRepository.ListByArtistIdAsync(Id);
        }

        public async Task<IEnumerable<Event>> ListAsyncByEventType(ETypeOfEvent eTypeOf)
        {
            return await _eventRepository.ListByEventTypeAsync(eTypeOf);
        }

        //Para event assistance
        public async Task<IEnumerable<Event>> ListByHobbyistAsync(long hobbyistId)
        {
            var eventAssistance = await _eventAssistanceRepository.ListByHobbyistIdAsync(hobbyistId);
            var events = eventAssistance.Select(pt => pt.Event).ToList();
            return events;
        }

        public async Task<EventResponse> SaveAsync(Event _event)
        {
            
            try
            {
                await _eventRepository.AddAsync(_event);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(_event);
            }
            catch (Exception ex)
            {
                return new EventResponse($"An error ocurred while saving the event: {ex.Message}");
            }
        
        }

        public async Task<EventResponse> UpdateAsync(long id, Event _event)
        {
            var existingEvent = await _eventRepository.FindById(id);

            if (existingEvent == null)
                return new EventResponse("Event not found");

            existingEvent.EventTitle = _event.EventTitle;
            existingEvent.EventType = _event.EventType;
            existingEvent.DateStart = _event.DateStart;
            existingEvent.DateEnd = _event.DateEnd;
            existingEvent.EventDescription = _event.EventDescription;
            existingEvent.EventAditionalInfo = _event.EventAditionalInfo;

            try
            {
                _eventRepository.Update(existingEvent);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(existingEvent);
            }
            catch (Exception ex)
            {
                return new EventResponse($"An error ocurred while updating the Event: {ex.Message}");
            }
        }
    }
}
