using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using CAF_CUP.Authorization.Users;
using CAF_CUP.MultiTenancy;
using CAF_CUP.Users;
using Microsoft.AspNet.Identity;

namespace CAF_CUP
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class CAF_CUPAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected CAF_CUPAppServiceBase()
        {
            LocalizationSourceName = CAF_CUPConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}