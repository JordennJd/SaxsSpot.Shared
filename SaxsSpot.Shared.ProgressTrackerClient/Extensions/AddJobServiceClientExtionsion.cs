using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;
using SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;
using SaxsSpot.Shared.ProgressTrackerClient.Mapping;

namespace SaxsSpot.Shared.ProgressTrackerClient.Extensions;

public static class AddJobServiceClientExtension
{
    public static IServiceCollection AddJobServiceClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<JobClientFactory>();
        serviceCollection.AddAutoMapper(cfg => cfg.AddMaps(typeof(JobServiceProfiles).Assembly));
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