using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SmartHome.Repository.IRepositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        DbSet<T> GetDbSet();
        IQueryable<T> GetAll<TProp>(Expression<Func<T, TProp>> selector, bool order);
        Task<List<T>> GetAllAsync<TProp>(Expression<Func<T, TProp>> selector, bool order);
        T GetById(int id);        
        T GetById(long id);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
