using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading;

namespace winTop
{
    class Program
    {
        static void Main(string[] args)
        {
            winTop program = new winTop();
            program.start(args);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
