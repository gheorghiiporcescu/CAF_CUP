using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CAF_CUP.EntityFramework;

namespace CAF_CUP.Migrator
{
    [DependsOn(typeof(CAF_CUPDataModule))]
    public class CAF_CUPMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<CAF_CUPDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}