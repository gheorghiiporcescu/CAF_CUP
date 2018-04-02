using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using CAF_CUP.EntityFramework;

namespace CAF_CUP
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(CAF_CUPCoreModule))]
    public class CAF_CUPDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CAF_CUPDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
