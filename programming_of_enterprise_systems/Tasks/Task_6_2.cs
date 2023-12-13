using System;
using System.Xml;
using System.Xml.Linq;
using Program.Models.Tables;
using System.Text;
using System.Globalization;



namespace Program.Tasks
{
    internal class Task_6_2 {
        
        public static void Run(string[] args){
            if (args.Length < 3) throw new Exception("this task expects 3 arguments");
            var date_req1 = args[0] == "a"? "02.01.2021" : args[0];
            var date_req2 = args[1] == "a"? "20.02.2021" : args[1];
            var VAL_NM_RQ = args[2] == "a"? "R01235" : args[2];

            Console.WriteLine(date_req1+date_req2+VAL_NM_RQ);
            const int CHART_WIDTH = 50;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var data = XElement.Load($"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={date_req1}&date_req2={date_req2}&VAL_NM_RQ={VAL_NM_RQ}");
            
            var data_values = data.Elements("Record").OrderBy(
                _record => DateTime.ParseExact(_record.Attribute("Date").Value, "dd.MM.yyyy", null)
            ).Select(
                _record => double.Parse(_record.Element("Value").Value.Replace(',', '.')) / double.Parse(_record.Element("Nominal").Value.Replace(',', '.'))
            );

            var data_max = data_values.Max();
            
            var data_min = data_values.Min();

            Console.WriteLine(data_min + new string('-', CHART_WIDTH - data_min.ToString().Length +1) + data_max);
            foreach (var _value in data_values) {
                var _percent = Convert.ToInt32(Math.Round((_value - data_min) / (data_max - data_min) * CHART_WIDTH));
                Console.WriteLine(new string('-', _percent) + '*' + new string('.', CHART_WIDTH - _percent));
            }
        }
    }
}