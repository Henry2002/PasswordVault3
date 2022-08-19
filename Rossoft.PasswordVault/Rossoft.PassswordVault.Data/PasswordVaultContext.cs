
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PassswordVault.Data
{
    public class PasswordVaultContext :ApiAuthorizationDbContext<ApplicationUser>, IPasswordVaultContext
    {
        public PasswordVaultContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<T> GetSet<T>() where T : class
        {
            return this.Set<T>();
        }

        public void Submit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}