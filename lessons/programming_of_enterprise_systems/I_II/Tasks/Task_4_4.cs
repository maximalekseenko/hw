using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_4 {
        public static void Run(string[] args){
            // ---------- variables ---------- 
            int _inputValue = 10;
            int[] _inputArray = {
                7, 15, 9, 12, 5, 18, 11, 3, 14, 20
            };

            // ---------- make output ---------- 
            var _output = _inputArray.SkipWhile(
                    _value => _value <= _inputValue
                ).Where(
                    _value => _value > 0 && _value % 2 != 0
                ).Reverse();


            // ---------- output output ----------
            foreach(var _value in _output)
                Console.WriteLine(_value);
        }
    }
}