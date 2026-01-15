using Dapper;
using Microsoft.Data.SqlClient;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure.Repositories;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly string connectionString;

    public EmployeeReadRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        using var connection = new SqlConnection(connectionString);

        const string sql = "SELECT * FROM Employees WHERE DeletedOn IS NULL";
        return await connection.QueryAsync<Employee>(sql);
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(connectionString);

        const string sql = "SELECT * FROM Employees WHERE Id = @Id AND DeletedOn IS NULL";
        return await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
    }
}