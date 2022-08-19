namespace Rossoft.PasswordVault.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Company Company { get; set; }

        public bool IsPrimary { get; set; }

        public string Notes { get; set; }

    }
}