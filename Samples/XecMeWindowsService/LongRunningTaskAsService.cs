using System;
using XecMe.Core.Services;
using System.Threading;

namespace XecMeSamples
{
    public class LongRunningTaskAsService : IService
    {
        private string _serviceName = "LongRuninngTaskAsService";
        private Thread _thread;
        private ManualResetEvent _shutdownEvent;

        public bool CanPauseAndContinue
        {
            get { return false; }
        }

        public void OnContinue()
        {
            throw new NotSupportedException();
        }

        public void OnPause()
        {
            throw new NotSupportedException();
        }

        public void OnShutdown()
        {
            _shutdownEvent.Set();
        }

        public void OnStart()
        {
            _thread = new Thread(RunInBackground)
                {
                    Name = "Worker Thread",
                    IsBackground = true
                };

            _shutdownEvent = new ManualResetEvent(false);
            _thread.Start();
        }

        private void RunInBackground()
        {
            // run some thing in background
            while (!_shutdownEvent.WaitOne(0))
            {
                // Replace the Sleep() call with the work you need to do
                Thread.Sleep(1000);
            }
        }

        public void OnStop()
        {
            if (!_thread.Join(3000))
            {
                // give the thread 3 seconds to stop
                _thread.Abort();
            }
        }

        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
    }
}