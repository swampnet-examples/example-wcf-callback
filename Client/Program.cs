using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    static class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();

            while (true)
            {
                Console.WriteLine("key");
                Console.ReadKey(true);

                using (var client = new Service.ServiceClient())
                {
                    var rs = client.Ping();
                    Log.Information("Response: {rs}", rs);
                }
            }
        }
    }
}
