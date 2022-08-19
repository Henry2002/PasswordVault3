using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Data.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(object id);

        void Add(T item);

        void Remove(T item);
        
    }
}