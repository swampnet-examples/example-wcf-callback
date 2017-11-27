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
            ICallback subscriber = OperationContext.Current.GetCallbackChannel<ICallback>();
            if(subscriber != null)
            {
                Log.Information("Subscribe");

                lock (_callbacks)
                {
                    _callbacks.Add(subscriber);
                }

                subscriber.Poke("Poke!");
            }
        }


        public void Unsubscribe()
        {
            ICallback subscriber = OperationContext.Current.GetCallbackChannel<ICallback>();
            if (subscriber != null)
            {
                Log.Information("Unsubscribe");

                lock (_callbacks)
                {
                    _callbacks.Remove(subscriber);
                }
            }
        }

        private List<ICallback> _callbacks = new List<ICallback>();
    }
}
