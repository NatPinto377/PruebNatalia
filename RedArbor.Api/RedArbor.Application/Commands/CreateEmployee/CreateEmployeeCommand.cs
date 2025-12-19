using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RedArbor.Application.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
        int CompanyId,
        string Email,
        string Password,
        int PortalId,
        int RoleId,
        int StatusId,
        string Username,
        string? Name,
        string? Telephone,
        string? Fax
    ) : IRequest<int>;
}
