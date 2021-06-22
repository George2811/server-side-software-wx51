using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services.Communications
{
    public class AuthenticationResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
