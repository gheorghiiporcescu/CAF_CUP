using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CAF_CUP.Roles.Dto;

namespace CAF_CUP.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
