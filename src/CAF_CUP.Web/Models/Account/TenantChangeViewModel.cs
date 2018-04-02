using Abp.AutoMapper;
using CAF_CUP.Sessions.Dto;

namespace CAF_CUP.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}