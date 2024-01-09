using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Repositories.Generic
{
    public class GenericRepository<T> : IDisposable,IGenericRepository<T>, IAsyncDisposable where T : SeedEntity 
    {
        private readonly DefaultDbContext _context;

        public GenericRepository(DefaultDbContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet => _context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync(bool relations = false)
        {
            IQueryable<T> queryable = DbSet.AsQueryable();

            if (relations)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                    queryable = queryable.Include(property.Name);

            }

            List<T> entities = await queryable.ToListAsync();

            return entities;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool relations = false)
        {
            IQueryable<T> queryable = DbSet.AsQueryable();

            if (relations && _context.Model.FindEntityType(typeof(T)) != null)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                    queryable = queryable.Include(property.Name);

            }

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public bool Exist(Expression<Func<T, bool>>? predicate = null)
        {

            return predicate == null ? DbSet.Any() : DbSet.Any(predicate);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync() > 0);

            }
            catch
            {
                return false;
            }
        }

        public void PostAsync(T t)
        {
            DbSet.Add(t);
        }

        public void PutAsync(T t)
        {
            DbSet.Update(t);
        }

        public void Delete(T t)
        {
            DbSet.Remove(t);
        }

        public async void Delete(int id)
        {
            Delete(await GetAsync(x => x.Id == id));
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }



    }
}
