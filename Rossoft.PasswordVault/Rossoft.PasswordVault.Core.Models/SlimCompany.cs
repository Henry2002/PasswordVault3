using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Models
{
    public class SlimCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }

        public string Notes { get; set; }

        public string PrimaryContactName { get; set; }

        public string PrimaryContactPhonenumber { get; set; }
    }

    public class CompanyInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Notes { get; set; }


        public IList<SlimContact> Contacts { get; set; }

        public IList<SlimServer> Servers { get; set; }
    }

    public class SaveCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Notes { get; set; }
    }
}