using Microsoft.Extensions.Configuration;
using HN.Management.Engine.Repositories;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HN.Management.Manager.Services.Paypal;
using HN.Management.Engine.Repositories.Paypal;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.ManagementEngine.Models;
using HN.Management.Engine.CosmosDb.Accessors;
using System;
using Microsoft.Azure.Cosmos;
using HN.Management.Engine.CosmosDb.Client;
using HN.Management.Engine.CosmosDb.Base;
using User = HN.ManagementEngine.Models.User;
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Auth;
using HN.Management.Engine.CosmosDb.DataInitializer;

namespace HN.Management.Web.Extensions
{
    public static class MiddlewareServiceExtension
    {
        public static void ConfigureClassesWithInterfaces(this IServiceCollection service)
        {
            //Services
            //service.AddScoped<IExpenseService, ExpenseService>();
            //service.AddScoped<IDonorService, DonorService>();
            //service.AddScoped<IEvidenceService, EvidenceService>();
            //service.AddScoped<IProjectService, ProjectService>();
            //service.AddScoped<IStudentService, StudetService>();
            //service.AddScoped<IUserRoleService, UserRoleService>();

            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IPaypalService, PaypalService>();
            service.AddScoped<IEmailService, EmailService>();
            service.AddScoped<IDonationService, DonationService>();
            service.AddScoped<IUserService, UserService>();

            //Repositories
            //service.AddScoped<IExpenseRepository, ExpenseRepository>();
            //service.AddScoped<IDonorRepository, DonorRepository>();
            //service.AddScoped<IEvidenceRepository, EvidenceRepository>();
            //service.AddScoped<IProjectRepository, ProjectRepository>();
            //service.AddScoped<IStudentRepository, StudentRepository>();
            //service.AddScoped<IUserRoleRepository, UserRoleRepository>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IDonationRepository, DonationRepository>();
            service.AddScoped<IPaypalRepository, PaypalRepository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IRolePrivilegeRepository, RolePrivilegeRepository>();

            service.AddScoped<IDataInitializer, DataInitializer>();
        }

        public static void ConfigureRedis(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:4455";
            });
        }

        // public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
        //      => app.UseMiddleware<ApiExceptionHandlingMiddleware>();

        public static void ConfigureJWToken(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = appSettings.ValidIssuer,
                    ValidAudience = appSettings.ValidAudience
                };
            });
        }

        /// <summary>
        ///  Setup Cosmos DB
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Cosmos Configuration
            var cosmosDbConnection = configuration.GetConnectionString("CosmosDb");
            var cosmosClient = new CosmosClient(cosmosDbConnection);
            services.AddSingleton(cosmosClient);

            services.AddSingleton(serviceProvider => CreateCosmosDbClient<Donation>(
                serviceProvider,
                Databases.CrezcoDatabaseId,
                Databases.CrezcoCollectionName));

            services.AddSingleton(serviceProvider => CreateCosmosDbClient<User>(
                serviceProvider,
                Databases.CrezcoDatabaseId,
                Databases.CrezcoCollectionName));

            services.AddSingleton(serviceProvider => CreateCosmosDbClient<Role>(
                serviceProvider,
                Databases.CrezcoDatabaseId,
                Databases.CrezcoCollectionName));

            services.AddSingleton(serviceProvider => CreateCosmosDbClient<RolePrivilege>(
             serviceProvider,
             Databases.CrezcoDatabaseId,
             Databases.CrezcoCollectionName));
             
            //Readers and Managers
            services.AddScoped<IDataReader<Donation>, DonationDataAccessor>();
            services.AddScoped<IDataManager<Donation>, DonationDataAccessor>();

            services.AddScoped<IDataReader<User>, UserDataAccessor>();
            services.AddScoped<IDataManager<User>, UserDataAccessor>();

            services.AddScoped<IDataReader<Role>, RoleDataAccessor>();
            services.AddScoped<IDataManager<Role>, RoleDataAccessor>();

            services.AddScoped<IDataReader<RolePrivilege>, PrivilegeDataAccessor>();
            services.AddScoped<IDataManager<RolePrivilege>, PrivilegeDataAccessor>();

        }

        private static ICosmosDbClient<T> CreateCosmosDbClient<T>(
            IServiceProvider serviceProvider,
            string databaseId,
            string collectionName)
            where T : IBaseEntity
        {
            var cosmosClient = serviceProvider.GetService<CosmosClient>();

            var configuration = serviceProvider.GetService<IConfiguration>();

            return new CosmosDbClient<T>(
                cosmosClient,
                databaseId,
                collectionName,
                configuration);
        }
    }
}
