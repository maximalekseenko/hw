using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_4 {
        public static void Run(){

            #region get data 
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
                var ARRAY_E = TableReader.AccessTable<E>("table_E");
            #endregion get data 

            #region process data 
                var _output = ARRAY_D.GroupBy(
                    _itemD => _itemD.vendor_code
                ).Select(
                    _groupD_by_vendor_code => new {
                        amount_of_sales = ARRAY_E.Where(
                                _itemE => _itemE.vendor_code == _groupD_by_vendor_code.First().vendor_code
                            ).ToArray().Length,
                        vendor_code = _groupD_by_vendor_code.First().vendor_code,
                        max_cost = _groupD_by_vendor_code.OrderBy(
                                _item => _item.cost
                            ).First().cost
                    }
                ).Where( // that was sold
                    _item => _item.amount_of_sales != 0
                ).OrderBy( // Sort
                    _item => _item.amount_of_sales
                ).ThenBy(
                    _item => _item.vendor_code
                ).ThenBy(
                    _item => _item.max_cost
                ).Select( // format
                    _item => $"{_item.amount_of_sales}\t{_item.vendor_code}\t{_item.max_cost}"
                );
            #endregion process data 

            #region output
                foreach(var _value in _output)
                    Console.WriteLine(_value);
            #endregion output
            
        }
    }
}