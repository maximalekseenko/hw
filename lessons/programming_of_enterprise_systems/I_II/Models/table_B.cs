using System;
using System.Collections.Generic;


namespace Program.Models.Tables
{
    public class B { 
        public int vendor_code { get; set; }
        public string category { get; set; }
        public string manufacture_country { get; set; }
        public override string ToString() {
            return $"{vendor_code}\t{category}\t{manufacture_country}";
        }
    }
}