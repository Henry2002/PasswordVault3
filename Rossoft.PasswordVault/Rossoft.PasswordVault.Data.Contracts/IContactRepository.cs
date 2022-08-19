using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Data.Contracts
{
    public interface IContactRepository: IRepository<Contact>
    {
        IEnumerable<Contact> GetForCompany(int companyId);

        Contact GetFullPrimaryContact(int companyId);
    }
}
