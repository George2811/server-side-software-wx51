﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookingController : ControllerBase
    {


        private readonly IBookingService _bookingService;
        private readonly IEventService _eventService;
        private readonly IHobbyistService _hobbyistService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper, IHobbyistService hobbyistService, IEventService eventService = null)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _hobbyistService = hobbyistService;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IEnumerable<EventResource>> GetAllByHobbyistIdAsync(long hobbyistId)
        {
            var events = await _eventService.ListByHobbyistAsync(hobbyistId);
            var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return resources;
        }

        [HttpPost("{eventId}")]
        public async Task<IActionResult> AssignBooking(long hobbyistId, long eventId, DateTime attendance) {
            var result = await _bookingService.AssignBookingAsync(hobbyistId, eventId, attendance);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource.Event);
            return Ok(eventResource);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> UnassignBooking(long hobbyistId, long eventId) {
            var result = await _bookingService.UnassignBookingAsync(hobbyistId, eventId);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource.Event);
            return Ok(eventResource);
        }

    }
}
