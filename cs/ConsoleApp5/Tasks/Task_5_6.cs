using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_6 {
        public static void Run(){

            #region get data                 
                var ARRAY_A = TableReader.AccessTable<A>("table_A");
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
                var ARRAY_E = TableReader.AccessTable<E>("table_E");
            #endregion get data 

            #region process data 
                var _output = ARRAY_A.GroupBy(
                    _itemA => _itemA.residence_street
                ).SelectMany(
                    _groupA_by_residence_street => ARRAY_E.GroupBy(
                        _itemE => _itemE.shop_name
                    ).Select(
                        _groupE_by_shop_name => new {
                                residence_street=_groupA_by_residence_street.First().residence_street,
                                shop_name=_groupE_by_shop_name.First().shop_name,
                                sum_cost=ARRAY_D.Where( // filter by shop
                                    _itemD => _itemD.shop_name == _groupE_by_shop_name.First().shop_name
                                ).Where( // filter by vendor
                                    _itemD => _groupE_by_shop_name.Where(
                                        _itemE => _groupA_by_residence_street.Select(
                                            _itemA => _itemA.consumer_key
                                        ).Contains(_itemE.consumer_key)
                                    ).Select(
                                        _itemE => _itemE.vendor_code
                                    ).Contains(_itemD.vendor_code)
                                ).Select(
                                    _itemD => _itemD.cost
                                ).Sum()
                            }
                    )
                ).OrderBy( // Sort
                    _item => _item.residence_street
                ).ThenBy(
                    _item => _item.shop_name
                ).ThenBy(
                    _item => _item.sum_cost
                ).Select( // format
                    _item => $"{_item.residence_street}\t{_item.shop_name}\t{_item.sum_cost}"
                );
            #endregion process data 

            #region output
                foreach(var _value in _output)
                    Console.WriteLine(_value);
            #endregion output

        }
    }
}