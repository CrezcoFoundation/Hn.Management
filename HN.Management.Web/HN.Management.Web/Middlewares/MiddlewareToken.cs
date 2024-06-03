using HN.Management.Engine.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Options;

namespace HN.Management.Web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareToken
    {
        private readonly RequestDelegate next;
        private readonly AppSetting settings;

        public MiddlewareToken(RequestDelegate next, IOptions<AppSetting> settings)
        {
            this.next = next;
            this.settings = settings.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var (userId, roleId) = ValidateAccessToken(token);
                httpContext.Items["UserId"] = userId;
                httpContext.Items["RoleId"] = roleId;
            }

            await next(httpContext);
        }
         
        private (string? userId, string? roleId) ValidateAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.settings.Secret));

                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = settings.ValidIssuer,
                    ValidAudience = settings.ValidAudience,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                var userId = jwtToken?.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
                var roleId = jwtToken?.Claims.FirstOrDefault(x => x.Type == "RoleId")?.Value;

                return (userId, roleId);
            }
            catch
            {
                return (null, null);
            }
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareToken>();
        }
    }
}
