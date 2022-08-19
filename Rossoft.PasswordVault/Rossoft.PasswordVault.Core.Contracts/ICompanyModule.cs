using Rossoft.PasswordVault.Core.Models;

namespace Rossoft.PasswordVault.Core.Contracts
{
    public interface ICompanyModule
    {
        BaseResult<IEnumerable<SlimCompany>> GetSlimCompanies(bool includeInactive);

     
        BaseResult<SlimCompany> GetSlimCompany(int id);
        BaseResult Save(SaveCompany model);

        BaseResult Remove(int id);


    }
}