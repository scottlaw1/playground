using System.ServiceProcess;
using System.Threading;

namespace CronService
{
    public partial class CronService : ServiceBase
    {
        private CronJob job;
        private Timer stateTimer;
        private TimerCallback timerDelegate;

        public CronService()
        {
            InitializeComponent();
            ServiceName = "Cron";
            CanStop = true;
            CanPauseAndContinue = false;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            job = new CronJob();
            timerDelegate = job.DoSomething;
            stateTimer = new Timer(timerDelegate, null, 1000, 1000);
        }

        protected override void OnStop()
        {
            stateTimer.Dispose();
        }
    }
}
