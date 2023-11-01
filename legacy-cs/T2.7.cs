using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        var _inputClientData = new Dictionary<long, long> {
            {4056281045718745, 10023}, 
            {4056284045718745, 20024}, 
            {4056297845718745, 30012},
            {1283281045718745, 00064},
            {7546284045718745, 00086},
            {9876297845718745, 00045}
        };

        const int CURRENCY_TYPE = 810;

        // ---------- make arrays ----------
        var _output = _inputClientData.Where(
                _item => _item.Key / 100000000 % 1000 == CURRENCY_TYPE
            ).Select(
                _item => _item.Value
            ).Sum();




        Console.WriteLine(_output);

    }

}