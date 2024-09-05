using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_6 {
        public static void Run(string[] args){

            #region get data                 
                var ARRAY_A = TableReader.AccessTable<A>("table_A");
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
                var ARRAY_E = TableReader.AccessTable<E>("table_E");
            #endregion get data 

            #region process data 
                var _output = 

                #region make data
                    ARRAY_A.GroupBy(
                        _itemA => _itemA.residence_street
                    ).SelectMany(
                        _groupA_by_residence_street => ARRAY_E.GroupBy(
                            _itemE => _itemE.shop_name
                        ).Select(
                            _groupE_by_shop_name => new {
                                residence_street=_groupA_by_residence_street.FirstOrDefault(new A()).residence_street,
                                    
                                shop_name=_groupE_by_shop_name.FirstOrDefault(new E()).shop_name,
                                
                                sum_cost=ARRAY_D.Where(
                                        _itemD => _itemD.shop_name == _groupE_by_shop_name.FirstOrDefault(new E()).shop_name
                                               && _groupE_by_shop_name.Where(
                                                _itemE => _groupA_by_residence_street.Any(
                                                        _itemA => _itemA.consumer_key == _itemE.consumer_key
                                                    )
                                                ).Any(
                                                    _itemE => _itemE.vendor_code == _itemD.vendor_code
                                                )
                                    ).Sum(
                                        _itemD => _itemD.cost
                                    )
                            }
                        )
                #endregion make data

                #region sort data
                    ).OrderBy( // Sort
                        _item => _item.residence_street
                    ).ThenBy(
                        _item => _item.shop_name
                    ).ThenBy(
                        _item => _item.sum_cost
                #endregion sort data
                
                #region format output
                    ).Select( // format
                        _item => $"{_item.residence_street
                                }\t{_item.shop_name
                                }\t{_item.sum_cost
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