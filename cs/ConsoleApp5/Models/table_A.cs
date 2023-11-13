using System;
using System.Collections.Generic;


namespace Program.Models.Tables
{
    public class A { 
        public int consumer_key { get; set; }
        public int birth_year { get; set; }
        public string residence_street { get; set; }
        public override string ToString() {
            return $"{consumer_key}\t{birth_year}\t{residence_street}";
        }
    }
}