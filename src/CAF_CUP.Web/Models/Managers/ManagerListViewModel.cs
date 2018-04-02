using System.Collections.Generic;
using CAF_CUP.Roles.Dto;
using CAF_CUP.Users.Dto;

namespace CAF_CUP.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}