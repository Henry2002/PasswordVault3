using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rossoft.PassswordVault.Data;
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        ISearchModule searchModule;
        public SearchController(ISearchModule searchModule)
        {
            this.searchModule=searchModule;
        }

        [HttpGet("search/{searchphrase}/{searchoption}")]
        public BaseResult<IList<SlimCompany>> Search(string searchPhrase,string searchOption)
        {
            return this.searchModule.Search(searchPhrase,searchOption);
        }
    }
}