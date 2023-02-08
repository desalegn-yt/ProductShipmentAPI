using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SmartNestAPI.Application.Core;
using SmartNestAPI.Application.Services;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Interfaces;
using System.Reflection;
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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "SmartNest API Documentation",
                    Version = "v1.0",
                    Description = ""
                });
                options.ResolveConflictingActions(x => x.First());
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    BearerFormat = "JWT",
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"https://{domain}/oauth/token"),
                            AuthorizationUrl = new Uri($"https://{domain}/authorize?audience={audience}"),
                            Scopes = new Dictionary<string, string>
                  {
                      { "openid", "OpenId" },

                  }
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
          {
              new OpenApiSecurityScheme
              {
                  Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
              },
              new[] { "openid" }
          }
      });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{domain}";
                options.Audience = audience;
            });
        }
        public static void ConfigureBuiltinServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IUserContainerService, UserContainerService>();
            services.AddScoped<IUserAddressService, UserAddressService>();
            services.AddScoped<IUserPaymentMethodService, UserPaymentMethodService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContainerLogService, ContainerLogService>();
            services.AddScoped<IContainerRuleService, ContainerRuleService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            services.AddScoped<ISupplierProductService, SupplierProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<PostgreSqlContext>();
            services.AddScoped<LogWriter>();

        }
    }
}
