using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;


namespace CronService
{
    [RunInstaller(true)]
    public partial class CronInstaller : Installer
    {
        private readonly ServiceProcessInstaller processInstaller;
        private readonly ServiceInstaller serviceInstaller;

        public CronInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "Cron";
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
