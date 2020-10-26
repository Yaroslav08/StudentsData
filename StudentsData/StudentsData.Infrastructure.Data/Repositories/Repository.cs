using Microsoft.EntityFrameworkCore;
using StudentsData.Domain.Interfaces;
using StudentsData.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly StudentsDataContext db;
        public readonly DbSet<TEntity> dbSet;
        public Repository()
        {
            db = new StudentsDataContext();
            dbSet = db.Set<TEntity>();
        }

        public async Task<int> CountAsync()
        {
            return await db.Set<TEntity>().CountAsync();
        }

        public async Task<string> CreateAsync(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return await SaveAsync();
        }

        public async Task<string> EditAsync(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            return await SaveAsync();
        }

        public async Task<List<TEntity>> GetAllAsTrackingAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> selector)
        {
            return await db.Set<TEntity>().AsNoTracking().Select(selector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<TEntity> GetByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public async Task<List<TEntity>> GetListByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> GetListByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).ToListAsync();
        }

        public async Task<string> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            return await SaveAsync();
        }

        public async Task<string> SaveAsync()
        {
            return await db.SaveChangesAsync() > 0 ? "OK" : "Error";
        }
    }
}