using System.Linq.Expressions;

namespace WebApi.Repositories.Generic
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(bool relations = false);

        Task<T> GetAsync(Expression<Func<T, bool>>? predicate, bool relations = false);

        bool Exist(Expression<Func<T, bool>>? predicate = null);

        Task<bool> SaveChangesAsync();

        void PostAsync(T t);

        void PutAsync(T t);

        void Delete(T t);

        void Delete(int id);
    }
}
