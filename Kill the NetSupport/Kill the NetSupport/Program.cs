using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kill_the_NetSupport
{
    class Program
    {
        static string[] harmfullProcesses = new string[] { "client32", "Runplugin64", "runplugin", "StudentUI" };
        static int time;

        static void Main(string[] args)
        {
            Console.WriteLine("Input the remaining seconds until the NetSupport's Death.");
            string input;
            try
            {
                do
                {
                    input = Console.ReadLine();
                    Console.WriteLine("Pozitív Számot lehetőleg!");
                } while (!int.TryParse(input, out time) || input[0] == '-');
            }
            catch (IndexOutOfRangeException) { }
            Console.Clear();
            Console.WriteLine(time + " seconds until NetSupport's death.");
            for (int i = time - 1; i > 0; --i)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Remaining Time: " + (i - 1));
            }

            foreach (var harlfulProcess in harmfullProcesses)
            {
                foreach (var process in Process.GetProcessesByName(harlfulProcess))
                {
                    process.Kill();
                }
            }
        }
    }
}
