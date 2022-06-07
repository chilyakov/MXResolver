using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MXResolver
{
    public partial class MXResolverService : ServiceBase
    {
        private bool _cancel;
        public MXResolverService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           
            Task.Run(() => Processing());
            EventLog.WriteEntry("Service started", EventLogEntryType.Information);
        }

        private void Processing()
        {
           try
            {
                while (!_cancel)
                {
                    System.Threading.Thread.Sleep(100);            
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnStop()
        {
            _cancel = true;
            EventLog.WriteEntry("Service stoped", EventLogEntryType.Information);
        }
    }
}
