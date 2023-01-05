using SmartNestAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureBasicServices();
builder.Services.ConfigureBuiltinServices();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string clientID = MyConfig.GetSection("Authentication:ClientId").Value;
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartNest API Documentaion");
    c.OAuthClientId(clientID);
});
app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
