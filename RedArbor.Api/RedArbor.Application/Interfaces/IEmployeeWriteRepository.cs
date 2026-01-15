using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interfaces
{
    public interface IEmployeeWriteRepository
    {
        Task<int> CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
