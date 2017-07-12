using System.ComponentModel;
using System.Configuration.Install;

namespace WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            //uncomment if need start service after install

            //using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
            //{
            //    sc.Start();
            //}
        }
    }
}
