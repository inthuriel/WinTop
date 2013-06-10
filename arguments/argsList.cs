using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class argsList
    {
        public argsList()
        {
        }

        public List<string> generateList(string[] _args)
        {
            List<string> _list = new List<string>();

            foreach (string arg in _args)
            {
                _list.Add(arg.Trim());
            }

            return _list;
        }
    }
}
