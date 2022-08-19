namespace Rossoft.PasswordVault.Data.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public virtual Company Company { get; set; }

        public byte[] IV { get; set; }

        public string Notes { get; set; }

    }
}