using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Data.Contracts
{
    public interface ICompanyRepository : IRepository<Company> { 
    
        IEnumerable<Company> GetAllOrderedByName();
        IEnumerable<Company> GetActiveCompaniesOrderedByName();

        SlimCompany GetSlimCompany(int id);
    }
}