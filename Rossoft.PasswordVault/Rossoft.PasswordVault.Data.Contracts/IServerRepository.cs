using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Data.Contracts
{
    public interface IServerRepository : IRepository<Server>
    {
        IEnumerable<Server> GetForCompany(int companyId);
        string Encrypt(string input, byte[] Key, byte[] IV);
        string Decrypt(string input, byte[] Key, byte[] IV);

    }
}
