namespace tut7.Services.Abstractions;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
    public DateTime Now { get; }
}