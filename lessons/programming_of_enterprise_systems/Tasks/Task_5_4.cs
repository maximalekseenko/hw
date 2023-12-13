using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_4 {
        public static void Run(string[] args){

            #region get data 
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
                var ARRAY_E = TableReader.AccessTable<E>("table_E");
            #endregion get data 

            #region process data 
                var _output = 

                #region make data
                    ARRAY_D.GroupBy(
                        _itemD => _itemD.vendor_code
                    ).Select(
                        _groupD_by_vendor_code => new {
                            amount_of_sales = ARRAY_E.Where(
                                    _itemE => _itemE.vendor_code == _groupD_by_vendor_code.FirstOrDefault(new D()).vendor_code
                                ).Count(),
                            vendor_code = _groupD_by_vendor_code.FirstOrDefault(new D()).vendor_code,
                            max_cost = _groupD_by_vendor_code.Max(
                                    _itemD => _itemD.cost
                                )
                        }
                    ).Where( // that was sold
                        _item => _item.amount_of_sales != 0
                #endregion make data

                #region sort data
                    ).OrderBy(
                        _item => _item.amount_of_sales
                    ).ThenBy(
                        _item => _item.vendor_code
                    ).ThenBy(
                        _item => _item.max_cost
                #endregion sort data
                
                #region format output
                    ).Select(
                        _item => $"{_item.amount_of_sales
                                }\t{_item.vendor_code
                                }\t{_item.max_cost
                                }"
                    );
                #endregion format output
            #endregion process data 

            #region output
                foreach(var _value in _output)
                    Console.WriteLine(_value);
            #endregion output
        }
    }
}