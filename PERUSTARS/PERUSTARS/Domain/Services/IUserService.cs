using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<IEnumerable<User>> GetAllAsync();
        Task RegisterAsync(RegisterRequest request);
    }
}
