using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Repository.WriteRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.WriteRepositoryService.Rpository
{
    public class WriteRepository : IWriteRepository
    {
        private readonly IdentityDbContext _appContext;

        public WriteRepository(IdentityDbContext appContext)
        {
            _appContext = appContext;
        }

        public T Create<T>(T entity, Guid CreatedBy, DateTime CreateOn) where T : class, IEntity
        {
            try
            {
                DefaultParams(entity, CreatedBy, true);
                var results = _appContext.Set<T>().Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> CreateAsync<T>(T entity, Guid CreatedBy) where T : class, IEntity
        {
            DefaultParams(entity, CreatedBy, true);
            var results = await _appContext.Set<T>().AddAsync(entity);
            return entity;
        }

        private void DefaultParams<T>(T entity, Guid CreatedBy, bool isCreate = true) where T : class, IEntity
        {
            if (isCreate)
            {
                entity.CreatedBy = CreatedBy;
                entity.CreatedOn = DateTime.Now;
            }
            entity.ModifyBy = CreatedBy;
            entity.ModifyOn = DateTime.Now;
        }

        public async Task DeleteAsync<T>(Guid id, Guid ModifyBy) where T : class, IEntity
        {
            var entity = await _appContext.Set<T>().FindAsync(id);
            entity.IsDeleted = true;
            List<string> ignuor = new List<string>();
            Update<T>(entity, ModifyBy, ignuor);

        }

        public void Update<T>(T entity, Guid ModifyBy, IEnumerable<string> ignuor) where T : class, IEntity
        {
            DefaultParams<T>(entity, ModifyBy, false);
            _appContext.Entry(entity).CurrentValues.SetValues(entity);
        }

        public void UpdateAsync<T>(T entity, Guid ModifyBy, IEnumerable<string> ignuor) where T : class, IEntity
        {
            DefaultParams<T>(entity, ModifyBy, false);
            _appContext.Set<T>().Update(entity).State = EntityState.Modified;
            _appContext.Entry(entity).CurrentValues.SetValues(entity);
        }
    }
}
