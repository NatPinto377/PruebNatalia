using MediatR;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;

    public CreateEmployeeCommandHandler(
        IEmployeeWriteRepository employeeWriteRepository)
    {
        this.employeeWriteRepository = employeeWriteRepository;
    }

    public async Task<int> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            CompanyId = request.CompanyId,
            Email = request.Email,
            Password = request.Password,
            PortalId = request.PortalId,
            RoleId = request.RoleId,
            StatusId = request.StatusId,
            Username = request.Username,
            Name = request.Name,
            Telephone = request.Telephone,
            Fax = request.Fax,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow
        };

        return await employeeWriteRepository.CreateAsync(employee);
    }
}