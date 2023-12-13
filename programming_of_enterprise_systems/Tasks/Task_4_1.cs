using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_1 {
        public static void Run(string[] args){
            // ---------- variables ---------- 
            int[] _inputArray = {
                -1, -2, 1, -1, 4, 5, -5, 3
            };

            // ---------- make output ---------- 
            Console.WriteLine(
                _inputArray.FirstOrDefault(
                    _value => _value > 0
                )
            );


            Console.WriteLine(
                _inputArray.LastOrDefault(
                    _value => _value < 0
                )
            );
        }
    }
}