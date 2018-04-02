using Abp.Authorization;
using CAF_CUP.Authorization.Roles;
using CAF_CUP.Authorization.Users;

namespace CAF_CUP.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
