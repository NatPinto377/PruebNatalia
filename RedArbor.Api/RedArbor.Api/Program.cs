using MediatR;
using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Commands.CreateEmployee;
using RedArbor.Application.Commands.UpdateEmployee;
using RedArbor.Application.Commands.DeleteEmployee;
using RedArbor.Application.Queries.GetAllEmployees;
using RedArbor.Application.Queries.GetEmployeeById;
using RedArbor.Application.Interfaces;
using RedArbor.Infrastructure.Persistence;
using RedArbor.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly));

// Database (EF Core - WRITE)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultWriteConnection")
    ));

// Repositories
var readConnection = builder.Configuration.GetConnectionString("DefaultReadConnection");

builder.Services.AddScoped<IEmployeeReadRepository>(
    _ => new EmployeeReadRepository(readConnection!)
);

builder.Services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();