using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace BlinkRGBLed
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferral_;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferral_ = taskInstance.GetDeferral();
            new BoardController().Start();
        }
    }
}
