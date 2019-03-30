using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.WriteRepositoryService.Interface
{
    public interface IWriteRepository
    {
        T Create<T>(T entity, Guid CreatedBy, DateTime CreateOn) where T : class, IEntity;
        Task<T> CreateAsync<T>(T entity, Guid CreatedBy) where T : class, IEntity;
        Task DeleteAsync<T>(Guid id, Guid ModifyBy) where T : class, IEntity;
        void Update<T>(T entity, Guid ModifyBy, IEnumerable<string> ignuor) where T : class, IEntity;
        void UpdateAsync<T>(T entity, Guid ModifyBy, IEnumerable<string> ignuor) where T : class, IEntity;
    }
}
