using Grpc.Core;
using Grpc.Core.Interceptors;
using SaxsSpot.Shared.Authenticator.Contracts;

namespace SaxsSpot.Shared.ProgressTrackerClient.Interceptors;

public class AuthInterceptor(IAuthenticator authenticator) : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        return new AsyncUnaryCall<TResponse>(
            InternalAsync(request, context, continuation),
            responseHeadersAsync: null,
            getStatusFunc: null,
            getTrailersFunc: null,
            disposeAction: null);
    }

    private async Task<TResponse> InternalAsync<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        where TRequest : class
        where TResponse : class
    {
        // Асинхронно получаем токен
        var token = await authenticator.GetAccessTokenAsync();
        
        var metadata = new Metadata
        {
            { "authorization", $"Bearer {token}" }
        };

        var newContext = new ClientInterceptorContext<TRequest, TResponse>(
            context.Method,
            context.Host,
            context.Options.WithHeaders(metadata));

        return await continuation(request, newContext);
    }
}