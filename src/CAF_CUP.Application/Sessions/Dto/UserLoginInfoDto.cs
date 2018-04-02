using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CAF_CUP.Authorization.Users;
using CAF_CUP.Users;

namespace CAF_CUP.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
