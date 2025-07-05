
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;
using SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;
using Xunit;

namespace SaxsSpot.Shared.UnitTests
{
    [Collection("ProgressTrackerTests")]
    public class ProgressTrackerTests
    {
        private readonly ProgressTrackerFixtureInitializer _fixture;

        public ProgressTrackerTests(ProgressTrackerFixtureInitializer fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ProgressTrackerCrateTest()
        {
            var client = _fixture.ServiceProvider.GetRequiredService<IJobServiceClient>();
            var jobId = "0127470f-f135-780b-9534-c3d5b59f319a";

            var job = await client.GetJobAsync(
                new ProgressTrackerClient.Contracts.Models.GetJobQuery(jobId));
        }
    }
}