using System;
using System.ServiceProcess;
using System.Threading;
using WinService.Config;
using WinService.Log;
using WinService.Process;

namespace WinService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Timers.Timer _timerProcess;
        IServiceProcess _spProcess;
        ManualResetEvent _evProcess;
        bool _stoping = false;
        bool _firstTickProcess = false;

        /// <summary>
        /// Init and run all working proccesses
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("OnStart");

            try
            {
                _spProcess = new ServiceProcess();
                _spProcess.OnInit();

                _timerProcess = new System.Timers.Timer();
                _timerProcess.Elapsed += TimerProcess_Elapsed;
                _timerProcess.Interval = 10; //do not wait first time
                _timerProcess.AutoReset = false;
                _firstTickProcess = true;
                _timerProcess.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            _stoping = true;
            try
            {
                log.Debug("OnStop");

                if (_timerProcess != null && _spProcess != null)
                    _spProcess.StopDoWork();

                if (_timerProcess != null && _spProcess != null)
                {
                    if (_evProcess != null)
                        _evProcess.WaitOne();
                    _timerProcess.Enabled = false;
                    _timerProcess = null;

                    _spProcess.OnStop();
                    _spProcess = null;
                }
            }
            catch (Exception ex)
            {
                log.Error("!!!Error", ex);
            }
        }

        private void TimerProcess_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_stoping)
                return;

            try
            {
                //log.Debug(">TimerProcess_Elapsed");
                _evProcess = new ManualResetEvent(false);
                try
                {
                    _spProcess.DoWork();
                }
                catch (Exception ex)
                {
                    log.Error("!!!Error", ex);
                }
                //log.Debug("<TimerProcess_Elapsed");
                _evProcess.Set();
                if (!_stoping)
                {
                    if (_firstTickProcess)
                    {
                        _timerProcess.Interval = AppSettings.TimerIntervalProcess;
                        _firstTickProcess = false;
                    }
                    _timerProcess.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("!!!Error", ex);
            }
        }
    }
}
