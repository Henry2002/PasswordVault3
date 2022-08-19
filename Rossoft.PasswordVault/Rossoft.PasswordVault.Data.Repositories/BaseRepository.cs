using Rossoft.PasswordVault.Data.Contracts;

namespace Rossoft.PasswordVault.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IPasswordVaultContext context;

        public BaseRepository(IPasswordVaultContext context)
        {
            this.context = context;
        }

        public void Add(T item)
        {
            this.context.GetSet<T>().Add(item);
        }

        public T Get(object id)
        {
            return this.context.GetSet<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.context.GetSet<T>().AsQueryable();
        }

        public void Remove(T item)
        {
            this.context.GetSet<T>().Remove(item);
        }
    }
}