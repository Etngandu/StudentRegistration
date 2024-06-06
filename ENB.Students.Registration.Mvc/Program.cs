using AspNetCoreHero.ToastNotification;
using AutoMapper;
using ENB.Students.Registration.EF;
using ENB.Students.Registration.EF.Repositories;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Commands.CreateAcademicYear;
using ENB.Students.Registration.Mvc.Factory;
using ENB.Students.Registration.Mvc.Help;
using ENB.Students.Registration.Mvc.Middlewares;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentsRegistrationContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("StudentRegistrationCtr")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               opt =>
               {
                   opt.Password.RequiredLength = 7;
                   opt.Password.RequireDigit = false;
                   opt.Password.RequireUppercase = false;
               })
                .AddEntityFrameworkStores<StudentsRegistrationContext>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

   
});
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsFactory>();
builder.Services.AddAutoMapper(typeof(StudentsRegistrationProfile));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IAsyncAcademicYearRepository, AsyncAcademicYeartRepository>();


//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorMvc<,>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//builder.Services.AddScoped<IAsyncStaffRepository, AsyncStaffRepository>();
//builder.Services.AddScoped<IAsyncMinistryRepository, AsyncMinistryRepository>();
//builder.Services.AddScoped<IAsyncActivityRepository, AsyncActivityRepository>();
builder.Services.AddScoped<IAsyncUnitOfWorkFactory, AsyncEFUnitOfWorkFactory>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
// builder.Services.AddScoped<IValidator<CreateAcademicYearCommand>, CreateAcademicYearCommandValidator>();
//builder.Services.AddScoped<IValidator<CreateAndEditStaff>, CreateAndEditStaffValidator>();
//builder.Services.AddScoped<IValidator<CreateAndEditMinistry>, CreateAndEditMinistryValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseMiddleware<ExceptionHandlingMiddleware>();


app.Run();
