using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PPAC_API;
using PPAC_API.BAL.Interfaces;
using PPAC_API.BAL.Services;
using PPAC_API.DAL;

var builder = WebApplication.CreateBuilder(args);


// Configure JWT authentication
var key = Encoding.ASCII.GetBytes("thisismysecretkeyforjwttokenbasedauthentication");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Set to true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,        
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
    };
});

// Add services to the container.

builder.Services.AddDbContext<PPACDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PPACDbConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IPPAC_Repository, PPAC_Repository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GLobalExceptionHandlerMiddleware>();

app.Run();

