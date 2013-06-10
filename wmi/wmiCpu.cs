using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace winTop
{
    class wmiCpu : wmiInfo
    {
        public wmiCpu()
        {
        }

        public int numberOfCores()
        {
            ManagementObject _cores = cpuInfo("root\\CIMV2", "SELECT * FROM Win32_Processor");            
            return int.Parse(_cores["NumberOfCores"].ToString());
        }

        public int totalLoad()
        {
 
            ManagementObject _cpu = new ManagementObject();
            ManagementObjectSearcher _querry = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject queryObj in _querry.Get())
            {
                if (queryObj != null)
                {
                    _cpu = queryObj;
                }
                
            }

            string _value = "";

            if (_cpu["LoadPercentage"] != null)
            {
                _value = _cpu["LoadPercentage"].ToString();
            }
            else 
            {
                _value = "0";
            }


            return int.Parse(_value);
        }

        public List<int[]> coresLoadInfo()
        {
            List<int[]> _loads = new List<int[]>();            

            ManagementObjectSearcher _searchLoads = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_Counters_ProcessorInformation WHERE NOT Name='_Total' AND NOT Name='0,_Total'");

            foreach (ManagementObject _queryObj in _searchLoads.Get())
            {
                string _name = _queryObj["Name"].ToString();
                string[] _numbers = _name.Split(',');
                string _value = "";

                if (_queryObj["PercentProcessorTime"] != null)
                {
                    _value = _queryObj["PercentProcessorTime"].ToString();
                }
                else
                {
                    _value = "0";
                }

                int[] _element = new int[2] { int.Parse(_numbers[1]), int.Parse(_value) };
                _loads.Add(_element);
            }

            return _loads;
        }

    }
}
