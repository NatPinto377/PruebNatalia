using MediatR;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Queries.GetAllEmployees;

public record GetAllEmployeesQuery() : IRequest<IEnumerable<Employee>>;