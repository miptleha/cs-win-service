using System;

namespace WinService.Log
{
    public interface ILog
    {
        void Error(Exception ex);
        void Error(string message, Exception ex);
        void Debug(string message);
    }
}
