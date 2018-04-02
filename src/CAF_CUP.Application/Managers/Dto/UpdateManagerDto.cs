using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Managers;
using Abp.AutoMapper;
using CAF_CUP.Authorization.Managers;

namespace CAF_CUP.Managers.Dto
{
    [AutoMapTo(typeof(Manager))]
    public class UpdateManagerDto: EntityDto<long>
    {
        [Required]
        [StringLength(AbpManagerBase.MaxManagerNameLength)]
        public string ManagerName { get; set; }

        [Required]
        [StringLength(AbpManagerBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpManagerBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpManagerBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }
    }
}