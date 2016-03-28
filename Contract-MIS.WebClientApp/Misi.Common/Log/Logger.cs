using System;

namespace Misi.Common.Log
{
    public class Logger : ILogger
    {
        private readonly NLog.Logger _logger;

        public Logger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string message, Exception ex)
        {
            _logger.Info(string.Format("{0} || {1}", message, ex.Message));
        }


        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            _logger.Error(string.Format("{0} || {1}", message, ex.Message));
        }

        public void Error(string message, Exception ex, object obj)
        {
            _logger.Error(string.Format("{0} || {1} || {2}", message, ex.Message, obj.GetType()));
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            _logger.Fatal(string.Format("{0} || {1}", message, ex.Message));
        }
    }
}