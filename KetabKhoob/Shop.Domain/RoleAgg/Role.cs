﻿using Common.Domain.Exceptions;
using System.Security;
using Common.Domain;

namespace Shop.Domain.RoleAgg;

public class Role:AggregateRoot
{
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }

    private Role()
    {
    }

    public Role(string title, List<RolePermission> permissions)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));

        Title = title;
        Permissions = permissions;
    }

    public void Edit(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title , nameof(title));
        Title = title;
    }

    public void SetPermissions(List<RolePermission> permissions)
    {
        Permissions = permissions;

    }


}