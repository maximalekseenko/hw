using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public struct Applicant{
        public int schoolId;
        public int admissionYear;
        public string lastName;
    }
    public static void Main(string[] args)
    {
        // ---------- variables ----------
        List<Applicant> _inputArray = new List<Applicant>
        {
            new Applicant { 
                schoolId=1, 
                admissionYear=2019, 
                lastName="Volk" 
            },
            new Applicant { 
                schoolId=2, 
                admissionYear=2020, 
                lastName="McGregor" 
            },
            new Applicant { 
                schoolId=3, 
                admissionYear=2019, 
                lastName="Makhachev" 
            },
            new Applicant { 
                schoolId=1, 
                admissionYear=2021, 
                lastName="Costa" 
            },
            new Applicant { 
                schoolId=2, 
                admissionYear=2020, 
                lastName="Walker"
            }
        };


        // ---------- make output ---------- 
        var _output = _inputArray.GroupBy(
                _item => _item.admissionYear
            ).Select(
                _group => new {
                    year = _group.First().admissionYear,
                    amount = _group.Count()
                }
            ).GroupBy(
                _item => _item.amount
            ).OrderBy(
                _group => _group.First().amount
            );



        // ---------- output output ----------
        Console.WriteLine("min");
        foreach(var _value in _output.First())
            Console.WriteLine(_value);

        Console.WriteLine("max");
        foreach(var _value in _output.Last())
            Console.WriteLine(_value);
    }

}