using Serilog;
using System;

namespace Tools.Logger
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        public void LogError(string message, params object[] args)
        {
            try
            {
                Log.ForContext<T>().Error(message, args);
            }
            catch (Exception)
            {
                // ingnore
            }
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            try
            {
                Log.ForContext<T>().Error(ex, message, args);
            }
            catch (Exception)
            {
                // ingnore
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            try
            {
                Log.ForContext<T>().Information(message, args);
            }
            catch (Exception)
            {
                // ingnore
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            try
            {
                Log.ForContext<T>().Warning(message, args);
            }
            catch (Exception)
            {
                // ingnore
            }
        }
    }
}
