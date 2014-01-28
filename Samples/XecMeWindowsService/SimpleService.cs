#region HeaderAndCopyright

// Name:    		Punit Ganshani
// Website:		www.ganshani.com
// Blog:    		www.codetails.com/punitganshani
// 
// Date: 		11 Feb, 2013
// Project: 		XecMeSamples
// 
// Copyright:	Punit Ganshani, 2013
// License to use:	
// Please feel free to download, use, or modify the source code as required.

#endregion

#region Using Block

using System;
using XecMe.Core.Services;

#endregion

namespace XecMeSamples
{
    public class SimpleService : IService
    {
        private string _serviceName = "SimpleService";

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
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
    }
}