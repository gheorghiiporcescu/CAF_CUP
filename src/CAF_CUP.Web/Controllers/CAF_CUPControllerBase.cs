using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace CAF_CUP.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class CAF_CUPControllerBase : AbpController
    {
        protected CAF_CUPControllerBase()
        {
            LocalizationSourceName = CAF_CUPConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}