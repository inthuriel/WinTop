using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace winTop
{
    class winTop
    {
        public winTop()
        {
        }

        public void start(string[] _arg)
        {
            //arguments processor
            argsProcessor _arguments = new argsProcessor(_arg);
            _arguments.processArgs();

            //console setup
            ConsoleColor _bg = ConsoleColor.Black;
            ConsoleColor _txt = ConsoleColor.White;
            console _konsola = new console(150, 60, _bg, _txt, "");

            //display objects setup
            cpuUsage _cpu = new cpuUsage(_konsola);
            memoryUsage _mem = new memoryUsage(_konsola);
            process _proc = new process(_konsola);

            Console.Clear();

            generateLogo(_konsola);
           
            //loop for display data
            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(0, 10);

                    _cpu.summaryCpuUsage();

                    if (_arguments.useModulesList.Any(item => item == "perCoreCpuUsage"))
                    {
                        _cpu.perCoreCpuUsage();
                    }

                    _mem.showPercentMemUsage();

                    if (_arguments.useModulesList.Any(item => item == "showPercentVirtMemUsage"))
                    {
                        _mem.showPercentVirtMemUsage();
                    }

                    if (_arguments.useModulesList.Any(item => item == "printProcessTable"))
                    {
                        Console.SetCursorPosition(0, 18);
                        _proc.generateProcessTable();
                        _proc.printProcessTable();
                    }                                        

                    Thread.Sleep(500);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape );


        }

        private void generateLogo(console _konsola)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string _logo = "                      _/          _/_/_/_/_/\n _/      _/      _/      _/_/_/      _/      _/_/    _/_/_/ \n_/      _/      _/  _/  _/    _/    _/    _/    _/  _/    _/\n _/  _/  _/  _/    _/  _/    _/    _/    _/    _/  _/    _/ \n  _/      _/      _/  _/    _/    _/      _/_/    _/_/_/    \n                                                 _/         \n                                                _/          ";
            string _copy = "Made by Mikolaj 'Metatron' Niedbala";
            string _licenced = "Licenced under GNU/GPL v2";
            Console.WriteLine(_logo);
            Console.WriteLine(_copy);
            Console.WriteLine(_licenced);
            Console.ForegroundColor = _konsola.consoleTextColor;
        }

    }
}
