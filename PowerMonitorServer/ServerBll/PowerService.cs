using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using PowerServer.ServerAil;
using PowerServer.ServerBll.IModules;

namespace PowerServer.ServerBll
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple,InstanceContextMode=InstanceContextMode.Single)]
    public class PowerService:IPowerService,IDisposable
    {
        #region Service Control
        private void _initialService()
        {
            //initial work threads here
        }

        protected ServiceHost _host = null;
        public void startService()
        {
            _initialService();
            _host = new ServiceHost(typeof(PowerService));
            _host.Open();
        }

        public void stopService()
        {
            _host.Close();
        }

        bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {

            }
            _disposed = true;
        }
        #endregion

        #region Logic member
        private PublisherServer.PubliserServer _publisher = PublisherServer.PubliserServer.GetInstance();
        #endregion

        #region Implement Interface
        public bool userLogin(string username, string passwd)
        {
            
            return false;
        }
        #endregion
    }
}
