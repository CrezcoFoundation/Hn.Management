using HN.Management.Manager.Services.Interfaces;
using HN.Management.Manager.Services;
using HN.Management.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HN.Management.Engine.ViewModels;
using HN.Management.Engine.CosmosDb.Interfaces;
using Stripe;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;
using HN.Management.Manager.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using HN.Management.Web.Middlewares;
using HN.Management.Engine.Models;

namespace HN.Management.Web
{
    public class Startup
    {
        //private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        [System.Obsolete]
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Configuration = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureJWToken(Configuration);
            services.ConfigureRedis();

            //Add Cosmos db configuration
            services.SetupCosmosDb(Configuration);
            services.ConfigureClassesWithInterfaces();
            services.ConfigureMapping();

            services.Configure<AppSetting>(Configuration.GetSection("AppSettings"));
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.Configure<StripeSetting>(Configuration.GetSection("StripeSetting"));

            // Stripe Configurations
            services.AddScoped<PriceService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<PaymentIntentService>();
            services.AddScoped<InvoiceService>();
            services.AddScoped<SubscriptionService>();
            services.AddScoped<SetupIntentService>();
            StripeConfiguration.ApiKey = Configuration.GetValue<string>("StripeSetting:ApiKey");

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["JWT:Issuer"],
            //        ValidAudience = Configuration["JWT:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
            //            )
            //    };

            //});           

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            services.AddScoped<IEmailService, EmailService>();

            services.Configure<EmailOptions>(Configuration.GetSection(
                                EmailOptions.EmailSettings));

            services.Configure<StripeSetting>(Configuration.GetSection(
                        "StripeSetting"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HN.Management", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "HN.Management"));
            }

            // app.UseApiExceptionHandling();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddlewareToken();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                                           name: default,
                                           pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            var seedDatabaseService = app.ApplicationServices.GetService<IDataInitializerService>();
            seedDatabaseService.SeedDatabase();

            // global error handler
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        ApiException => (int)HttpStatusCode.InternalServerError,
                        ForbiddenException => (int)HttpStatusCode.Forbidden,
                        UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });

        }
    }
}
