using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;
using SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;

namespace SaxsSpot.Shared.ProgressTrackerClient.Extensions;

public static class AddJobServiceClientExtension
{
    public static IServiceCollection AddJobServiceClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var domain = AppDomain.CurrentDomain.GetAssemblies();

        serviceCollection.AddSingleton<JobClientFactory>();
        serviceCollection.AddAutoMapper(cfg => cfg.AddMaps(domain));
        if (configuration["Grpc:UseMock"] == "true")
        {
            serviceCollection.AddScoped<IJobServiceClient, JobServiceClientMock>();
        }
        else
        {
            serviceCollection.AddScoped<IJobServiceClient, JobServiceClient.JobServiceClient>();
        }
        
        return serviceCollection;
    }
}