using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        int _inputValue = 5;
        int[] _inputArray = {
            123, 543, 324, 2345, 234, 245
        };

        // ---------- make output ---------- 
        var _output = _inputArray.FirstOrDefault(
            _value => _value % 10 == _inputValue
        );

        // ---------- output output ----------
        Console.WriteLine(_output);
    }

}