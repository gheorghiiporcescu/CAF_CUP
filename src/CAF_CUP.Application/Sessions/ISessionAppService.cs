using System.Threading.Tasks;
using Abp.Application.Services;
using CAF_CUP.Sessions.Dto;

namespace CAF_CUP.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
