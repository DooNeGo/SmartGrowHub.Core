using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Common.Password;

namespace SmartGrowHub.Application.LogIn;

public sealed record LogInRequest(UserName UserName, PlainTextPassword Password)
{
    public static Fin<LogInRequest> New(string userNameRaw, string passwordRaw) =>
        from userName in UserName.From(userNameRaw)
        from password in PlainTextPassword.From(passwordRaw)
        select new LogInRequest(userName, password);
}