using System.Collections.Generic;
using CAF_CUP.Roles.Dto;

namespace CAF_CUP.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}