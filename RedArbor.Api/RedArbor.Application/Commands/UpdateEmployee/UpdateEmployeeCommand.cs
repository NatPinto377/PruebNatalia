using MediatR;

namespace RedArbor.Application.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int PortalId { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
    public string Username { get; set; } = string.Empty;

    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public string? Fax { get; set; }
}