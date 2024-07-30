using Microsoft.EntityFrameworkCore;
using ProductManagementDataAccess.Contexts;
using ProductManagementDataAccess.Repositories.Abstracts;
using ProductManagementDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementDataAccess.Repositories.Concretes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly ProductManagementContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(ProductManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            await _table.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id is INVALID", nameof(id));

            var entity = await _table.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Entity not found");

            _table.Remove(entity);
        }


        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id is INVALID", nameof(id));
            return await _table.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var ent = await _table.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (ent is null) throw new ArgumentNullException(nameof(entity));
            _table.Remove(ent);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _table.Update(entity);
        }
    }
}
