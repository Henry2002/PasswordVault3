using Rossoft.PasswordVault.Core.Models;
using Rossoft.PasswordVault.Data.Contracts;
using Rossoft.PasswordVault.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace Rossoft.PasswordVault.Data.Repositories
{
    public class ServerRepository : BaseRepository<Server>, IServerRepository
    {
        private byte[] Key;
        public ServerRepository(IPasswordVaultContext context) : base(context)
        {
            this.Key = Encoding.ASCII.GetBytes("T8Gr4Rfm11LayTkLcZFmNq4f");
        }
        public IEnumerable<Server> GetForCompany(int companyId)
        {
            var servers = base.GetAll().Where(x => x.Company.Id == companyId);
            return servers;
        }

        

        public string Encrypt(string input, byte[] Key, byte[] IV)
        {

            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {

                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(input);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string cipherText, byte[] Key, byte[] IV)
        {
            try
            {
                string plaintext = null;
                using (AesManaged aes = new AesManaged())
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cs))
                                plaintext = reader.ReadToEnd();
                        }
                    }
                }
                return plaintext;
            }catch
            {
                return cipherText;
            }
        }


    }
}
