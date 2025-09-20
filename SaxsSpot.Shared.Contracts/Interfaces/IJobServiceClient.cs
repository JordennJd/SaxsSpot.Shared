using SaxsSpot.Shared.Contracts.Models;

namespace SaxsSpot.Shared.Contracts.Interfaces;

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