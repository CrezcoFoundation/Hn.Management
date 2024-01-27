using HN.Management.Engine.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HN.ManagementEngine.Models;

namespace HN.Management.Manager.Services
{
    public class TokenService
    {
        private readonly AppSetting appSetting;

        public TokenService(IOptions<AppSetting> appSetting)
        {
            this.appSetting = appSetting.Value;

        } 
        public string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("OLAh6Yh5KwNFvOqgltw7");
            var expireTime = appSetting.ExpireTime;
            var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("UserId", user.Id),
                        new Claim("RoleId", user.Role.Id),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("Role", user.Role.Name.ToString())
                    }),
                Issuer = appSetting.ValidIssuer,
                Audience = appSetting.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(0.5),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
