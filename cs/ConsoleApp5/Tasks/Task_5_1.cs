using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_1 {
        public static void Run(){

            #region get data 
                var ARRAY_A = TableReader.AccessTable<A>("table_A");
                var ARRAY_C = TableReader.AccessTable<C>("table_C");              
            #endregion get data

            #region process data 
                var _output = 

                #region make data
                    ARRAY_C.GroupBy(
                        _itemC => _itemC.shop_name
                    ).Select( // get max discount
                        _groupC_by_shop_name => _groupC_by_shop_name.MaxBy(
                            _itemC => Tuple.Create(_itemC.discount, _itemC.consumer_key)
                        )
                #endregion make data

                #region sort data
                    ).OrderBy( // sort
                        _itemC => _itemC.shop_name
                #endregion sort data
                
                #region format output
                    ).Select( // format output
                        _itemC => $"{ _itemC.shop_name
                                 }\t{ _itemC.consumer_key
                                 }\t{ ARRAY_A.FirstOrDefault(
                                        _itemA => _itemA.consumer_key == _itemC.consumer_key
                                    , new A()).birth_year
                                 }\t{ _itemC.discount}"
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