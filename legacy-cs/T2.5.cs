using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        string[] inputArrayA = {
            "QWE12", "RT345", "YU678", "IOP"
        };
        string[] inputArrayB = {
            "ASD12", "FG345", "HJ678", "KLZ"
            , "YU678", "IOP"
        };


        // ---------- make arrays ----------
        var _output = inputArrayA.GroupJoin(inputArrayB,
                _valueA => _valueA[0],
                _valueB => _valueB[0],
                (_e, _n) => new {E=_e, N=_n.Count()}
            // ).OrderBy(_item => (_item.N, -_item.E)
            ).Select(_item => $"{_item.E}:{_item.N}");


        foreach (var _item in _output)
            Console.WriteLine(_item);

    }

}