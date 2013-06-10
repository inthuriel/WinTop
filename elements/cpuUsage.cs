using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;


namespace winTop
{
    class cpuUsage
    {
        private console consoleInfo { get; set; }
        private wmiCpu wmiInfo = new wmiCpu();

        public cpuUsage(console _consoleInfo)
        {
            this.consoleInfo = _consoleInfo; 
        }

        public void summaryCpuUsage()
        {           
            procentageBar _cpuTotal = new procentageBar(this.consoleInfo, "Total CPU", 60);
            _cpuTotal.write(wmiInfo.totalLoad());
        }

        public void perCoreCpuUsage()
        {
            List<int[]> _coreLoads = wmiInfo.coresLoadInfo();

            foreach (int[] _load in _coreLoads)
            {
                procentageBar _cpuTotal = new procentageBar(this.consoleInfo, "CPU " + _load[0]+"    ", 60);
                _cpuTotal.write(_load[1]);
            }

        }

    }
}
