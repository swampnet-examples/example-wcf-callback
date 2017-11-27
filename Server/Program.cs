using Serilog;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var svc = new Service();
            svc.Start();

            Console.WriteLine("key");
            Console.ReadKey(true);

            svc.Stop();

            Log.CloseAndFlush();
        }
    }
}
