using AutoMapper;
using CarPoolAPI.MapperProfile;
using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.Repository;
using CarPoolDbContext.IRepository;
using CarPoolServices.IContracts;
using CarPoolServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var defaultConnString = builder.Configuration.GetConnectionString("CarpoolConnectionString");

// Add services to the container.

builder.Services.AddDbContext<CarPoolDataDbContext>(options =>options.UseSqlServer(defaultConnString,b => b.MigrationsAssembly("CarPoolAPI")));


builder.Services.AddScoped<IAuthorizationServices, AuthorizationServices>();
builder.Services.AddScoped<IOfferRideServices, OfferRideServices>();
builder.Services.AddScoped<ILocationServices, LocationServices>();
builder.Services.AddScoped<IBookRidesServices, BookRidesServices>();
builder.Services.AddScoped<ICommonServices, CommonServices>();

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped <IOfferRideRepository, OfferRideRepository> ();
builder.Services.AddScoped <ILocationRepository, LocationRepository> ();
builder.Services.AddScoped <IBookRidesRepository, BookRidesRepository> ();
//builder.Services.AddScoped <IOfferRideRepository, OfferRideRepository> ();
//builder.Services.AddTransient<IOfferRideServices, OfferRideServices>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:7221",
                        ValidAudience = "https://localhost:7221",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super-Secret_Car-Pool-User"))
                    };
                });


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CarpPool", Version = "v1" });
    c.CustomSchemaIds(x => x.FullName);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id ="Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


//builder.Services.AddSwaggerGen();












var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
