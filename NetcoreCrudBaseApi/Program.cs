using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Repositories;
using NetcoreCrudBaseApi.Domains.Repositories.Context;
using NetcoreCrudBaseApi.Domains.Services;
using NetcoreCrudBaseApi.Infrastructure.Auth;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configure option EnableLegacyTimestampBehavior (values Kind - DateTime Postgre)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services DBContex
var connectionString = builder.Configuration.GetConnectionString("DbPostgre");
builder.Services.AddDbContext<DataBaseContext>(opts => opts.UseLazyLoadingProxies()
                                                            .UseNpgsql(connectionString));

var tokenConfiguration = builder.Configuration.GetSection("TokenConfiguration").Get<TokenConfiguration>();
builder.Services.Configure<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration"));

// Add services to the container dependecy inject. (Services)
builder.Services.AddTransient<AuthTokenService>();
builder.Services.AddTransient<ProfileService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<PermissionService>();
builder.Services.AddTransient<ProfilePermissionService>();

// Add services to the container dependecy inject. (Repositories)
builder.Services.AddTransient<IUserRepository, UserContextRepository>();
builder.Services.AddTransient<IProfileReporitory, ProfileContextRepository>();
builder.Services.AddTransient<IProfilePermissionRepository, ProfilePermissionContextRepository>();
builder.Services.AddTransient<IPermissionRepository, PermissionContextRepository>();

// Add mappers
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    //opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD BASIC", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Add service JWT
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
    
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        
       // ValidateIssuer = true,
       // ValidateAudience = true,
       // ValidateLifetime = true,
       // RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecurityKey))
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jwt Token V1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
