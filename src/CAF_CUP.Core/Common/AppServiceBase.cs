#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CAF_CUP.Repositories;
using System.Data;

#endregion

namespace CAF_CUP.Common {
    public class AppServiceBase<TEntity, TEntityDto, TPrimaryKey> : IAppServiceBase<TEntity, TEntityDto, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IBaseDto<TPrimaryKey> {
        protected readonly IRepository<TEntity, TPrimaryKey> Repository;
        private IAppServiceBase<TEntity, TEntityDto, TPrimaryKey> _appServiceBaseImplementation;

        public AppServiceBase(IRepository<TEntity, TPrimaryKey> repository) {
            Repository = repository;
        }

        #region IAppServiceBase<TEntity,TEntityDto,TPrimaryKey> Members

        public TEntityDto Get(TPrimaryKey id) {
            var entityDto = Repository.GetDto<TEntityDto>(id);

            if (entityDto == null) {
                throw new ObjectNotFoundException();
            }

            return entityDto;
        }




        public async Task<TEntityDto> GetAsync(TPrimaryKey id)
        {
            return await GetAsync<TEntityDto>(id);
        }

        public async Task<TOtherDto> GetAsync<TOtherDto>(TPrimaryKey id)
        {
            var entityDto = await Repository.GetDtoAsync<TOtherDto>(id);

            if (entityDto == null)
            {
                throw new ObjectNotFoundException();
            }

            return entityDto;
        }



        public TEntityDto GetOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return Repository.GetDtoOrDefault<TEntityDto>(predicate);
        }

        public async Task<TEntityDto> GetOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetOrDefaultAsync<TEntityDto>(predicate);
        }

        public async Task<TOtherDto> GetOrDefaultAsync<TOtherDto>(Expression<Func<TEntity, bool>> predicate) {
            return await Repository.GetDtoOrDefaultAsync<TOtherDto>(predicate);
        }

        public List<TEntityDto> GetAll() {
            return Repository.GetAllDtos<TEntityDto>();
        }

        public List<TOtherDto> GetAll<TOtherDto>()
        {
            return Repository.GetAllDtos<TOtherDto>();
        }

        public List<TEntityDto> GetAll(Expression<Func<TEntity, bool>> predicate) {
            return Repository.GetAllDtos<TEntityDto>(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Count(predicate);
        }

        public async Task<List<TEntityDto>> GetAllAsync() {
            return await Repository.GetAllDtosAsync<TEntityDto>();
        }

        public async Task<List<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) {
            return await Repository.GetAllDtosAsync<TEntityDto>(predicate);
        }

        public async Task<List<TOtherDto>> GetAllAsync<TOtherDto>(Expression<Func<TEntity, bool>> predicate) {
            return await Repository.GetAllDtosAsync<TOtherDto>(predicate);
        }

        public void Delete(TPrimaryKey id) {
            Repository.Delete(Repository.Get(id));
        }

        public async Task DeleteAsync(TPrimaryKey id) {
            await Repository.DeleteAsync(await Repository.GetAsync(id));
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Repository.DeleteAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate) {
            return Repository.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
            return await Repository.AnyAsync(predicate);
        }


        #endregion
    }
}