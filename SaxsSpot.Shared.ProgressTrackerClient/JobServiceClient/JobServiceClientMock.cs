using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Models;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;

namespace SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;

public class JobServiceClientMock : IJobServiceClient
{
    public Task<JobCommandResult> CreateJobAsync(Contracts.Models.CreateJobQuery request)
    {
        return Task.FromResult(new JobCommandResult(true, ""));
    }

    public Task<JobCommandResult> StartJobAsync(Contracts.Models.StartJobQuery request)
    {
        return Task.FromResult(new JobCommandResult(true, ""));
    }

    public Task<JobCommandResult> CompleteJobAsync(Contracts.Models.CompleteJobQuery request)
    {
        return Task.FromResult(new JobCommandResult(true, ""));
    }

    public Task<Contracts.Models.GetJobResult> GetJobAsync(Contracts.Models.GetJobQuery request)
    {
        return Task.FromResult(new Contracts.Models
            .GetJobResult(true, 
                null, ""));
    }

    public Task<Contracts.Models.GetJobResult> GetNextJobAsync(Contracts.Models.GetNextJobRequest request)
    {
        return Task.FromResult(new Contracts.Models
            .GetJobResult(true, 
                null, ""));    }

    public Task<Contracts.Models.GetJobsResult> GetWorkingJobsAsync(Contracts.Models.GetWorkingJobRequest request)
    {
        return Task.FromResult(new Contracts.Models
            .GetJobsResult(true, 
                [], ""));    }
}