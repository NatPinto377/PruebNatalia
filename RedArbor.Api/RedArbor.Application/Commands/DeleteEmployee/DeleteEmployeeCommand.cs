using MediatR;

namespace RedArbor.Application.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : IRequest;