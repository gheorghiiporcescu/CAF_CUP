using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CAF_CUP.Roles.Dto;
using CAF_CUP.Managers.Dto;

namespace CAF_CUP.Managers
{
    public interface IManagerAppService : IAsyncCrudAppService<ManagerDto, long, PagedResultRequestDto, CreateManagerDto, UpdateManagerDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}