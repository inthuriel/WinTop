using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class procentageBarElement
    {
        char barElementChar {get; set;}
        bool colored {get; set;}

        public procentageBarElement(char _element = '|', bool _colored = true)
        {
            this.barElementChar = _element;
            this.colored = _colored;
        }

        public char getElement()
        {
            return this.barElementChar;
        }
    }
}
