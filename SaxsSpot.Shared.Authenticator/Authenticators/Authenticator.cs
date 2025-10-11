using SaxsSpot.Shared.Contracts.Interfaces;

namespace SaxsSpot.Shared.Authenticator.Authenticators;

public class Authenticator : IAuthenticator
{
    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30");
    }

    public Task<string> RefreshTokenAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30");
    }

    public bool IsTokenExpired(string token)
    {
        return true;
    }
}