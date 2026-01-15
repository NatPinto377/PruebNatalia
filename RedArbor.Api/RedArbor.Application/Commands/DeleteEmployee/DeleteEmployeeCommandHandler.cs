using MediatR;
using RedArbor.Application.Interfaces;

namespace RedArbor.Application.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;

    public DeleteEmployeeCommandHandler(
        IEmployeeWriteRepository employeeWriteRepository)
    {
        this.employeeWriteRepository = employeeWriteRepository;
    }

    public async Task Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await employeeWriteRepository.DeleteAsync(request.Id);
    }
}