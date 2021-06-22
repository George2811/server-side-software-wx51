using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Domain.Services;
using PERUSTARS.Domain.Services.Communications;
using PERUSTARS.Exceptions;
using PERUSTARS.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net;

namespace PERUSTARS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var users = await _userRepository.ListAsync();
            
            var user = users.SingleOrDefault(x => x.Username == request.Username);

            if (user == null || !BCryptNet.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new AppCustomException("Username or password is incorrect");
            }

            var token = GenerateJwtToken(user);
            return new AuthenticationResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.ListAsync();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var users = await _userRepository.ListAsync();

            if (users.Any(x => x.Username == request.Username))
            {
                throw new AppCustomException($"Username '{request.Username}' is already taken");
            }

            var user = _mapper.Map<RegisterRequest, User>(request);
            user.PasswordHash = BCryptNet.BCrypt.HashPassword(request.Password);

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
