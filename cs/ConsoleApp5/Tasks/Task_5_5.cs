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
                var _output = ARRAY_A.GroupBy(
                    _itemA => _itemA.birth_year
                ).Select( // make output object
                    _groupA_by_birth_year => new {
                        birth_year = _groupA_by_birth_year.First().birth_year,

                        country_of_max_prod = ARRAY_B.GroupBy(
                                _itemB => _itemB.manufacture_country
                            ).Select( // B where 
                                _groupB_by_manufacture_country => _groupB_by_manufacture_country.Where(
                                    _itemB => ARRAY_E.Where( // E (having consumer_key in A),
                                        _itemE => ARRAY_A.Select(
                                            _itemA => _itemA.consumer_key
                                        ).ToArray().Contains(_itemE.consumer_key)
                                    ).Select( // contains B's vendor_code
                                        _itemE => _itemE.vendor_code
                                    ).Contains(_itemB.vendor_code)
                                )
                            ).OrderBy(
                                _groupB_by_manufacture_country => _groupB_by_manufacture_country.ToArray().Length
                            ).First().First().manufacture_country,

                        amount_of_max_prod = ARRAY_B.GroupBy(
                                _itemB => _itemB.manufacture_country
                            ).Select( // B where 
                                _groupB_by_manufacture_country => _groupB_by_manufacture_country.Where(
                                    _itemB => ARRAY_E.Where( // E (having consumer_key in A),
                                        _itemE => ARRAY_A.Select(
                                            _itemA => _itemA.consumer_key
                                        ).ToArray().Contains(_itemE.consumer_key)
                                    ).Select( // contains B's vendor_code
                                        _itemE => _itemE.vendor_code
                                    ).Contains(_itemB.vendor_code)
                                ).ToArray().Length
                            ).OrderBy(
                                _length => _length
                            ).First()
                    }
                ).OrderBy( // Sort
                    _item => _item.birth_year
                ).ThenBy(
                    _item => _item.country_of_max_prod
                ).ThenBy(
                    _item => _item.amount_of_max_prod
                ).Select( // format
                    _item => $"{_item.birth_year}\t{_item.country_of_max_prod}\t{_item.amount_of_max_prod}"
                );
            #endregion process data 

            #region output
                foreach(var _value in _output)
                    Console.WriteLine(_value);
            #endregion output

        }
    }
}