namespace FreakyFashion.Core.Interfaces;

public interface ILoggingService
{
    void LogError(Exception e);
    void LogInfo(string message);
}