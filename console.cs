using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTop
{
    class console
    {
        public int consoleWidth { get; set; }
        public int consoleHeight { get; set; }
        public ConsoleColor consoleBgColor { get; set; }
        public ConsoleColor consoleTextColor { get; set; }
        public string title { get; set; }
        
        public console(int _width = 120, int _height = 50, ConsoleColor _colorBg = ConsoleColor.Black, ConsoleColor _colorText = ConsoleColor.White, string _title = "")
        {
            this.consoleWidth = _width;
            this.consoleHeight = _height;
            this.consoleBgColor = _colorBg;
            this.consoleTextColor = _colorText;
            this.title = _title;            

            setSize();
        }

        private void setSize()
        {
            Console.SetWindowSize(this.consoleWidth, this.consoleHeight);
        }

        private void setColors()
        {
            System.Console.BackgroundColor = this.consoleBgColor;
            System.Console.ForegroundColor = this.consoleTextColor;
            System.Console.Clear();
        }

        private void setTitle()
        {
            if (String.IsNullOrEmpty(this.title))
            {
                this.title = "WinTop - console process viewer";
            }

            System.Console.Title = this.title;
        }

        private void setPosition()
        {
            System.Console.SetWindowPosition(0, 0);
        }
    }
}
