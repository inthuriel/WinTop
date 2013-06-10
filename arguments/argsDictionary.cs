using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class argsDictionary
    {
        public int lenght { get; set; }
        public int wordLenght { get; set; }
        public List<string> wordElements { get; set; }
        public argsDictionaryElement singleWord { get; set; }

        public argsDictionary(int _lenght)
        {
            this.lenght = _lenght;
        }

        public void setWord(int _lenght, List<string> _elements)
        {
            this.wordLenght = _lenght;
            this.wordElements = _elements;
            singleWord = new argsDictionaryElement(this.wordLenght, this.wordElements);
        }

        public List<argWord[]> getDictionary()
        {
            List<argWord[]> _dict = new List<argWord[]>();

            for (int i = 0; i < this.lenght; i++)
            {
                _dict.Add(singleWord.getWord());
            }

            return _dict;
        }
    }
}
