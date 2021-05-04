using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task<SpecialtyResponse> GetByIdAsync(long Id);
    }
}
