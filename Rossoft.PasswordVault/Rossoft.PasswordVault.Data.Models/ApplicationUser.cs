using Microsoft.AspNetCore.Identity;


namespace Rossoft.PasswordVault.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public string Forename { get; set; }
        [PersonalData]
        public string Surname { get; set; } 
    }
}


