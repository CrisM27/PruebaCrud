using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.DAL.Repositories;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Mapping;
using PruebaCrud.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PruebaCrudContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Repositories
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<IStoreRepository, StoreRepository>();

// Services
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

builder.Services.AddAutoMapper(typeof(PruebaCrudProfile));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
