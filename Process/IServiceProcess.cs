namespace WinService.Process
{
    /// <summary>
    /// Definition of abstract working process. Inherit and implement all methods for your business logic.
    /// </summary>
    interface IServiceProcess
    {
        /// <summary>
        /// Called when service starting. If exception arrise, service will not start.
        /// </summary>
        void OnInit();

        /// <summary>
        /// Called when service stoped. In this method you can speed up completion of DoWork() method.
        /// </summary>
        void StopDoWork();

        /// <summary>
        /// Called when service stoped after DoWork() finished
        /// </summary>
        void OnStop();

        /// <summary>
        /// Called on timer with period from config file. Do all background work here (check db, write files, etc).
        /// If you need to do independent actions, then create several instances of IServiceProcess (activate them in Service1.cs)
        /// </summary>
        void DoWork();
    }
}
