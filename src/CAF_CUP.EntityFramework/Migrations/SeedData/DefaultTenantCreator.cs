using System.Linq;
using CAF_CUP.EntityFramework;
using CAF_CUP.MultiTenancy;

namespace CAF_CUP.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly CAF_CUPDbContext _context;

        public DefaultTenantCreator(CAF_CUPDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
