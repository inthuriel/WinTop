using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class argWord
    {
        public string type {
            get
            {
                return this.ToString();
            }
            set
            {
            }
        }
        public object value { get; set; }

        public argWord(string _type, object _value)
        {
            this.type = _type;
            this.value = _value;
        }

        public void setValue(string _val)
        {
            this.value = _val;
        }
    }
}
