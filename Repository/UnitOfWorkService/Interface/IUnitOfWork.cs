using Repository.ReadRepositoryService.Interface;
using Repository.WriteRepositoryService.Interface;
using System.Threading.Tasks;

namespace Repository.UnitOfWorkService.Interface
{
    public interface IUnitOfWork
    {
        IReadRepository Read { get; set; }
        IWriteRepository Write { get; set; }
        Task<int> SaveAsync();
        int Save();
    }
}
