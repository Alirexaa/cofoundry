﻿namespace Cofoundry.Domain
{
    /// <summary>
    /// Permission to update a role.
    /// </summary>
    public class RoleUpdatePermission : IEntityPermission
    {
        public RoleUpdatePermission()
        {
            EntityDefinition = new RoleEntityDefinition();
            PermissionType = CommonPermissionTypes.Update("Roles");
        }

        public IEntityDefinition EntityDefinition { get; private set; }
        public PermissionType PermissionType { get; private set; }
    }
}