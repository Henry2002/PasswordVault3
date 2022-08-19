using Microsoft.EntityFrameworkCore;
using Rossoft.PasswordVault.Data.Models;


namespace Rossoft.PasswordVault.Data.Contracts
{
    public interface IPasswordVaultContext : IDisposable
    {

        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Server> Servers { get; set; }
        DbSet<T> GetSet<T>() where T : class;
        void Submit();

    }
}