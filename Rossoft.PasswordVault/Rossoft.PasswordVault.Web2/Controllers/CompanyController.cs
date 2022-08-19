

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;

namespace Rossoft.PasswordVault.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyModule module;
        
        public CompanyController(ICompanyModule module)
        {
            this.module = module;
            
        }
        
        [HttpGet("getslimcompanies/{includeInactive}")]
        public BaseResult<IEnumerable<SlimCompany>> GetSlimCompanies(string includeInactive)
        {
            var isInactive = bool.Parse(includeInactive);
            var result = this.module.GetSlimCompanies(isInactive);
            return result ;
            
        }

        [HttpPost("save")]

        public BaseResult Save(SaveCompany saveCompany)
        {
            return this.module.Save(saveCompany);
          
        }

       
        [HttpGet("getslimcompany/{id}")]

        public BaseResult<SlimCompany> GetSlimCompany(int id)
        {
            var result =this.module.GetSlimCompany(id);
            return result;
        }

        [HttpPost("remove")]

        public BaseResult Remove(SlimCompany company)
        {
           return this.module.Remove(company.Id);
        }

       
    }
}