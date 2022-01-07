using System.Text.Json.Serialization;

namespace lda_PublicKey.Models
{
    public class SecretResponseModel
    {
        [JsonPropertyName("private-key")]
        public string PrivateKey { get; set; }

        [JsonPropertyName("public-key")]
        public string PublicKey { get; set; }
    }
    public class PublicKeyModel
    {       
        public string PublicKey { get; set; }
    }
}
