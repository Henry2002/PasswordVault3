using Rossoft.PasswordVault.Core.Contracts;
using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace Rossoft.PasswordVault.Core.Modules
{
    public class ServerModule : IServerModule
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IServerRepository serverRepository;
        private readonly IPasswordVaultContext context;
        private byte[] Key;

        public ServerModule(IServerRepository serverRepository, ICompanyRepository companyRepository, IPasswordVaultContext context)
        {
            this.serverRepository = serverRepository;
            this.companyRepository = companyRepository;
            this.context = context;
            this.Key = Encoding.ASCII.GetBytes("T8Gr4Rfm11LayTkLcZFmNq4f");

        }



        public BaseResult<ServerInfo> Get(int id)
        {
            var server = this.serverRepository.Get(id);

            var returnValue = new ServerInfo
            {
                Id = server.Id,
                Name = server.Name,
                Address = server.Address,
                Username = server.Username,
                Notes= server.Notes,
                Password = this.serverRepository.Decrypt(server.Password, this.Key, server.IV)
            };

            return new BaseResult<ServerInfo>(returnValue);
        }

        public BaseResult Remove(ServerToRemove model)
        {
            this.serverRepository.Remove(this.serverRepository.Get(model.Id));
            this.context.Submit();
            return new BaseResult();
        }

        public BaseResult Save(ServerInfo model)
        {
            var Key = this.Key;
            var IV = GenerateIV();
            Server server;
            if (model.Id == 0)
            {
                server = new Server();
                this.serverRepository.Add(server);
            }
            else
            {
                server = this.serverRepository.Get(model.Id);
            }

            server.Name = model.Name;
            server.Address = model.Address;
            server.Username = model.Username;
            server.Company = companyRepository.Get(model.CompanyId);
            server.Password =this.serverRepository
               .Encrypt(model.Password,Key,IV);
            server.IV = IV; 
            server.Notes = model.Notes;
            this.context.Submit();
            return new BaseResult();
        }

        
        public BaseResult<IList<SlimServer>> GetSlimServers(int CompanyId)
        {
            IList<SlimServer> returnValue = this.serverRepository.GetForCompany(CompanyId)
                .Select(x => new SlimServer
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Username = x.Username,
                    Password = this.serverRepository.Decrypt(x.Password, this.Key, x.IV),
                    Notes = x.Notes,
                }).ToList();

            return new BaseResult<IList<SlimServer>>(returnValue);

        }

        private byte[] GenerateIV()
        {
            byte[] IV = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(IV);
            }
           
            return IV;
        }


    }
}