using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_4_9 {
        public struct Applicant{
            public int schoolId;
            public int admissionYear;
            public string lastName;
        }
        public static void Run(string[] args){
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
                    _group => $"{_group.Select(
                        _item => _item.schoolId
                    ).Distinct().Count()
                    } {_group.First().admissionYear}"
                );




            // ---------- output output ----------
            foreach(var _value in _output)
                Console.WriteLine(_value);
        }
    }
}