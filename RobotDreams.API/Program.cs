using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RobotDreams.API.Context;
using RobotDreams.API.Helper;
using RobotDreams.API.Model.Settings;
using Serilog;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment environment = builder.Environment;
builder.Configuration.Sources.Clear();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//var connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<RobotDreamsDbContext>(options => options.UseSqlServer(connection));

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                                       .Enrich.WithEnvironmentName()
                                                       .WriteTo.Debug()
                                                       .WriteTo.Console()
                                                       .WriteTo.Elasticsearch(ConfigureElasticSink.Configure(builder.Configuration, environment.EnvironmentName))
                                                       .Enrich.WithProperty("Environment", environment.EnvironmentName)
                                                       .ReadFrom.Configuration(builder.Configuration)
                                                       .CreateLogger();
builder.Host.UseSerilog();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
