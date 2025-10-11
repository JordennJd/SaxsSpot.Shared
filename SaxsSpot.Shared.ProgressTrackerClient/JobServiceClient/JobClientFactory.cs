
using AutoMapper;
using Grpc.Core.Interceptors;
using SaxsSpot.Shared.Contracts.Interfaces;
using SaxsSpot.Shared.ProgressTrackerClient.Interceptors;

namespace SaxsSpot.Shared.ProgressTrackerClient.JobServiceClient;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class JobClientFactory
{
    private readonly string _address;
    private readonly bool _useSsl;
    private readonly IAuthenticator _authenticator;
    
    public JobClientFactory(
        IConfiguration configuration,
        IAuthenticator authenticator)
    {
        _address = configuration["Grpc:ServerAddress"];
        _useSsl = configuration["Grpc:UseSsl"] == "true";
        _authenticator = authenticator;
    }

    public async Task<JobService.JobService.JobServiceClient> GetClientAsync(
        CancellationToken cancellationToken = default)
    {
        var channel = await CreateAuthenticatedChannelAsync(cancellationToken);
        var a =  channel.Intercept(new AuthInterceptor(_authenticator));

        return new JobService.JobService.JobServiceClient(a);
    }
    
    private async Task<GrpcChannel> CreateAuthenticatedChannelAsync(CancellationToken cancellationToken)
    {
        ChannelCredentials channelCredentials;
    
        if (_useSsl)
        {
            var callCredentials = CreateCallCredentialsAsync(cancellationToken);
            channelCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
        }
        else
        {
            channelCredentials = ChannelCredentials.Insecure;
        }
        
        var channelOptions = new GrpcChannelOptions
        {
            Credentials = channelCredentials,
            HttpHandler = new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = Timeout.InfiniteTimeSpan,
                KeepAlivePingTimeout = TimeSpan.FromSeconds(60),
                EnableMultipleHttp2Connections = true
            }
        };

        var channel = GrpcChannel.ForAddress(_address, channelOptions);

        return channel;
    }

    private CallCredentials CreateCallCredentialsAsync(CancellationToken cancellationToken)
    {
        return CallCredentials.FromInterceptor(async (context, metadata) =>
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var token = await _authenticator.GetAccessTokenAsync(cancellationToken);
            //TODO cache token
            if (!string.IsNullOrEmpty(token))
            {
                metadata.Add("authorization", $"Bearer {token}");
            }
        });
    }
    private class InsecureChannelConfigurator(IAuthenticator authenticator)
    {
        public CallCredentials CallCredentials => CallCredentials.FromInterceptor(async (context, metadata) =>
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var token = await authenticator.GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                metadata.Add("authorization", $"Bearer {token}");
            }
        });
    }
}