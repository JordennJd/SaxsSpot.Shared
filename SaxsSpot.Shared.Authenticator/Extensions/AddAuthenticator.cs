using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaxsSpot.Shared.Authenticator.Contracts;

namespace SaxsSpot.Shared.Authenticator.Extensions;

public static class AddAuthenticatorExtension
{
    public static IServiceCollection AddAuthenticator(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        if (configuration["Auth:UseMock"] == "true")
        {
            serviceCollection.AddSingleton<IAuthenticator, Authenticators.Authenticator>();
        }
        // else
        // {
        //     serviceCollection.AddScoped<IJobServiceClient, JobServiceClient.JobServiceClient>();
        // }
        
        return serviceCollection;
    }
}