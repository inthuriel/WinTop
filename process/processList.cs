using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class processList
    {
        public List<List<string>> fullProcessList { get; set; }

        public processList()
        {
            fullProcessList = new List<List<string>>();
        }

        public void addProcess(List<string> _pInfo)
        {
            fullProcessList.Add(_pInfo);
        }
    }
}
