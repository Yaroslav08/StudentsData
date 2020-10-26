using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<string> CreateAsync(TEntity entity);
        Task<string> EditAsync(TEntity entity);
        Task<string> RemoveAsync(TEntity entity);
        Task<TEntity> GetByWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> GetByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetListByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetListByWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> selector);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsTrackingAsync();
        Task<int> CountAsync();
    }
}