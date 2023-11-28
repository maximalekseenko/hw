using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_2 {
        public static void Run(string[] args){

            #region get data 
                var ARRAY_B = TableReader.AccessTable<B>("table_B");
                var ARRAY_D = TableReader.AccessTable<D>("table_D");                
            #endregion get data 

            #region process data 
                var _output = 

                #region make data
                    ARRAY_B.GroupBy(
                        _itemB => _itemB.category
                    ).Select( // get output data
                        _groupB_by_category => new {

                            shop_amount=ARRAY_D.GroupBy(
                                    _itemD => _itemD.shop_name
                                ).Count( // get amount of shops where such category is sold
                                    _groupD_by_shop_name => _groupD_by_shop_name.Count(
                                        _itemD => ARRAY_B.Any(
                                            _itemB => _itemB.vendor_code == _itemD.vendor_code
                                        )
                                    ) != 0
                                ),

                            category=(_groupB_by_category.FirstOrDefault(new B())).category,

                            country_amount=_groupB_by_category.Count()
                        }
                #endregion make data

                #region sort data
                    ).OrderBy(
                        _item => _item.shop_amount
                    ).ThenBy(
                        _item => _item.category
                    ).ThenBy(
                        _item => _item.country_amount
                #endregion sort data
                
                #region format output
                    ).Select(
                        _item => $"{_item.shop_amount
                                }\t{_item.category
                                }\t{_item.country_amount
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