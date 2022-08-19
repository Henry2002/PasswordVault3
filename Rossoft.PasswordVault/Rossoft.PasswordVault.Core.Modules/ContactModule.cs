
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;


namespace Rossoft.PasswordVault.Core.Modules
{
    public class ContactModule : IContactModule
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IContactRepository contactRepository;
        private readonly IPasswordVaultContext context;

        public ContactModule(IContactRepository contactRepository, ICompanyRepository companyRepository,IPasswordVaultContext context)
        {
            this.contactRepository = contactRepository;
            this.companyRepository = companyRepository;
            this.context = context;
        }

       

        public BaseResult<ContactInfo> Get(int id)
        {
            var contact = this.contactRepository.Get(id);

            var returnValue = new ContactInfo
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Notes= contact.Notes,
                Companyid = id,
                IsPrimary=contact.IsPrimary
            };

            return new BaseResult<ContactInfo>(returnValue);
        }

        public BaseResult Remove(ContactToRemove model)
        {
            this.contactRepository.Remove(this.contactRepository.Get(model.Id));
            this.context.Submit();
            return new BaseResult();
        }

        public BaseResult<string> Save(ContactInfo model)
        {
            Contact contact;
            if (model.Id == 0)
            {
                contact = new Contact();
                this.contactRepository.Add(contact);
            }
            else
            {
                contact = this.contactRepository.Get(model.Id);
            }
            var company = this.companyRepository.Get(model.Companyid);

            if (this.contactRepository.GetFullPrimaryContact(company.Id)!=null && model.IsPrimary)
            {
                return new BaseResult<string>("false");
            }
            else
            {
                contact.Name = model.Name;
                contact.Email = model.Email;
                contact.Phone = model.Phone;
                contact.Notes = model.Notes;
                contact.Company = company;
                contact.IsPrimary = model.IsPrimary;

                this.context.Submit();
                return new BaseResult<string>("true");
            }
        }

        public BaseResult MakePrimaryContact(ContactInfo model)
        {
            Contact newPrimaryContact;
            if (model.Id == 0)
            {
                newPrimaryContact = new Contact();
                this.contactRepository.Add(newPrimaryContact);
            }
            else
            {
                newPrimaryContact = this.contactRepository.Get(model.Id);
            }
            Contact oldPrimaryContact;
            var oldPrimary = this.contactRepository.GetFullPrimaryContact(model.Companyid);
            if (oldPrimary.Name!=null)
            {
                oldPrimary.IsPrimary = false;

            }
            newPrimaryContact.Name = model.Name;
            newPrimaryContact.Email = model.Email;
            newPrimaryContact.Phone = model.Phone;
            newPrimaryContact.Notes = model.Notes;
            newPrimaryContact.Company = this.companyRepository.Get(model.Companyid);
            newPrimaryContact.IsPrimary = true;

            this.context.Submit();
            return new BaseResult();


        }
        public BaseResult<SlimContact> GetPrimaryContact(int companyId)
        {
            SlimContact returnValue;
            var contact = this.contactRepository.GetFullPrimaryContact(companyId);
            if (contact == null)
            {
                returnValue = new SlimContact
                {
                    Name = "No Primary Contact",
                    Email = string.Empty,
                    Phone = "-",
                    Id = 0,
                };
            } else
            {
                returnValue = new SlimContact
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Id = contact.Id,
                };
            }
            return new BaseResult<SlimContact>(returnValue);
        }

        public BaseResult<IList<SlimContact>> GetSlimContacts(int companyId)
        {
            IList<SlimContact> returnValue = this.contactRepository.GetForCompany(companyId)
                .Select(x => new SlimContact
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    IsPrimary = x.IsPrimary,
                }).ToList();

            return new BaseResult<IList<SlimContact>>(returnValue);

        }



    }


    }
