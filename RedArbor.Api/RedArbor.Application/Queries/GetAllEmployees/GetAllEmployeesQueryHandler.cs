using MediatR;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Queries.GetAllEmployees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeReadRepository employeeReadRepository;

    public GetAllEmployeesQueryHandler(
        IEmployeeReadRepository employeeReadRepository)
    {
        this.employeeReadRepository = employeeReadRepository;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await employeeReadRepository.GetAllAsync();
    }
}