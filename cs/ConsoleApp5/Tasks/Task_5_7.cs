using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_7 {
        public static void Run(string[] args){

            #region get data                 
                var ARRAY_A = TableReader.AccessTable<A>("table_A");
                var ARRAY_C = TableReader.AccessTable<C>("table_C");
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
                            _itemE => _itemE.vendor_code
                        ).Select(
                            _groupE_by_vendor_code => new {
                                vendor_code=_groupE_by_vendor_code.FirstOrDefault(new E()).vendor_code,
                                
                                residence_street=_groupA_by_residence_street.FirstOrDefault(new A()).residence_street,
                                
                                sum_discount=_groupE_by_vendor_code.Sum(
                                    _itemE => Math.Round(
                                            ARRAY_D.FirstOrDefault(
                                                    _itemD => (_itemD.vendor_code == _itemE.vendor_code) 
                                                           && (_itemD.shop_name == _itemE.shop_name),
                                                    new D()
                                                ).cost
                                            * 
                                            ARRAY_C.FirstOrDefault(
                                                    _itemC => (_itemC.consumer_key == _itemE.consumer_key) 
                                                           && (_itemC.shop_name == _itemE.shop_name),
                                                    new C()
                                                ).discount
                                            )
                                )
                            }
                        )
                #endregion make data

                #region sort data
                    ).OrderBy( // Sort
                        _item => _item.vendor_code
                    ).ThenBy(
                        _item => _item.residence_street
                    ).ThenBy(
                        _item => _item.sum_discount
                #endregion sort data
                
                #region format output
                    ).Select( // format
                        _item => $"{_item.vendor_code
                                }\t{_item.residence_street
                                }\t{_item.sum_discount
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