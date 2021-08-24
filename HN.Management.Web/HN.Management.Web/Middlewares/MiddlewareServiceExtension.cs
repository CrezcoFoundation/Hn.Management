using HN.Management.Engine.Repositories;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HN.Management.Web.Extensions
{
    public static class MiddlewareServiceExtension
    {
      public static void ConfigureClassesWithInterfaces(this IServiceCollection service)
        {
            //Services
            service.AddScoped<IActivityService, ActivityService>();
            service.AddScoped<IDonationService, DonationService>();
            service.AddScoped<IDonorService, DonorService>();
            service.AddScoped<IEvidenceService, EvidenceService>();
            service.AddScoped<IProjectService, ProjectService>();
            service.AddScoped<IStudentService, StudetService>();
            service.AddScoped<IUserDonorPermitService, UserDonorPermitService>();
            service.AddScoped<IUserProjectPermitService, UserProjectPermitService>();
            service.AddScoped<IUserService, UserService>();

            //Repositories
            service.AddScoped<IActivityRepository, ActivityRepository>();
            service.AddScoped<IDonationRepository, DonationRepository>();
            service.AddScoped<IDonorRepository, DonorRepository>();
            service.AddScoped<IEvidenceRepository, EvidenceRepository>();
            service.AddScoped<IProjectRepository, ProjectRepository>();
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<IUserDonorPermitRepository, UserDonorPermitRepository>();
            service.AddScoped<IUserProjectPermitRepository, UserProjectPermitRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
        public static void ConfigureRedis(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:4455";
            });
        }
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
                => app.UseMiddleware<ApiExceptionHandlingMiddleware>();

    }
}
