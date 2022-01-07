using lda_PublicKey.Models;
using System.Threading.Tasks;

namespace lda_PublicKey.Application.Contracts
{
    public interface IPublicKey
    {
        Task<ResultPublyKeyResponseMode> PostPublicKey();
    }
}
