using Microsoft.Extensions.Configuration;
using HN.Management.Engine.Repositories;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HN.Management.Manager.Services.Paypal;
using HN.Management.Engine.Repositories.Paypal;
using static HN.Management.Engine.CosmosDb.Setting.CosmosSetting;
using HN.Management.Engine.CosmosDb;
using HN.Management.Engine.CosmosDb.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PayPalCheckoutSdk.Orders;

namespace HN.Management.Web.Extensions
{
    public static class MiddlewareServiceExtension
    {
        public static void ConfigureClassesWithInterfaces(this IServiceCollection service)
        {
            //Services
            //service.AddScoped<IExpenseService, ExpenseService>();
            //service.AddScoped<IDonationService, DonationService>();
            //service.AddScoped<IDonorService, DonorService>();
            //service.AddScoped<IEvidenceService, EvidenceService>();
            //service.AddScoped<IProjectService, ProjectService>();
            //service.AddScoped<IStudentService, StudetService>();
            //service.AddScoped<IUserRoleService, UserRoleService>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IPaypalService, PaypalService>();

            //Services
            service.AddScoped<IEmailService, EmailService>();

            //Repositories
            //service.AddScoped<IExpenseRepository, ExpenseRepository>();
            //service.AddScoped<IDonationRepository, DonationRepository>();
            //service.AddScoped<IDonorRepository, DonorRepository>();
            //service.AddScoped<IEvidenceRepository, EvidenceRepository>();
            //service.AddScoped<IProjectRepository, ProjectRepository>();
            //service.AddScoped<IStudentRepository, StudentRepository>();
            //service.AddScoped<IUserRoleRepository, UserRoleRepository>();


            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IPaypalRepository, PaypalRepository>();
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
            // Bind database-related bindings
            CosmosDbSettings cosmosDbConfig = configuration.GetSection("ConnectionStrings:CosmosDb").Get<CosmosDbSettings>();
            // register CosmosDB client and data repositories
            services.AddCosmosDb(cosmosDbConfig.EndpointUrl,
                                 cosmosDbConfig.PrimaryKey,
                                 cosmosDbConfig.DatabaseName,
                                 cosmosDbConfig.Containers);
        }


        /// <summary>
        ///  Register a singleton instance of Cosmos Db Container Factory, which is a wrapper for the CosmosClient.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="endpointUrl"></param>
        /// <param name="primaryKey"></param>
        /// <param name="databaseName"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static IServiceCollection AddCosmosDb(this IServiceCollection services,
                                                     string endpointUrl,
                                                     string primaryKey,
                                                     string databaseName,
                                                     List<ContainerInfo> containers)
        {
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(endpointUrl, primaryKey);
            CosmosContainerFactory cosmosDbClientFactory = new CosmosContainerFactory(client, databaseName, containers);

            // Microsoft recommends a singleton client instance to be used throughout the application
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.cosmos.cosmosclient?view=azure-dotnet#definition
            // "CosmosClient is thread-safe. Its recommended to maintain a single instance of CosmosClient per lifetime of the application which enables efficient connection management and performance"
            services.AddSingleton<ICosmosContainerFactory>(cosmosDbClientFactory);

            return services;
        }
    }
}
