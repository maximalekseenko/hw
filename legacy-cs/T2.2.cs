using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        string[] inputArray = {
            "B2AA", "B2AB", "B1A", "B1B",
            "A2AA", "A2AB", "A1A", "A1B",
        };

        // ---------- make arrays ----------
        var _output = inputArray.GroupBy(// make arrays with letters
            _value => _value[0]
        ).Select(// get best values from arrays with letters
            _array => _array.OrderByDescending(// sort arrays with letters
                _value => _value.Length
            ).First()
        ).OrderBy(_value => _value);// final sort


        foreach (var _item in _output)
            Console.WriteLine(_item);

    }

}