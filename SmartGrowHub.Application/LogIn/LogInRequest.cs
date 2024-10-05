using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Application.LogIn;

public sealed record LogInRequest(UserName UserName, Password Password)
{
    public static Fin<LogInRequest> Create(string userNameRaw, string passwordRaw) =>
        from userName in UserName.From(userNameRaw)
        from password in Password.FromPlainText(passwordRaw)
        select new LogInRequest(userName, password);
}