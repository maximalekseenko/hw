using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- cs/T4.6.cs
        int _inputValueK = 9;
        string[] _inputArray = {
            "ABC123",
            "DEFGH",
            "5678",
            "HIJKL",
            "MNOP9",
            "QRSTU345"
        };

        // ---------- make output ---------- 
        var _output = _inputArray.Take(
            _inputValueK
        ).Intersect(
            _inputArray.SkipWhile(
                _value => !_value.Any(char.IsDigit)
            ).Skip(1) 
        ).OrderBy(
            _value => _value.Length
        ).ThenBy(
            _value => _value
        );



        // ---------- output output ----------
        foreach(var _value in _output)
            Console.WriteLine(_value);
    }

}