using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class argsDictionaryElement
    {
        private int wordLenght { get; set; }
        private string[] wordElementsTypes { get; set; }

        public argsDictionaryElement(int _lenght, List<string> _elements)
        {
            this.wordLenght = _lenght;
            wordElementsTypes = new string[this.wordLenght];

            for (int i = 0; i < this.wordLenght; i++)
            {
                this.wordElementsTypes[i] = _elements[i].ToString();
            }
        }


        public argWord[] getWord()
        {
            argWord[] _word = new argWord[this.wordLenght];

            for (int i = 0; i < this.wordLenght; i++)
            {
                argWord _singleWord = new argWord(this.wordElementsTypes[i], "value");
                _word[i] = _singleWord;                
            }

            return _word;
        }

        
    }
}
