using System;
using System.Collections.Generic;
using System.Text;
using PowerServer.ServerBll;

namespace PowerServer.PowerMonitorServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using(PowerService ps = new PowerService())
            {
                ps.startService();
                Console.WriteLine("Service Running ...");
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
                ps.stopService();
            }
        }
    }
}
