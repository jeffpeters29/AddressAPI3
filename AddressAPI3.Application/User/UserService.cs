using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AddressAPI3.Application.User
{
    using Domain;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public string _secret { get; set; }
        //private readonly AppSettings _appSettings;

        // note: CTOR CHAINING
        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository) : this(userRepository)
        {
            _secret = appSettings.Value.Secret;
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password, string referer)
        {
            var user = _userRepository.GetUser(username, password);

            if (user == null) return null;

            // Authentication successful so generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);                  //_appSettings.Secret
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Issuer = user.Referrer,
                Subject = new ClaimsIdentity(new Claim[]{
                                                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                                                            new Claim(ClaimTypes.Surname, user.LastName),
                                                            new Claim(ClaimTypes.Uri, referer)
                                                        }),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
