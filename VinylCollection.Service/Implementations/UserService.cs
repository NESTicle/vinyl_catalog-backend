using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using VinylCollection.Data.Helpers;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Security;
using VinylCollection.Domain.Helper;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly VinylDbContext _context;

        public UserService(VinylDbContext context)
        {
            _context = context;
        }

        public int RegisterAccount(User model)
        {
            try
            {
                model.Id = 0;
                model.Password = PasswordHasher.HashPassword(model.Password);

                _context.User.Add(model);

                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User LoginUser(User model)
        {
            try
            {
                User user = _context.User
                    .AsNoTracking()
                    .Where(x => x.Deleted == false && x.UserName.Trim().ToLower() == model.UserName.Trim().ToLower())
                    .FirstOrDefault();

                if (user == null)
                    return null;

                return PasswordHasher.ValidatePassword(model.Password, user.Password) ? user : null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtHelper.GetHashKeyJwt()), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
