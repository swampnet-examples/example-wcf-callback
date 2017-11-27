using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Shared;
using Serilog;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class Service : IService
    {
        private ServiceHost _host;

        public void Start()
        {
            Log.Information("Starting");

            _host = new ServiceHost(this);
            _host.Open();
        }

        public void Stop()
        {
            if(_host != null)
            {
                Log.Information("Stopping");

                _host.Close();
                _host = null;
            }
        }

        public string Ping()
        {
            Log.Information("ping");

            return "pong";
        }


        public void Subscribe()
        {

        }


        public void Unsubscribe()
        {

        }
    }
}
