namespace Program.Models.Tables
{
    public struct T6_Work { 
        public string job_title { get; set; }
        public int date_begin { get; set; }
        public int date_end { get; set; }
        public string department { get; set; }
        public override string ToString() {
            return $"{job_title}\t{date_begin}\t{date_end}\t{department}";
        }
    }
    public struct T6_Income { 
        public int year { get; set; }
        public int month { get; set; }
        public int total { get; set; }
        public override string ToString() {
            return $"{year}\t{month}\t{total}";
        }
    }
    public struct T6_Employee { 
        public string name_full { get; set; }
        public int birth_year { get; set; }
        public List<T6_Work> work_list { get; set; }
        public List<T6_Income> payment_list { get; set; }
        public override string ToString() {
            return $"{name_full}\t{birth_year}\n{work_list}\n{payment_list}";
        }
    }
}