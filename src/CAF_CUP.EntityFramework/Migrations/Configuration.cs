using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using CAF_CUP.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace CAF_CUP.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CAF_CUP.EntityFramework.CAF_CUPDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CAF_CUP";
        }

        protected override void Seed(CAF_CUP.EntityFramework.CAF_CUPDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
