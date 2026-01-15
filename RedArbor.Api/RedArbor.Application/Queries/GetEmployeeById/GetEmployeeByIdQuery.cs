using MediatR;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(int Id) : IRequest<Employee?>;