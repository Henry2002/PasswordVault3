namespace Rossoft.PasswordVault.Core.Models
{
    public class SlimServer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public string Notes { get; set; }
    }

    public class ServerInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }

        public string Notes { get; set; }


    }

    public class ServerToRemove
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
