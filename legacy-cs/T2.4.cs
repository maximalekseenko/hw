using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        int[] inputArrayA = {
            5839, 2953, 2033, 2994,
            6930, 4949, 3323, 4730,
        };
        int[] inputArrayB = {
            5839, 2953, 2033, 2994,
            6930, 4949, 3323, 4730,
        };


        // ---------- make arrays ----------
        var _output = inputArrayA.Select(
                _valueA => new {
                    S = inputArrayB.Where(_valueB => _valueA % 10 == _valueB % 10).Average(), 
                    E = _valueA
                }
            ).OrderBy(_item => (_item.S, -_item.E)
            ).Select(_item => $"{_item.S}:{_item.E}");


        foreach (var _item in _output)
            Console.WriteLine(_item);

    }

}