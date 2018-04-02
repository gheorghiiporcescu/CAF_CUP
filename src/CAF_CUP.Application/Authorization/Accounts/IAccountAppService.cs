using System.Threading.Tasks;
using Abp.Application.Services;
using CAF_CUP.Authorization.Accounts.Dto;

namespace CAF_CUP.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
