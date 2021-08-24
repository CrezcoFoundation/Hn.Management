using HN.Management.Engine.Models;
using HN.ManagementEngine.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HN.Management.Manager.Services.Interfaces;

namespace HN.Management.Manager.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSetting;

        public TokenService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public string GenerateToken(UserPermitDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var expireTime = _appSetting.ExpireTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("DonorPermit", user.DonorPermit.ToString()),
                        new Claim("ProjectPermit", user.ProjectPermit.ToString())
                    }),
                Issuer = _appSetting.ValidIssuer,
                Audience = _appSetting.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(expireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
