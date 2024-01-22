using HN.Management.Engine.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace HN.Management.Manager.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSetting;
        private readonly RequestDelegate _next;

        public TokenService(IOptions<AppSetting> appSetting, RequestDelegate next)
        {
            _appSetting = appSetting.Value;
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var (userId, roleId) = ValidateAccessToken(token);
                context.Items["UserId"] = userId;
                context.Items["RoleId"] = roleId;
            }

            await _next(context);
        }


        private (string? userId, string? roleId) ValidateAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.Secret));

                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = _appSetting.ValidIssuer,
                    ValidAudience = _appSetting.ValidAudience,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                var userId = jwtToken?.Claims.FirstOrDefault(x => x.Type == "uid")?.Value;
                var roleId = jwtToken?.Claims.FirstOrDefault(x => x.Type == "rid")?.Value;

                return (userId, roleId);
            }
            catch
            {
                return (null, null);
            }
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
