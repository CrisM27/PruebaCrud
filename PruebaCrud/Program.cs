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


// Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();

// Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();

//Mapper
builder.Services.AddAutoMapper(typeof(PruebaCrudProfile));

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

app.Run();
