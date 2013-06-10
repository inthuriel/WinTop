using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace winTop
{
    class wmiInfo
    {
        public wmiInfo()
        {
        }

        public ManagementObject cpuInfo(string _namespace, string _query)
        {
            ManagementObject _cpu = new ManagementObject();
            ManagementObjectSearcher _querry = new ManagementObjectSearcher(_namespace, _query);
            foreach (ManagementObject queryObj in _querry.Get())
            {
                _cpu = queryObj;
            }

            return _cpu;
        }

    }
}
