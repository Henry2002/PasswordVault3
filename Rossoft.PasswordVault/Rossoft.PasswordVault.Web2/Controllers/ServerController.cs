using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rossoft.PassswordVault.Data;
using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;


namespace Rossoft.PasswordVault.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        private IServerModule module;
        public ServerController(IServerModule module)
        {
            this.module = module;
        }


        [HttpPost("saveserver")]

        public BaseResult Save(ServerInfo serverInfo)
        {
            return this.module.Save(serverInfo);
        }

        [HttpGet("getserver/{id}")]

        public BaseResult<ServerInfo> Get(int id)
        {
            return this.module.Get(id);
        }

        [HttpPost("removeserver")]

        public BaseResult Remove(ServerToRemove server)
        {
           return this.module.Remove(server);
        }

        [HttpGet("getslimservers/{companyid}")]

        public BaseResult<IList<SlimServer>> GetSlimServers(int companyId)
        {
            return this.module.GetSlimServers(companyId);
        }
    }
}