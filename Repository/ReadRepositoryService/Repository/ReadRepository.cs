using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Repository.ApplicationContext;
using Repository.ReadRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.ReadRepositoryService
{
    public class ReadRepository : IReadRepository
    {
        private readonly MyAppContext _context;

        public ReadRepository(MyAppContext context)
        {
            _context = context;
        }


        private async Task<IEnumerable<T>> ReturnData<T>(
            Expression<Func<T, bool>> filter,
           Expression<Func<T, T>> order,
            Expression<Func<T, object>>[] includeExpressions,
            int skip = 5, int take = 5) where T : class, IEntity
        {
            try
            {
                var query = _context.Set<T>().Where(filter);
                if (order != null)
                {
                    query = query.OrderBy(order);
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> filter,
            Expression<Func<T, T>> order,
            Expression<Func<T, object>>[] includeExpressions) where T : class, IEntity
        {
            try
            {
                var results = await ReturnData<T>(filter, order, includeExpressions);
                return results.Where(X => X.IsDeleted).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T>> order,
            Expression<Func<T, object>>[] includeExpressions) where T : class, IEntity
        {
            try
            {
                return await ReturnData<T>(filter, order, includeExpressions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
