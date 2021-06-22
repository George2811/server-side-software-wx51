using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
    }
}
