using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RobotDreams.API.Context;
using RobotDreams.API.Model.Settings;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment environment = builder.Environment;

builder.Configuration.Sources.Clear();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//builder.Configuration.AddXmlFile("appsettings.xml", true, true);
builder.Configuration//.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                     .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);

ConfigurationSettingsSimple simpleConfigurationSettings = new();
builder.Configuration.GetSection("Settings").Bind(simpleConfigurationSettings);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

//IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
//var connection = config["ConnectionStrings:DefaultConnection"];


builder.Services.AddDbContext<RobotDreamsDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Melih's API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = builder.Configuration["JwtSecurityToken:Audience"],
        ValidIssuer = builder.Configuration["JwtSecurityToken:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityToken:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.Configure<JwtSecurityTokenSettings>
        (builder.Configuration.GetSection("JwtSecurityToken"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var resp = "<html><b>You don't have access to this method. Forbidden</b></html>";

//app.UseStatusCodePages(Text.Plain, $"");
app.UseStatusCodePages(Text.Html, resp);
//app.UseExceptionHandler(exceptionHandlerApp =>
//{
//    exceptionHandlerApp.Run(async context =>
//    {
//        if (context.Response.StatusCode == StatusCodes.Status403Forbidden) {
//            context.Response.ContentType = Text.Plain;
//            await context.Response.WriteAsync("You don't have access this method");
//        }      
//    });
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
