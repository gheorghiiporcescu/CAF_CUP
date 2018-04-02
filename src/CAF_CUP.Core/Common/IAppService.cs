#region Using

using CAF_CUP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

#endregion

namespace CAF_CUP.Common {
    public interface IAppServiceBase<TEntity, TEntityDto, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IBaseDto<TPrimaryKey> {
        TEntityDto Get(TPrimaryKey id);

        TEntityDto GetOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntityDto> GetAsync(TPrimaryKey id);
        Task<TOtherDto> GetAsync<TOtherDto>(TPrimaryKey id);
        Task<TOtherDto> GetOrDefaultAsync<TOtherDto>(Expression<Func<TEntity, bool>> predicate);

        Task<TEntityDto> GetOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        List<TEntityDto> GetAll();
        List<TOtherDto> GetAll<TOtherDto>();

        List<TEntityDto> GetAll(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntityDto>> GetAllAsync();
        Task<List<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TOtherDto>> GetAllAsync<TOtherDto>(Expression<Func<TEntity, bool>> predicate);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}