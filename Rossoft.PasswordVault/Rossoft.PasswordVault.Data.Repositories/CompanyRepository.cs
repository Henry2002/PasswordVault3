using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Data.Repositories
{

    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
   
        
        public CompanyRepository(IPasswordVaultContext context) : base(context)
        {
        }

 
        public IEnumerable<Company> GetActiveCompaniesOrderedByName()
        {
            return this.GetAllOrderedByName().Where(x => x.Active==true);
        }

        public IEnumerable<Company> GetAllOrderedByName()
        {
            return this.GetAll().OrderBy(y => y.Name);
        }

        public SlimCompany GetSlimCompany(int id)
        {
            var company = this.Get(id);
            return new SlimCompany
            {
                Id = company.Id,
                Name = company.Name,
                Active = company.Active,
            };
        }




    }
}