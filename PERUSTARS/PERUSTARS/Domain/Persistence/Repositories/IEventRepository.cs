﻿using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> ListAsync();
        Task<IEnumerable<Event>> ListByArtistIdAsync(long eventId);
        Task AddAsync(Event _event);
        Task<Event> FindById(long id);
        void Update(Event _event);
        void Remove(Event _event);
    }
}
