using AutoMapper;
using ENB.Students.Registration.EF;
using ENB.Students.Registration.EF.Repositories;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi;
using ENB.Students.Registration.WebApi.Factory;
using ENB.Students.Registration.WebApi.Help;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentsRegistrationContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("StudentRegistrationCtr")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               opt =>
               {
                   opt.Password.RequiredLength = 7;
                   opt.Password.RequireDigit = false;
                   opt.Password.RequireUppercase = false;
               })
                .AddEntityFrameworkStores<StudentsRegistrationContext>()
                .AddDefaultTokenProviders() ;

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);


});

//builder.Services.addm(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//builder.Services.AddScoped<IValidator<CreateAcademicYearCommand>, CreateAcademicYearCommandValidator>();

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
            ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Key").Value!))

    };
    });

builder.Services.AddScoped<IAuthService , AuthService>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsFactory>();
builder.Services.AddAutoMapper(typeof(StudentsRegistrationProfile));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IAsyncAcademicYearRepository, AsyncAcademicYeartRepository>();
builder.Services.AddScoped<IAsyncUnitOfWorkFactory, AsyncEFUnitOfWorkFactory>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
