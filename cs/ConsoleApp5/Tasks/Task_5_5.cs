using System;
using System.Collections.Generic;
using System.Linq;
using Program.Models.Tables;

namespace Program.Tasks
{
    internal class Task_5_5 {
        public static void Run(){

            #region get data                 
                var ARRAY_A = TableReader.AccessTable<A>("table_A");
                var ARRAY_B = TableReader.AccessTable<B>("table_B");                
                var ARRAY_E = TableReader.AccessTable<E>("table_E");
            #endregion get data 

            #region process data 
                var _output = 

                #region make data
                    ARRAY_A.GroupBy(
                        _itemA => _itemA.birth_year
                    ).Select( // make output object
                        _groupA_by_birth_year => new {
                            birth_year = _groupA_by_birth_year.FirstOrDefault(new A()).birth_year,

                            country_of_max_prod = ARRAY_B.GroupBy(
                                    _itemB => _itemB.manufacture_country
                                ).Select(
                                    _groupB_by_manufacture_country => _groupB_by_manufacture_country.Where(
                                        _itemB => ARRAY_E.Any(
                                            _itemE => _groupA_by_birth_year.Any(
                                                    _itemA => _itemA.consumer_key == _itemE.consumer_key
                                                ) && _itemE.vendor_code == _itemB.vendor_code
                                        )
                                    )
                                ).MaxBy(
                                    _groupB_by_manufacture_country => _groupB_by_manufacture_country.Count()
                                ).FirstOrDefault(new B()).manufacture_country,

                            amount_of_max_prod = ARRAY_B.GroupBy(
                                    _itemB => _itemB.manufacture_country
                                ).Select( 
                                    _groupB_by_manufacture_country => _groupB_by_manufacture_country.Where(
                                        _itemB => ARRAY_E.Any(
                                            _itemE => _groupA_by_birth_year.Any(
                                                    _itemA => _itemA.consumer_key == _itemE.consumer_key
                                                ) && _itemE.vendor_code == _itemB.vendor_code
                                        )
                                    )
                                ).Max(
                                    _groupB_by_manufacture_country => _groupB_by_manufacture_country.Count()
                                )
                        }
                #endregion make data

                #region sort data
                    ).OrderBy(
                        _item => _item.birth_year
                    ).ThenBy(
                        _item => _item.country_of_max_prod
                    ).ThenBy(
                        _item => _item.amount_of_max_prod
                #endregion sort data
                
                #region format output
                    ).Select( 
                        _item => $"{_item.birth_year
                                }\t{_item.country_of_max_prod
                                }\t{_item.amount_of_max_prod
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