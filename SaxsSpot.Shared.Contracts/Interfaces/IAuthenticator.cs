namespace SaxsSpot.Shared.Contracts.Interfaces;

public interface IAuthenticator
{
    Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
    Task<string> RefreshTokenAsync(CancellationToken cancellationToken = default);
    bool IsTokenExpired(string token);
}