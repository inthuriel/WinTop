using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class process
    {
        private console consoleInfo { get; set; }
        public List<List<string>> processList { get; set; }
        private wmiProcess wmiInfo = new wmiProcess();
        public string processTable { get; set; }

        public process(console _konsola)
        {
            consoleInfo = _konsola;
            processList = new List<List<string>>();
            processList = wmiInfo.showProcess();
        }

        public void generateProcessTable()
        {
            processTable = "";
            string _header     = "       pid |                          name |       RAM |   virtual |";
            string _headerLine = "-----------+-------------------------------+-----------+-----------+";
            processTable += _header + "\n";
            processTable += _headerLine + "\n";
            foreach (List<string> _process in processList)
            {
                processTable += singleProcessListElement(_process)+"\n";
            }
            processTable += _headerLine + "\n";
        }

        public void printProcessTable()
        {
            Console.ForegroundColor = consoleInfo.consoleTextColor;
            Console.WriteLine(processTable);
        }

        private string singleProcessListElement(List<string> _processInfo)
        {
            string _element = "";

            //pid cell
            int _spacesCnt = 10 - _processInfo[0].Count();
            string _spaces = "";
            for (int i = 0; i < _spacesCnt; i++)
            {
                _spaces += " ";
            }

            _element += _spaces+_processInfo[0]+" |"; 

            //name cell
            _spacesCnt = 30 - _processInfo[1].Count();
            _spaces = "";
            for (int i = 0; i < _spacesCnt; i++)
            {
                _spaces += " ";
            }
            _element += _spaces + _processInfo[1] + " |";

            //RAM usage
            long _ramUsage = long.Parse(_processInfo[2]);
            string _ramUsageText = converValue(_ramUsage);
            _spacesCnt = 10 - _ramUsageText.Count();
            _spaces = "";
            for (int i = 0; i < _spacesCnt; i++)
            {
                _spaces += " ";
            }
            _element += _spaces + _ramUsageText + " |";

            //vist usage
            long _virtUsage = long.Parse(_processInfo[3]);
            string _virtUsageText = converValue(_virtUsage);
            _spacesCnt = 10 - _virtUsageText.Count();
            _spaces = "";
            for (int i = 0; i < _spacesCnt; i++)
            {
                _spaces += " ";
            }
            _element += _spaces + _virtUsageText + " |"; 

            return _element;
        }

        private string converValue(float _val, int _lvl = 0)
        {
            string[] _suffix = new string[5] { "B","kB","MB","GB","TB" };
            string _newVal = "";

            if (_val < 1024)
            {
                int _val2 = (int)Math.Round(_val, 0);
                _newVal = _val2.ToString() + _suffix[_lvl];
                return _newVal;
            }
            else
            {
                _val = _val / 1024;                
                return converValue(_val, ++_lvl);
            }
        }

    }
}
