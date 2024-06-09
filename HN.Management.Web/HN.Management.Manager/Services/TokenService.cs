using HN.Management.Engine.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using HN.Management.Engine.Util;

namespace HN.Management.Manager.Services
{
    public class TokenService
    {
        private readonly AppSetting appSetting;

        public TokenService(IOptions<AppSetting> appSetting)
        {
            this.appSetting = appSetting.Value;
        }

        public string GenerateToken(User user, List<string> privileges)
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
                        new Claim("RoleName", user.Role.Name),
                        new Claim("Privileges", BaseUtility.ToJsonString(privileges)),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.UserData, BaseUtility.ToJsonString(user))
                    }),

                Issuer = appSetting.ValidIssuer,
                Audience = appSetting.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(expireTime),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
