using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_2 {
        public static void Run(){

            #region get data 
                var ARRAY_B = TableReader.AccessTable<B>("table_B");
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
            #endregion get data 

            #region process data 
                var _output = ARRAY_B.GroupBy(
                    _itemB => _itemB.category
                ).Select( // get output data
                    _groupB_by_category => new {
                        category=_groupB_by_category.First().category,

                        shop_amount=ARRAY_D.GroupBy(
                                _itemD => _itemD.shop_name
                            ).Where( // get amount of shops where such category is sold
                                _groupD_by_shop_name => _groupD_by_shop_name.Select(
                                    _itemD => _itemD.vendor_code
                                ).ToArray().Intersect(
                                    ARRAY_B.Select(
                                        _itemB => _itemB.vendor_code
                                    )
                                ).ToArray().Length != 0
                            ).ToArray().Length,

                        country_amount=_groupB_by_category.ToArray().Length
                    }
                ).Select( // make output
                    _item => $"{_item.category} {_item.shop_amount} {_item.country_amount}"
                );
            #endregion process data 

            #region output
                foreach(var _value in _output)
                    Console.WriteLine(_value);
            #endregion output

        }
    }
}