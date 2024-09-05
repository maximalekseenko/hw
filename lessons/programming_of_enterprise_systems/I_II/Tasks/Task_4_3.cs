using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_3 {
        public static void Run(string[] args){
            // ---------- variables ---------- 
            int _inputValue = 4;
            string[] _inputArray = {
                "a123", "543", "3241", "d2345"
            };

            // ---------- make output ---------- 
            var _output = _inputArray.FirstOrDefault(
                _value => char.IsDigit(_value[0]) && _value.Length == _inputValue
            );

            // ---------- output output ----------
            Console.WriteLine(_output != null? _output : "Not found");
        }
    }
}