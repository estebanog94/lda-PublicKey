using lda_PublicKey.Application.Contracts;
using lda_PublicKey.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using util_Common;
using utils_AwsInstances;

namespace lda_PublicKey.Application
{
    public class PublicKeyAppService : IPublicKey
    {
        #region Properties
        private readonly ISecretsManagerService _amazonSecretsManager;

        #endregion

        #region Builders        
        public PublicKeyAppService(ISecretsManagerService amazonSecretsManager)
        {
            _amazonSecretsManager = amazonSecretsManager;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResultPublyKeyResponseMode> PostPublicKey()
        {
            var response = await _amazonSecretsManager.GetSecretAsync(Constants.SECRETNAME);
            SecretResponseModel result = JsonSerializer.Deserialize<SecretResponseModel>(response);
            return new ResultPublyKeyResponseMode()
            {
                status = "SUCCES",
                data = new PublicKeyModel()
                {
                    PublicKey = EncodeBase64($"-----BEGIN PUBLIC KEY-----\n{result.PublicKey}\n-----END PUBLIC KEY-----")
                }
            };
        }

        private static string EncodeBase64(string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }
        #endregion

    }
}
