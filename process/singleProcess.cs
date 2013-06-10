using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace winTop
{
    class singleProcess
    {
        public singleProcess()
        {
        }

        public List<string> getProcessElement(int _pId, ManagementObject _processWideInfo)
        {
            List<string> _processFullInfo = new List<string>();
            _processFullInfo.Add(_pId.ToString());
            _processFullInfo.Add(_processWideInfo["Name"].ToString());
            _processFullInfo.Add(_processWideInfo["VirtualBytes"].ToString());
            _processFullInfo.Add(_processWideInfo["PageFileBytes"].ToString());
            return _processFullInfo;
        }
    }
}
