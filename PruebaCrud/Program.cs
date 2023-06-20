using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using DbUp;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.DAL.Repositories;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Mapping;
using PruebaCrud.Services.Services;
using System.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;



        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<PruebaCrudContext>
            (options => options.UseSqlServer(connString));

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

#region Repositories
// Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
#endregion

#region Services
// Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddSingleton<IDbMigrationService, DbMigrationService>();
#endregion

#region Mapper
//Mapper
builder.Services.AddAutoMapper(typeof(PruebaCrudProfile));
#endregion

#region ToastNotification
// Add ToastNotification
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});
#endregion

#region DB Migrations

var entitiesAssembly = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.FullName.StartsWith("PruebaCrud.DAL"));
#endregion

var app = builder.Build();

var migrationService = app.Services.GetService<IDbMigrationService>();

migrationService.RunMigrationsFromAssembly(connString, entitiesAssembly, "Migrations");

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

        app.UseNotyf();

        app.Run();


#region Repositories

#endregion
#region Services

#endregion
#region Mapper

#endregion
#region ToastNotification

#endregion
#region DB Migrations

#endregion
