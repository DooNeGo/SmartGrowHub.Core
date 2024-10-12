using SmartGrowHub.Application.LogIn;
using SmartGrowHub.Application.LogOut;
using SmartGrowHub.Application.RefreshTokens;
using SmartGrowHub.Application.Register;

namespace SmartGrowHub.Application.Services;

public interface IAuthService
{
    Eff<LogInResponse> LogIn(LogInRequest request, CancellationToken cancellationToken);
    Eff<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken);
    Eff<LogOutResponse> LogOut(LogOutRequest request, CancellationToken cancellationToken);
    Eff<RefreshTokensResponse> RefreshTokens(RefreshTokensRequest request, CancellationToken cancellationToken);
}