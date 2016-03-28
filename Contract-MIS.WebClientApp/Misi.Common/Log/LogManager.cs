using System;

namespace Misi.Common.Log
{
    public sealed class LogManager
    {
        private static volatile Logger _instance;
        private static readonly object SyncRoot = new Object();

        public static Logger Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
                return _instance;
            }
        }
    }
}