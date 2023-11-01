using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
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