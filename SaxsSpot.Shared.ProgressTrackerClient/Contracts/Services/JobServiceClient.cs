

namespace SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;

using Contracts.Models;

public interface IJobServiceClient
{
    Task<JobCommandResult> ChangeJobMessageAsync(ChangeJobMessageQuery request);
    Task<JobCommandResult> CreateJobAsync(CreateJobQuery request);
    Task<JobCommandResult> StartJobAsync(StartJobQuery request);
    Task<JobCommandResult> CompleteJobAsync(CompleteJobQuery request);
    Task<GetJobResult> GetJobAsync(GetJobQuery request);
    Task<GetJobResult> GetNextJobAsync(GetNextJobRequest request);
    Task<GetJobsResult> GetWorkingJobsAsync(GetWorkingJobRequest request);
}