using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_5 {
        public static void Run(string[] args){
            // ---------- variables ---------- 
            int _inputValue = 3;
            string[] _inputArray = {
                "Apple",
                "banana",
                "Cherry",
                "date",
                "Elderberry"
            };

            // ---------- make output ---------- 
            var _output = _inputArray.Take(
                    _inputValue - 1
                ).Where(
                    _value => _value.Length % 2 != 0 && char.IsUpper(_value[0])
                ).Reverse();



            // ---------- output output ----------
            foreach(var _value in _output)
                Console.WriteLine(_value);
        }
    }
}