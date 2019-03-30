using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.ReadRepositoryService.Interface
{
    public interface IReadRepository
    {
        Task<T> GetAsync<T>(Expression<Func<T, bool>> filter,
            Expression<Func<T, T>> order,
            Expression<Func<T, object>>[] includeExpressions)
            where T : class, IEntity;

        Task<IEnumerable<T>> GetAllAsync<T>(
             Expression<Func<T, bool>> filter,
             Expression<Func<T, T>> order,
             Expression<Func<T, object>>[] includeExpressions) where T : class, IEntity;

    }
}
