using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace winTop
{
    class wmiRam : wmiInfo
    {
        public wmiRam()
        {
        }

        public int getProcentageMemoryUsage()
        {
            int[] _usageInfo = getMemoryBasicInfo();
            float _percent = 0;
            float _usage = _usageInfo[3] - _usageInfo[0];
            _percent = (_usage / (float)_usageInfo[3]) * 100;
            return (int)Math.Round(_percent,0);
        }

        public int getProcentageVirtualUsage()
        {
            int[] _usageInfo = getMemoryBasicInfo();
            float _percent = 0;
            float _usage = _usageInfo[2] - _usageInfo[1];
            _percent = (_usage / (float)_usageInfo[2]) * 100;
            return (int)Math.Round(_percent, 0);
        }

        private int[] getMemoryBasicInfo()
        { 
            ManagementObjectSearcher _memQuery = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
            int[] _usage = new int[4];
            foreach (ManagementObject queryObj in _memQuery.Get())
            {                
                _usage[0] = int.Parse(queryObj["FreePhysicalMemory"].ToString());
                _usage[1] = int.Parse(queryObj["FreeVirtualMemory"].ToString());
                _usage[2] = int.Parse(queryObj["TotalVirtualMemorySize"].ToString());          
                _usage[3] = int.Parse(queryObj["TotalVisibleMemorySize"].ToString());
            }            
            return _usage;
        }
    }
}
