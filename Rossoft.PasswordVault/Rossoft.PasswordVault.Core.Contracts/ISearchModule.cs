using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Contracts
{
    public interface ISearchModule
    {
        BaseResult<IList<SlimCompany>> Search(string searchPhrase,string searchOption);
    }
}
