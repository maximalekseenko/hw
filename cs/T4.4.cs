using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
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