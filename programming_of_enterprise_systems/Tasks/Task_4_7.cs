using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_7 {
        public static void Run(string[] args){
            // ---------- variables ----------
            int _inputValueK = 3;
            int[] _inputArray = {
                2, 5, 8, 7, 10, 12, 15, 18, 6, 9, 11, 14
            };

            // ---------- make output ---------- 
            var _output = _inputArray.Where(
                _value => _value % 2 == 0
            ).Except(
                _inputArray.Skip(_inputValueK)
            ).Reverse();



            // ---------- output output ----------
            foreach(var _value in _output)
                Console.WriteLine(_value);
        }
    }
}