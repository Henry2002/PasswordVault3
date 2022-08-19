using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Models;

namespace Rossoft.PasswordVault.Core.Contracts
{
    public interface IServerModule
    {
        BaseResult<ServerInfo> Get(int id);

        BaseResult Save(ServerInfo model);
        BaseResult Remove(ServerToRemove server);
        BaseResult<IList<SlimServer>> GetSlimServers(int companyId);
    }
}
