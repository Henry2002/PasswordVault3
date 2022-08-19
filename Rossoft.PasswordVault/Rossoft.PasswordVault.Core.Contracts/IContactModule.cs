using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Contracts
{
    public interface IContactModule
    {

        BaseResult<ContactInfo> Get(int id);

        BaseResult<string> Save(ContactInfo model);
        BaseResult Remove(ContactToRemove contact);
 
        BaseResult<IList<SlimContact>> GetSlimContacts(int companyId);

        BaseResult MakePrimaryContact(ContactInfo model);

    }
}