using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CAF_CUP.EntityFramework.Repositories
{
    public abstract class CAF_CUPRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CAF_CUPDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CAF_CUPRepositoryBase(IDbContextProvider<CAF_CUPDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CAF_CUPRepositoryBase<TEntity> : CAF_CUPRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CAF_CUPRepositoryBase(IDbContextProvider<CAF_CUPDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
