using System;
using System.Collections.Generic;
using System.Configuration;

namespace WinService.Config
{
    public class AppSettings
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        public static int TimerIntervalProcess
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings.Get("TimerIntervalProcess"));
            }
        }
    }
}