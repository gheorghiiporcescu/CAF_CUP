using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CAF_CUP.Authorization;
using CAF_CUP.Roles;
using CAF_CUP.Web.Models.Roles;

namespace CAF_CUP.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class RolesController : CAF_CUPControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }


        public async Task<ActionResult> Index()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var role = await _roleAppService.Get(new EntityDto(roleId));
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return View("_EditRoleModal", model);
        }
    }
}