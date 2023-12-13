using System;
using System.Collections.Generic;


namespace Program.Models.Tables
{
    public class C { 
        public int consumer_key { get; set; }
        public string shop_name { get; set; }
        public double discount { get; set; }
        public override string ToString() {
            return $"{consumer_key}\t{shop_name}\t{discount}";
        }
    }
}