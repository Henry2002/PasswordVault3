using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;

namespace Rossoft.PasswordVault.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactModule module;
        public ContactController(IContactModule module)
        {
            this.module = module;
        }

        [HttpPost("savecontact")]

        public BaseResult<string> Save(ContactInfo contactInfo)
        {
            return this.module.Save(contactInfo);
           
        }

        [HttpPost("makeprimarycontact")]

        public BaseResult MakePrimaryContact(ContactInfo contactInfo)
        {
            return this.module.MakePrimaryContact(contactInfo);
        }

        [HttpGet("getcontact/{id}")]

        public BaseResult<ContactInfo> Get(int id)
        {
            return this.module.Get(id);
        }

        [HttpPost("remove")]

        public BaseResult Remove(ContactToRemove contact)
        {
            return this.module.Remove(contact);
        }

        [HttpGet("getslimcontacts/{companyid}")]

        public BaseResult<IList<SlimContact>> GetSlimContacts(int companyId)
        {
            return this.module.GetSlimContacts(companyId);
        }

        
    }
}