using System;
using System.Collections.Generic;

namespace WinService.Log
{
    public class Log : ILog
    {
        public Log(Type type)
        {
            _type = type;
            _log = log4net.LogManager.GetLogger(type);
        }

        Type _type;
        log4net.ILog _log;

        public void Error(Exception ex)
        {
            Error("!!!Error", ex);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }
    }
}
