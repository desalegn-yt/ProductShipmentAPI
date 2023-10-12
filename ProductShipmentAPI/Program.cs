using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureBasicServices();
builder.Services.ConfigureBuiltinServices();


builder.Services.AddControllers()
      .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
      });
builder.Services.AddEndpointsApiExplorer();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string clientID = MyConfig.GetSection("Authentication:ClientId").Value;
string clientSecret = MyConfig.GetSection("Authentication:ClientSecret").Value;
app.UseSwagger();
app.UseSwaggerUI(settings =>
{
    settings.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartNest API Documentation");
    settings.OAuthClientId(clientID);
    settings.OAuthClientSecret(clientSecret);
    settings.OAuthUsePkce();
});
app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
