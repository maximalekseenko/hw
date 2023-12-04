using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public class VisitData {
        public int clientCode;
        public int year;
        public int month;
        public int time;
    }

    public static void Main(string[] args)
    {
        // ---------- variables ---------- 
        int _clientCode = 474;

        
        List<VisitData> _clientData = new List<VisitData>{
            new VisitData{
                clientCode=474,
                year=3211,
                month=24,
                time=123
            },new VisitData{
                clientCode=474,
                year=1234,
                month=24,
                time=232
            },new VisitData{
                clientCode=474,
                year=1234,
                month=24,
                time=232
            }
        };

        // ---------- make arrays ----------
        var _output = _clientData.Where(
                _item => _item.clientCode == _clientCode
            ).GroupBy(
                _item => _item.year
            ).Select(
                _array => _array.Aggregate(
                    (_item1, _item2) => _item1.time < _item2.time? _item1 : _item2
                )
            ).OrderBy(
                _item => (_item.time, _item.year)
            ).Select(
                _item => $"{_item.time} {_item.year} {_item.month}"
            );


        if (_output.Count() == 0)
            Console.WriteLine("Нет данных");
        else foreach (var _item in _output)
            Console.WriteLine(_item);

    }

}