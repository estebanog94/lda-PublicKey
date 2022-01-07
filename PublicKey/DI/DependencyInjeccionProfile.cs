using Amazon.SecretsManager;
using lda_PublicKey.Application;
using lda_PublicKey.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace lda_PublicKey.DI
{
    public static class DependencyInjeccionProfile
    {
        public static IServiceCollection AddDependencyInjeccion(this IServiceCollection service, IConfiguration configuration)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));

            #region Aplication
            service.AddTransient<IPublicKey, PublicKeyAppService>();
            #endregion

            #region Infrastructure
            var awsOptions = configuration.GetAWSOptions();
            service.AddDefaultAWSOptions(awsOptions)
                   .AddAWSService<IAmazonSecretsManager>()
                   .AddAWSService<Amazon.EventBridge.IAmazonEventBridge>();
            #endregion
            return service;
        }
    }
}
