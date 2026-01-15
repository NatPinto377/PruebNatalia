using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interfaces;

public interface IEmployeeReadRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
}