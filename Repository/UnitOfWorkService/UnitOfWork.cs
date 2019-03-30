using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Repository.ReadRepositoryService.Interface;
using Repository.UnitOfWorkService.Interface;
using Repository.WriteRepositoryService.Interface;
using System;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReadRepository Read { get; set; }
        private IdentityDbContext _UnitOfWork { get; set; }
        public IWriteRepository Write { get; set; }

        public UnitOfWork(
            IReadRepository Read, IWriteRepository Write,
            IdentityDbContext UnitOfWork)
        {
            this.Write = Write;
            this.Read = Read;
            _UnitOfWork = UnitOfWork;

        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save()
        {
            try
            {
                return _UnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
