using Serilog;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Callback : Service.IServiceCallback
    {
        public void Poke(string s)
        {
            Log.Information("Poke: {s}", s);
        }
    }
}
