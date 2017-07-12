using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WinService.Log;

namespace WinService.Process
{
    /// <summary>
    /// TODO: implement all methods
    /// </summary>
    class ServiceProcess : IServiceProcess
    {
        bool _stop = false;
        ILog log;

        public void OnInit()
        {
            //open files, connections
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void OnStop()
        {
            //close files, connections
        }

        public void StopDoWork()
        {
            //speed up DoWork, if service stoped in time of it execution
            _stop = true;
        }

        /// <summary>
        /// a lot of code here
        /// </summary>
        public void DoWork()
        {
            //...

            log.Debug("do some work, then sleep");

            if (_stop) return;

            //...
        }
    }
}
