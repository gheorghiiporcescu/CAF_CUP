using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CAF_CUP.MultiTenancy.Dto;

namespace CAF_CUP.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
