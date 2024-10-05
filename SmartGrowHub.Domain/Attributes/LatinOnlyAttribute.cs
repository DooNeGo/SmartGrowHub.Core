using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartGrowHub.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed partial class LatinOnlyAttribute(string errorMessage) : ValidationAttribute
{
    private readonly ValidationResult _failResult = new(errorMessage);
    private readonly Error Error = Error.New(errorMessage);

    public Fin<string> IsValid(string value) => GetLatinRegex().IsMatch(value)
        ? value : FinFail<string>(Error);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) =>
        IsValid(value?.ToString() ?? string.Empty).Match(
            Succ: value => ValidationResult.Success,
            Fail: error => _failResult);

    [GeneratedRegex(@"^[a-zA-Z0-9!@#$%^&*()\-_=+\[\]{}|\\:;""'<>,.?/~]*$", RegexOptions.Compiled)]
    private static partial Regex GetLatinRegex();
}