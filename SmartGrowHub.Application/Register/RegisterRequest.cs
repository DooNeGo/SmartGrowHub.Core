using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Application.Register;

public sealed record RegisterRequest(
    UserName UserName,
    Password Password,
    EmailAddress EmailAddress,
    NonEmptyString DisplayName);