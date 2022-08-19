using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;
using System.Data.Entity;

namespace Rossoft.PasswordVault.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {

        public ContactRepository(IPasswordVaultContext context) : base(context)
        {
        }

      //remove orderby//
        public IEnumerable<Contact> GetForCompany(int companyId)
        {
            var contacts = base.GetAll().Where(x => x.Company.Id == companyId);
            return contacts;
        }

        
        public Contact GetFullPrimaryContact(int companyId)
        {
            var contact = this.GetForCompany(companyId).Where(x => x.IsPrimary).FirstOrDefault();
            if (contact == null)
            {
                return new Contact();
            }
  
            return contact;
        }

        
    }

}
