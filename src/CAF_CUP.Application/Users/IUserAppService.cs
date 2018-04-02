using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CAF_CUP.Roles.Dto;
using CAF_CUP.Users.Dto;

namespace CAF_CUP.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}