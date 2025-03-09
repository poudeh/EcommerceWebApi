using Common.Application;
using Shop.Domain.RoleAgg.enums;

namespace Shop.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
