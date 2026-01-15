using MediatR;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeeReadRepository employeeReadRepository;

    public GetEmployeeByIdQueryHandler(
        IEmployeeReadRepository employeeReadRepository)
    {
        this.employeeReadRepository = employeeReadRepository;
    }

    public async Task<Employee?> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await employeeReadRepository.GetByIdAsync(request.Id);
    }
}