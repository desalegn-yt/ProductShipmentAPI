using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SmartNestAPI.Application.Core;
using SmartNestAPI.Application.Services;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Interfaces;
using System.Reflection.Metadata;

namespace SmartNestAPI.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureBasicServices(this IServiceCollection services)
        {

            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string clientID = MyConfig.GetSection("Authentication:ClientId").Value;
            string domain = MyConfig.GetSection("Authentication:Domain").Value;
            string audience = MyConfig.GetSection("Authentication:Audience").Value;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = audience;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "API",
                            Version = "v1",
                            Description = "A REST API",
                        });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            Scopes = new Dictionary<string, string>
                {
                    { "openid", "Open Id" }
                },
                            AuthorizationUrl = new Uri(domain + "authorize?audience=" + audience)
                        }
                    }
                });
            });
        }
        public static void ConfigureBuiltinServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<PostgreSqlContext>();
            services.AddScoped<LogWriter>();

        }
    }
}
