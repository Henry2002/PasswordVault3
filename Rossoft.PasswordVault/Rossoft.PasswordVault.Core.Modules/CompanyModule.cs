
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Modules
{
    public class CompanyModule : ICompanyModule
    {
        private readonly IServerRepository serverRepository;
        private readonly IContactRepository contactRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IPasswordVaultContext context;

        public CompanyModule(IServerRepository serverRepository, IContactRepository contactRepository,ICompanyRepository companyRepository, IPasswordVaultContext context)
        {
            this.contactRepository = contactRepository;
            this.serverRepository = serverRepository;
            this.companyRepository = companyRepository;
            this.context = context;
        }


        public BaseResult<SlimCompany> GetSlimCompany(int id)
        {

                var company = this.companyRepository.Get(id);

                var returnValue = new SlimCompany
                {
                    Id = company.Id,
                    Name = company.Name,
                    Active = company.Active,
                    Notes = company.Notes,
                };
            return new BaseResult<SlimCompany>(returnValue);
        }

            
        

        public BaseResult<IEnumerable<SlimCompany>> GetSlimCompanies(bool includeInactive)
        {
            IEnumerable<Company> companies; 

            if (!includeInactive)
            {
                companies = this.companyRepository.GetActiveCompaniesOrderedByName();
            }
            else
            {
                companies = this.companyRepository.GetAllOrderedByName();
            }
            
                 var returnValue = companies.Select(x => new SlimCompany
                {
                    Id = x.Id,
                    Name = x.Name,
                    Active = x.Active,
                    Notes = x.Notes,
                    PrimaryContactName = this.contactRepository.GetFullPrimaryContact(x.Id).Name,
                    PrimaryContactPhonenumber = this.contactRepository.GetFullPrimaryContact(x.Id).Phone
                }).ToList();
            
            return new BaseResult<IEnumerable<SlimCompany>>(returnValue);            
        }

        public BaseResult Remove(int id)
        {
           this.companyRepository.Remove(this.companyRepository.Get(id));
           this.context.Submit();
            return new BaseResult();
        }

        public BaseResult Save(SaveCompany model)
        {
            Company company;
            if (model.Id == 0)
            {
                company = new Company();
                this.companyRepository.Add(company);
            }
            else
            {
                company = this.companyRepository.Get(model.Id);
            }
            
            company.Name = model.Name;
            company.Active = model.Active;
            company.Notes= model.Notes;
            this.context.Submit();
            return new BaseResult();
        }

    }

    
}