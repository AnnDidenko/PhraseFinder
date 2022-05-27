using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phrase_Finder.Application.Exceptions;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Helpers;
using Phrase_Finder.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class AuthService: IAuthService
    {
        private IUserRepository userRepository;
        private JWTHelper jwt;
        private IMapper mapper;
        private SymmetricSecurityKey key;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        private PasswordHasher hasher;

        public AuthService(IUserRepository userRepository, IOptionsMonitor<JWTHelper> jwt, PasswordHasher hasher, IMapper mapper)
        {
            this.mapper = mapper;
            this.jwt = jwt.CurrentValue;
            this.userRepository = userRepository;
            this.hasher = hasher;
            key = this.jwt.GetSecretKey();
        }

        public bool DoesUserNameExist(string userName)
        {
            var users = userRepository.GetAll().Where(i => i.Name == userName);
            if (users == null)
            {
                return true;
            }
            return false;
        }

        public List<UserDto> AllUsers()
        {
            var users = userRepository.GetAll().ToList();
            var usersDTO = mapper.Map<List<UserDto>>(users);
            return usersDTO;
        }

        public UserDto UserById(int id)
        {
            var user = userRepository.GetById(id);
            return mapper.Map<UserDto>(user);
        }

        public TokenResponseDto Authenticate(RegistrationRequestDto data)
        {
            var user = userRepository.GetAll()
                    .Where(i => i.Email == data.Email && hasher.Check(i.Password, data.Password))
                    .FirstOrDefault();

            if (user == null)
            {
                throw new InvalidAuthenticateException("Wrong login or password");
            }

            var token = GetTokenForUser(user);
            return new TokenResponseDto { Token = token };
        }

        public async Task<TokenResponseDto> Register(RegistrationRequestDto data)
        {
            var user = userRepository.GetAll()
                    .Where(i => i.Email == data.Email)
                    .FirstOrDefault();

            if (user != null)
            {
                throw new EntityAlreadyExistsException("User already exists");
            }

            var newUser = mapper.Map<User>(data);
            newUser.Role = "User";
            newUser.Password = hasher.Hash(data.Password);
            await userRepository.Add(newUser);

            var token = GetTokenForUser(newUser);
            return new TokenResponseDto { Token = token };
        }

        //private SecurityTokenDescriptor GetTokenDescriptor(User user)
        //{
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(
        //                     new Claim[] {
        //                        new Claim (ClaimsIdentity.DefaultNameClaimType, user.Name),
        //                        new Claim (ClaimsIdentity.DefaultRoleClaimType, user.Role),
        //                        new Claim ("userId", user.Id.ToString())
        //                     },
        //                     "Token",
        //                     ClaimsIdentity.DefaultNameClaimType,
        //                     ClaimsIdentity.DefaultRoleClaimType
        //                     ),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
        //    };

        //    return tokenDescriptor;
        //}

        public string GetTokenForUser(User user)
        {
            var now = DateTime.Now;
            var claims = GetClaimsForAuth(user);
            return GetTokenFromClaims(claims, TimeSpan.FromDays(13));
        }

        public string GetTokenFromClaims(IEnumerable<Claim> claims, TimeSpan lifetime)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING"));
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                notBefore: now,
                claims: claims,
                expires: now.Add(lifetime),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return tokenHandler.WriteToken(token);
        }

        private static List<Claim> GetClaimsForAuth(User user)
        {
            var tokenClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

            tokenClaims.Add(new Claim(ClaimTypes.Role, user.Role));

            return tokenClaims;
        }
    }
}
