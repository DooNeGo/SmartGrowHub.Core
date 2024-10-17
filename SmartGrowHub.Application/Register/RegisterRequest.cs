using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Common.Password;

namespace SmartGrowHub.Application.Register;

public sealed record RegisterRequest(
    UserName UserName,
    PlainTextPassword Password,
    EmailAddress EmailAddress,
    NonEmptyString DisplayName);