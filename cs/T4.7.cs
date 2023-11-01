using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- cs/T4.6.cs
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