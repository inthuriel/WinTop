using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace winTop
{
    class wmiProcess : wmiInfo
    {
        public wmiProcess()
        {
        }

        public List<List<string>> showProcess()
        {          
            processList _prcessList = new processList();
            ManagementObjectSearcher _querry = new ManagementObjectSearcher("root\\CIMV2", "Select * from Win32_PerfRawData_PerfProc_Process  Where NOT Name='_Total' AND NOT Name='0,_Total' AND IDProcess > 0");
            int i = 0;

            foreach (ManagementObject mo in _querry.Get())
            {
                if (i <= 30)
                {
                    int _pID = int.Parse(mo["IDProcess"].ToString());
                    ManagementObject _pInfo = new ManagementObject();
                    _pInfo = mo;

                    singleProcess _singleElement = new singleProcess();
                    _prcessList.addProcess(_singleElement.getProcessElement(_pID, _pInfo));
                }
                i++;
            }

            return _prcessList.fullProcessList;
        }

    }
}
