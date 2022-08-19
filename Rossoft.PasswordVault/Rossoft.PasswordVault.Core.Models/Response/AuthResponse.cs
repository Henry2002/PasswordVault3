using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rossoft.PasswordVault.Core.Models.Response
{
    public class AuthResponse
    {
        public object Token { get; set; }
        public string UserId { get; set; }
    }
}
