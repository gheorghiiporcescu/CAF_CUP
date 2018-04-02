using Abp.Web.Mvc.Views;

namespace CAF_CUP.Web.Views
{
    public abstract class CAF_CUPWebViewPageBase : CAF_CUPWebViewPageBase<dynamic>
    {

    }

    public abstract class CAF_CUPWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CAF_CUPWebViewPageBase()
        {
            LocalizationSourceName = CAF_CUPConsts.LocalizationSourceName;
        }
    }
}