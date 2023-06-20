using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.DAL.Repositories;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Mapping;
using PruebaCrud.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection String
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PruebaCrudContext>
    (options => options.UseSqlServer(connString).EnableSensitiveDataLogging());
#endregion

#region Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
#endregion

#region Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
#endregion

#region Mapper
//Mapper
builder.Services.AddAutoMapper(typeof(PruebaCrudProfile));
#endregion

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

app.Run();
