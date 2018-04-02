using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CAF_CUP.MultiTenancy;

namespace CAF_CUP.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}