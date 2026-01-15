using MediatR;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;

    public UpdateEmployeeCommandHandler(
        IEmployeeWriteRepository employeeWriteRepository)
    {
        this.employeeWriteRepository = employeeWriteRepository;
    }

    public async Task Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Id = request.Id,
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
            UpdatedOn = DateTime.UtcNow
        };

        await employeeWriteRepository.UpdateAsync(employee);
    }
}