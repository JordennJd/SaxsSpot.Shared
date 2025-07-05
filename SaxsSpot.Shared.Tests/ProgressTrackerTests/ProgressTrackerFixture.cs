using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaxsSpot.Shared.Authenticator.Extensions;
using SaxsSpot.Shared.ProgressTrackerClient.Extensions;

namespace SaxsSpot.Shared.UnitTests;

public class ProgressTrackerFixtureInitializer : IAsyncLifetime
{
    public IConfiguration Configuration { get; private set; }
    public IServiceProvider ServiceProvider { get; private set; }
    
    public Task InitializeAsync()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        
        var configuration = builder.Build();

        var serviceCollection = new ServiceCollection()
            .AddJobServiceClient(configuration)
            .AddAuthenticator(configuration);
        
        serviceCollection.AddSingleton<IConfiguration>(configuration);

        ServiceProvider = serviceCollection.BuildServiceProvider();
        
        return Task.CompletedTask;
    }

    public Task DisposeAsync() => Task.CompletedTask;
}

[CollectionDefinition("ProgressTrackerTests")]
public class ProgressTrackerTestsCollection : ICollectionFixture<ProgressTrackerFixtureInitializer>
{
}