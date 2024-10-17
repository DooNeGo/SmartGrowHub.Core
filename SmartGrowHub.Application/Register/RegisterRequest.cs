using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Common.Password;

namespace SmartGrowHub.Application.Register;

public sealed record RegisterRequest(
    UserName UserName,
    Password Password,
    EmailAddress EmailAddress,
    NonEmptyString DisplayName);