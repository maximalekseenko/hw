using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        var _inputData = new {
            
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