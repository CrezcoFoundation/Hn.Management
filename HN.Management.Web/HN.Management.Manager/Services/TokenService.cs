using HN.Management.Engine.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Manager.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSetting;

        public TokenService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("OLAh6Yh5KwNFvOqgltw7");
            var expireTime = _appSetting.ExpireTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("Role", user.Role.RoleName.ToString())
                    }),
                Issuer = _appSetting.ValidIssuer,
                Audience = _appSetting.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(0.5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
