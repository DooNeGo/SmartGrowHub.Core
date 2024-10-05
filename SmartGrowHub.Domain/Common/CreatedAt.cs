using SmartGrowHub.Domain.Exceptions;

namespace SmartGrowHub.Domain.Common;

public readonly record struct CreatedAt : DomainType<CreatedAt, DateOnly>
{
    private const string ErrorMessage =
        "The date must be less than or equal to today's date";

    private static readonly InvalidDateException Exception = new(ErrorMessage);
    private static readonly TimeProvider TimeProvider = TimeProvider.System;

    private readonly DateOnly _value;

    private CreatedAt(DateOnly date) => _value = date;

    public static implicit operator DateOnly(CreatedAt createdAt) => createdAt.To();
    public static explicit operator CreatedAt(DateOnly date) => From(date).ThrowIfFail();

    public static Fin<CreatedAt> From(DateOnly rawValue) =>
        rawValue <= DateOnly.FromDateTime(TimeProvider.GetUtcNow().Date)
            ? new CreatedAt(rawValue) : FinFail<CreatedAt>(Exception);

    public DateOnly To() => _value;

    public override string ToString() => _value.ToString();
}