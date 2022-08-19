using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rossoft.PasswordVault.Core.Modules
{
    public class SearchModule : ISearchModule
    {

        private readonly ICompanyRepository companyRepository;
        private readonly IContactRepository contactRepository;
        private readonly IServerRepository serverRepository;
        private readonly IContactModule contactModule;
        private readonly IServerModule serverModule;
        private readonly IPasswordVaultContext context;
        private readonly ICompanyModule companyModule;

        public SearchModule(IContactRepository contactRepository, ICompanyRepository companyRepository, IServerRepository serverRepository,
            IPasswordVaultContext context, IContactModule contactModule, IServerModule serverModule, ICompanyModule companyModule)
        {
            this.contactRepository = contactRepository;
            this.companyRepository = companyRepository;
            this.serverRepository = serverRepository;
            this.companyModule = companyModule;
            this.context = context;
        }


        //this needs a new model and getfullcompany needs to be removed + add in the company inactive toggle feature 
        public BaseResult<IList<SlimCompany>> Search(string searchPhrase, string searchOption)
        {
            IList<SlimCompany> results;
            switch (searchOption)
            {
                case "Company":
                    results = this.companyRepository.GetAll()
                   .Where(result => result.Name == searchPhrase)
                   .Select(x => this.companyRepository.GetSlimCompany(x.Id)).ToList(); ;
                    return new BaseResult<IList<SlimCompany>>(results);
                case "Contact":
                    results = this.contactRepository.GetAll()
                   .Where(result => result.Name == searchPhrase || result.Phone == searchPhrase || result.Email == searchPhrase)
                   .Select(x => this.companyRepository.GetSlimCompany(x.Company.Id)).ToList();
                    return new BaseResult<IList<SlimCompany>>(results);
                case "Server":
                    results = this.serverRepository.GetAll()
                   .Where(result => result.Name == searchPhrase || result.Address == searchPhrase || result.Username == searchPhrase)
                   .Select(x => this.companyRepository.GetSlimCompany(x.Company.Id)).ToList();
                    return new BaseResult<IList<SlimCompany>>(results);
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }


    } 
}
