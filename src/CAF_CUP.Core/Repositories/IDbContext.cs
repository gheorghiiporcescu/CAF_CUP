#region Using

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Cleaning.Core.Domain;

#endregion

namespace CAF_CUP.Repositories {
    public interface IDbContext {
        Database Database { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object entity);
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}