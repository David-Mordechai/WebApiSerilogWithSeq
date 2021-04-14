using System;

namespace Tools.Logger
{
    public interface ILoggerAdapter<T>
    {
        void LogError(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
