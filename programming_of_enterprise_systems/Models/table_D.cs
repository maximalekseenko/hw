using System;
using System.Collections.Generic;


namespace Program.Models.Tables
{
    public struct D { 
        public int vendor_code { get; set; }
        public string shop_name { get; set; }
        public int cost { get; set; }
        public override string ToString() {
            return $"{vendor_code}\t{shop_name}\t{cost}";
        }
    }
}