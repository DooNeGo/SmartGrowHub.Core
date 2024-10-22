namespace SmartGrowHub.Domain.Extensions;

public static class TaskExtensions
{
    public static Eff<T> ToEff<T>(this Task<T> task) =>
        liftEff(() => task);

    public static Eff<Unit> ToEff(this Task task) =>
        liftEff(task.ToUnit);

    public static Eff<T> ToEff<T>(this ValueTask<T> task) =>
        liftEff(task.AsTask);

    public static Eff<Unit> ToEff(this ValueTask task) =>
        liftEff(task.AsTask().ToUnit);

    public static IO<T> ToIO<T>(this Task<T> task) =>
        liftIO(() => task);

    public static IO<Unit> ToIO(this Task task) =>
        liftIO(task.ToUnit);

    public static IO<T> ToIO<T>(this ValueTask<T> task) =>
        liftIO(task.AsTask);

    public static IO<Unit> ToIO(this ValueTask task) =>
        liftIO(task.AsTask);
}
