using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SmartHome.Repository.IRepositories;
using System.Linq.Expressions;

namespace SmartHome.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        ///     Konstruktor s DI (Dependency Injection)
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Null DbContext");

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        /// <summary>
        ///     Vytvoření entity do DB
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        /// <summary>
        ///     Vytvoření entity do DB
        /// </summary>
        /// <param name="entity"></param>
        public async Task AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                await DbSet.AddAsync(entity);
        }

        /// <summary>
        ///     Smazání záznamu podle id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            // Entitu načteme
            var entity = GetById(id);

            // Entita nenalezena, ukončíme metodu
            if (entity == null) return;

            // Smažeme entitu
            Delete(entity);
        }

        /// <summary>
        ///     Smazání entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        /// <summary>
        ///     Načtení všech záznamů
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Vrácení DBSet pro použití sql query
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetDbSet()
        {
            return DbSet;
        }

        public IQueryable<T> GetAll<TProp>(Expression<Func<T, TProp>> selector, bool order)
        {
            if (order)
                return DbSet.OrderBy(selector);

            return DbSet.OrderByDescending(selector);
        }

        public async Task<List<T>> GetAllAsync<TProp>(Expression<Func<T, TProp>> selector, bool order)
        {
            if (order)
                return await DbSet.OrderBy(selector).ToListAsync();

            return await DbSet.OrderByDescending(selector).ToListAsync();
        }

        /// <summary>
        ///     Načtení záznamu podle Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {   
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        ///     Načtení záznamu podle id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T GetById(long id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        ///     Změna entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        /// <summary>
        ///     Změna entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) 
                DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
