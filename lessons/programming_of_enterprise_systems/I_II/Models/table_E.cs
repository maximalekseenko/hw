using System;
using System.Collections.Generic;


namespace Program.Models.Tables
{
    public struct E { 
        public int consumer_key { get; set; }
        public int vendor_code { get; set; }
        public string shop_name { get; set; }
        public override string ToString() {
            return $"{consumer_key}\t{vendor_code}\t{shop_name}";
        }
    }
}