using Microsoft.IdentityModel.Tokens;
using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;
using MobileStoreManager.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobileStoreManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;

        public UsersService(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _configuration = configuration; 

        }

        public int AddUser(Users users)
        {
            if(users != null)
            {
                users.RoleId = 2;
                users.IsActive = 1;
            }

            return _usersRepository.AddUser(users);
        }

        public int DeleteUser(int userId)
        {
           return _usersRepository.DeleteUser(userId);
        }

        public LoginOutputDTO Login(Users users)
        {
            var _user = _usersRepository.Login(users);

            if(_user != null)
            {
                var token = GenerateJWTToken(_user);

                return new LoginOutputDTO
                {
                    Token = token,
                    UserId = _user.UserId,
                    RoleId = _user.RoleId,
                    EmailId = _user.EmailId,
                    IsActive = _user.IsActive,
                };
            }
            else
            {
                return null;
            }

           
        }

        private string GenerateJWTToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailId),
                new Claim(ClaimTypes.Role,user.RoleId.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                );
            var encodeToeken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToeken;
        }


    }
}
