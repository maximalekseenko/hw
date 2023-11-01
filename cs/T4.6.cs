using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        int _inputValueD = 10;
        int _inputValueK = 10;
        int[] _inputArray = {
            5, 8, 12, 15, 20, 6, 18, 9, 11, 7
        };

        // ---------- make output ---------- 
        var _output = _inputArray.TakeWhile(
                _value => _value <= _inputValueD
            ).Concat(
                _inputArray.Skip(_inputValueK - 1)
            ).Distinct(
            ).OrderByDescending(
                _value => _value
            );



        // ---------- output output ----------
        foreach(var _value in _output)
            Console.WriteLine(_value);
    }

}