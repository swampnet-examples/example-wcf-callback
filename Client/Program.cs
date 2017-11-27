using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    static class Program
    {
        private static Callback _callback = new Callback();

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();

            bool run = true;
            while (run)
            {
                Console.Write(">");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        run = false;
                        break;

                    case ConsoleKey.P:
                        Ping();
                        break;

                    case ConsoleKey.S:
                        Subscribe();
                        break;

                    case ConsoleKey.U:
                        Unsubscribe();
                        break;
                }

                Console.WriteLine();
            }
        }


        private static void Ping()
        {
            Log.Information("Ping");

            using (var client = new Service.ServiceClient(new InstanceContext(_callback)))
            {
                var rs = client.Ping();
                Log.Information("Response: {rs}", rs);
            }
        }


        private static void Subscribe()
        {
            Log.Information("Subscribe");

            using (var client = new Service.ServiceClient(new InstanceContext(_callback)))
            {
                client.Subscribe();
            }
        }

        private static void Unsubscribe()
        {
            Log.Information("Unsubscribe");

            using (var client = new Service.ServiceClient(new InstanceContext(_callback)))
            {
                client.Unsubscribe();
            }
        }
    }
}
