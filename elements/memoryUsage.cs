using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace winTop
{
    class memoryUsage
    {
        private console consoleInfo { get; set; }
        private wmiRam wmiInfo = new wmiRam();

        public memoryUsage(console _consoleInfo)
        {
            this.consoleInfo = _consoleInfo; 
        }

        public void showPercentMemUsage()
        {
            procentageBar _memTotal = new procentageBar(this.consoleInfo, "RAM usage", 60);
            _memTotal.write(wmiInfo.getProcentageMemoryUsage());
        }

        public void showPercentVirtMemUsage()
        {
            procentageBar _virtTotal = new procentageBar(this.consoleInfo, "Virtual memory usage", 60);
            _virtTotal.write(wmiInfo.getProcentageVirtualUsage());
        }

    }
}
