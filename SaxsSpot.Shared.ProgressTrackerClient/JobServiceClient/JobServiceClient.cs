using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Models;
using SaxsSpot.Shared.ProgressTrackerClient.Contracts.Services;

namespace SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;

public class JobServiceClient(JobClientFactory factory, IMapper mapper)  : IJobServiceClient
{
    
    public async Task<JobCommandResult> CreateJobAsync(Contracts.Models.CreateJobQuery request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<CreateJobQuery>(request);
        
        var grpcResponse = await client.CreateJobAsync(grpcRequest);
        return mapper.Map<JobCommandResult>(grpcResponse);
    }

    public async Task<JobCommandResult> StartJobAsync(Contracts.Models.StartJobQuery request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<StartJobQuery>(request);
        
        var grpcResponse = await client.StartJobAsync(grpcRequest);
        return mapper.Map<JobCommandResult>(grpcResponse);
    }

    public async Task<JobCommandResult> CompleteJobAsync(Contracts.Models.CompleteJobQuery request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<CompleteJobQuery>(request);
        
        var grpcResponse = await client.CompleteJobAsync(grpcRequest);
        return mapper.Map<Contracts.Models.JobCommandResult>(grpcResponse);
    }

    public async Task<Contracts.Models.GetJobResult> GetJobAsync(Contracts.Models.GetJobQuery request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<GetJobQuery>(request);
        
        var grpcResponse = await client.GetJobAsync(grpcRequest);
        return mapper.Map<Contracts.Models.GetJobResult>(grpcResponse);
    }

    public async Task<Contracts.Models.GetJobResult> GetNextJobAsync(Contracts.Models.GetNextJobRequest request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<GetNextJobRequest>(request);
        
        var grpcResponse = await client.GetNextJobAsync(grpcRequest);
        return mapper.Map<Contracts.Models.GetJobResult>(grpcResponse);
    }

    public async Task<Contracts.Models.GetJobsResult> GetWorkingJobsAsync(Contracts.Models.GetWorkingJobRequest request)
    {
        var client = await factory.GetClientAsync();
        var grpcRequest = mapper.Map<GetWorkingJobRequest>(request);
        
        var grpcResponse = await client.GetWorkingJobsAsync(grpcRequest);
        return mapper.Map<Contracts.Models.GetJobsResult>(grpcResponse);
    }
}