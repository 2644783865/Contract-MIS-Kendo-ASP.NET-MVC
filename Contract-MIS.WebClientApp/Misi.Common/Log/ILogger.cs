using System;

namespace Misi.Common.Log
{
    public interface ILogger
    {
        void Info(string message);
        void Info(string message, Exception ex);

        void Warn(string message);

        void Debug(string message);

        void Error(string message);
        void Error(string message, Exception ex);
        void Error(string message, Exception ex, Object obj);

        void Fatal(string message);
        void Fatal(string message, Exception ex); 
    }
}