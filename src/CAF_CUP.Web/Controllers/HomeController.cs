using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CAF_CUP.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CAF_CUPControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}