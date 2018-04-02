using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using CAF_CUP.Authorization;
using CAF_CUP.Authorization.Roles;
using CAF_CUP.Roles.Dto;
using CAF_CUP.Managers.Dto;
using Microsoft.AspNet.Identity;

namespace CAF_CUP.Managers
{
    [AbpAuthorize(PermissionNames.Pages_Managers)]
    public class ManagerAppService : AsyncCrudAppService<Manager, ManagerDto, long, PagedResultRequestDto, CreateManagerDto, UpdateManagerDto>, IManagerAppService
    {
        private readonly ManagerManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;

        public ManagerAppService(
            IRepository<Manager, long> repository, 
            ManagerManager userManager, 
            IRepository<Role> roleRepository, 
            RoleManager roleManager)
            : base(repository)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public override async Task<ManagerDto> Get(EntityDto<long> input)
        {
            var user = await base.Get(input);
            var userRoles = await _userManager.GetRolesAsync(user.Id);
            user.Roles = userRoles.Select(ur => ur).ToArray();
            return user;
        }

        public override async Task<ManagerDto> Create(CreateManagerDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<Manager>(input);

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;

            //Assign roles
            user.Roles = new Collection<ManagerRole>();
            foreach (var roleName in input.RoleNames)
            {
                var role = await _roleManager.GetRoleByNameAsync(roleName);
                user.Roles.Add(new ManagerRole(AbpSession.TenantId, user.Id, role.Id));
            }

            CheckErrors(await _userManager.CreateAsync(user));

            return MapToEntityDto(user);
        }

        public override async Task<ManagerDto> Update(UpdateManagerDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetManagerByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetManagerByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        protected override Manager MapToEntity(CreateManagerDto createInput)
        {
            var user = ObjectMapper.Map<Manager>(createInput);
            return user;
        }

        protected override void MapToEntity(UpdateManagerDto input, Manager user)
        {
            ObjectMapper.Map(input, user);
        }

        protected override IQueryable<Manager> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<Manager> GetEntityByIdAsync(long id)
        {
            var user = Repository.GetAllIncluding(x => x.Roles).FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }

        protected override IQueryable<Manager> ApplySorting(IQueryable<Manager> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.ManagerName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}