using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class argsProcessor
    {
        public string[] argsOrgList {get; set;}
        public List<string> argsList { get; set; }
        public List<argWord[]> dictionary { get; set; }
        public List<string> useModulesList { set; get; }

        public argsProcessor(string[] _args)
        {
            this.argsOrgList = _args;
            this.argsList = processArgs(_args);
        }

        private List<string> processArgs(string[] _args)
        {
            argsList _list = new argsList();
            return _list.generateList(_args);
        }

        private List<argWord[]> generateDictionary()
        {
            List<argWord[]> _dictionary = new List<argWord[]>();

            argsDictionary _dict = new argsDictionary(5);
            List<string> _elements = new List<string>();
            _elements.Add("string");
            _elements.Add("string");
            _elements.Add("string");
            _dict.setWord(3, _elements);

            _dictionary = _dict.getDictionary();

            return _dictionary;
        }

        private void fillDictionary()
        {
            dictionary = generateDictionary();

            //fill with real values
            dictionary[0][0].setValue("c"); //short name
            dictionary[0][1].setValue("cpu"); //long alias
            dictionary[0][2].setValue("summaryCpuUsage"); //element name

            dictionary[1][0].setValue("r");
            dictionary[1][1].setValue("ram");
            dictionary[1][2].setValue("showPercentMemUsage");

            dictionary[2][0].setValue("v");
            dictionary[2][1].setValue("virt");
            dictionary[2][2].setValue("showPercentVirtMemUsage");

            dictionary[3][0].setValue("p");
            dictionary[3][1].setValue("process");
            dictionary[3][2].setValue("printProcessTable"); 

            dictionary[4][0].setValue("cr");
            dictionary[4][1].setValue("core");
            dictionary[4][2].setValue("perCoreCpuUsage");

        }

        public void processArgs()
        {
            fillDictionary();
            useModulesList = new List<string>();
            foreach (string argument in argsList)
            {
                foreach (argWord[] arg in dictionary)
                {
                    if(argument == arg[0].value.ToString() || argument == arg[1].value.ToString())
                    {
                        useModulesList.Add(arg[2].value.ToString());
                    }
                }                
            }
        }

    }
}
