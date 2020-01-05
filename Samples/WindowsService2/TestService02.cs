using SessionZeroInteractive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService2
{
    public partial class TestService02 : ServiceBase
    {
        public TestService02()
        {
            InitializeComponent();
        }

        async protected override void OnStart(string[] args)
        {

            await Task.Delay(10000);
            var path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.System)}\notepad.exe";
            Interactor.Start(path);
        }

        protected override void OnStop()
        {
        }
    }
}
