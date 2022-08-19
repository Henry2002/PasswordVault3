using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Models
{
    public class SlimContact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsPrimary { get; set; }


    }

    public class ContactInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsPrimary { get; set; }

        public int Companyid { get; set; }

        public string Notes { get; set; }

    }

    public class ContactToRemove
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}