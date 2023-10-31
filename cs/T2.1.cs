using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        string[] A = {"QWE12", "RT345", "YU678", "IOP"};
        string[] B = {"ASD12", "FG345", "HJ678", "KLZ"};

        // ---------- make output ---------- 
        var _output = 
            A.SelectMany(// +++ get output +++ 
                _ea => B.Select(
                    _eb => new {EA=_ea, EB=_eb}
                )
            ).Where(// +++ filter output +++ 
                _e => 
                    char.IsDigit(_e.EA.Last()) 
                        && 
                    char.IsDigit(_e.EB.Last())
            ).OrderBy(// +++ sort output +++ 
                _e => (_e.EA, _e.EB)
            );

        // ---------- output output ---------- 
        foreach (var _item in _output)
            Console.WriteLine(_item.EA + "=" + _item.EB);
    }

}