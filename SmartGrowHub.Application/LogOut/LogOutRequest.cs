using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Model;

namespace SmartGrowHub.Application.LogOut;

public sealed record LogOutRequest(Id<UserSession> Id);
