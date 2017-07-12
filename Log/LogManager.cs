using System;

namespace WinService.Log
{
    class LogManager
    {
        public static ILog GetLogger(Type type)
        {
            var log = new Log(type);
            return log;
        }
    }
}
