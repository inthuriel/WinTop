using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class procentageBar
    {
        private string barName { get; set; }
        private int barLenght { get; set; }
        private bool barShowColored { get; set; }
        private bool barShowProcentage { get; set; }
        private bool barShowName { get; set; }
        private console consoleInfo { get; set; }

        public procentageBar(console _consoleInfo, string _name = "Bar", int _bars = 100, bool _colored = true, bool _procentageShow = true, bool _nameShow = true)
        {
            this.barName = _name;
            this.barLenght = _bars;
            this.barShowColored = _colored;
            this.barShowProcentage = _procentageShow;
            this.barShowName = _nameShow;
            this.consoleInfo = _consoleInfo; 
        }

        public void write(int _value) {
            float _percent = ((float)_value / 100) * (float)this.barLenght;
            double _percentVal = Math.Ceiling(_percent);

            //show name
            if (this.barShowName)
            {
                Console.Write(this.barName+": ");
            }

            Console.Write("[ ");
            for (int i = 0; i < this.barLenght; i++)
            {
                //set char
                char _char = ' ';
                if (i <= _percentVal)
                {
                    _char = getElement();
                }

                //set color
                if (this.barShowColored)
                {
                    Console.ForegroundColor = getBarColor(i, this.barLenght);
                }
                    Console.Write(_char);                               
            }

            if (this.barShowColored)
            {
                Console.ForegroundColor = consoleInfo.consoleTextColor;                
            }

            Console.Write(" ]");

            //show percent
            if (this.barShowProcentage)
            {
                string _zeroSpaces = "";

                if (_value < 10)
                {
                    _zeroSpaces = "  ";
                }
                else if (_value >= 10 && _value < 100)
                {
                    _zeroSpaces = " ";
                }

                Console.Write(" " + _zeroSpaces +_value + "%");
            }

            Console.WriteLine();
        }

        private char getElement()
        {
            procentageBarElement _char = new procentageBarElement('|');
            return _char.getElement();
        }

        private ConsoleColor getBarColor(int _currentStage, int _lenght)
        {
            ConsoleColor _color = ConsoleColor.White;
            int _50percent = (int)Math.Round(0.5 * (float)_lenght, 0);
            int _85percent = (int)Math.Round(0.85 * (float)_lenght, 0);

            if (_currentStage < _50percent)
            {
                _color = ConsoleColor.Green;
            }
            else if (_currentStage >= _50percent && _currentStage < _85percent)
            {
                _color = ConsoleColor.Yellow;
            }
            else
            {
                _color = ConsoleColor.Red;
            }                         

            return _color;
        }

    }
}
