namespace SaxsSpot.Shared.Contracts.Models;

public record JobCommandResult(
    bool IsSuccessful,
    string ErrorMessage);

public record GetJobQuery(
    string JobId);

public record ChangeJobMessageQuery(
    string JobId,
    string Message);

public record GetJobResult(
    bool IsSuccessful,
    Job Job,
    string ErrorMessage);

public record GetJobsResult(
    bool IsSuccessful,
    IReadOnlyList<Job> Jobs,
    string ErrorMessage);

public record CreateJobQuery(
    string JobId,
    string JobType,
    string Message,
    string Context);

public record StartJobQuery(
    string JobId);

public record CompleteJobQuery(
    string JobId,
    string Message,
    bool IsFailed = false);

public enum JobStatus
{
    Created = 0,
    Pending = 1,
    Running = 2,
    Completed = 3,
    Failed = 4
}

public record Job(
    string Id,
    string JobId,
    JobStatus Status,
    int Progress,
    string JobType,
    string Message,
    string Context,
    DateTime CreatedAt,
    DateTime? FinishedAt,
    string UserId);

public record SetProgressQuery(
    string JobId,
    float Progress);

public record GetNextJobRequest(
    string JobType);

public record GetWorkingJobRequest(
    string JobType);