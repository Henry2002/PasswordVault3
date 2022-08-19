namespace Rossoft.PasswordVault.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual IList<Server> Servers { get; set; }
        public virtual IList<Contact> Contacts { get; set; }
        public string Notes { get; set; }  
    }
}