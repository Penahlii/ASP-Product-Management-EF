using ProductManagementDomainLayer.Entities.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementDataAccess.Repositories.Abstracts
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task AddAsync(T entity);
        Task SaveAsync();
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
