using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;
using RedArbor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace RedArbor.Infrastructure.Repositories;

public class EmployeeWriteRepository : IEmployeeWriteRepository
{
    private readonly ApplicationDbContext context;

    public EmployeeWriteRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<int> CreateAsync(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
        return employee.Id;
    }

    public async Task UpdateAsync(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee == null) return;

        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
    }
}