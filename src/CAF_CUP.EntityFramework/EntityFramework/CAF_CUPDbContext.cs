using System.Data.Common;
using Abp.Zero.EntityFramework;
using CAF_CUP.Authorization.Roles;
using CAF_CUP.Authorization.Users;
using CAF_CUP.MultiTenancy;

namespace CAF_CUP.EntityFramework
{
    public class CAF_CUPDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CAF_CUPDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CAF_CUPDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CAF_CUPDbContext since ABP automatically handles it.
         */
        public CAF_CUPDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CAF_CUPDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public CAF_CUPDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
