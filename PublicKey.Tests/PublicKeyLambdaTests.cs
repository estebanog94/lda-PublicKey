using System.Threading.Tasks;
using utils_Tets;
using Xunit;


namespace lda_PublicKey.Tests
{
    [Trait("Category", "Integration")]
    public class PublicKeyLambdaTests
    {
        [Fact]
        public async Task OtpController_WhenAllDependenciesAreRegister_ShouldNotThrowException()
        {
            async Task func()
            {
                await Task.Run(() => { new LambdaEntryPoint(); });
            }

            var exception = await Record.ExceptionAsync(() => CommonUtilsTets.ExecuteAsync(func));
            Assert.Null(exception);
        }
    }
}
