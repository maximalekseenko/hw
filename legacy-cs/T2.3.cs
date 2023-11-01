using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        int[] inputArray = {
            5839, 2953, 2033, 2994,
            6930, 4949, 3323, 4730,
        };

        // ---------- make arrays ----------
        var _output = inputArray.GroupBy(
                _value => _value % 10
            ).Select(
                _array => $"{_array.First() % 10} : {_array.Sum()}"
            ).OrderBy(_value => _value[0]);


        foreach (var _item in _output)
            Console.WriteLine(_item);

    }

}