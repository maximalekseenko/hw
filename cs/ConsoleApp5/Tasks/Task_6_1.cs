using System;
using System.Xml;
using System.Xml.Linq;
using Program.Models.Tables;



namespace Program.Tasks
{
    internal class Task_6_1 {
        
        const int TABLE_LENGTH_LIMIT = 4;


        static private XElement _root = null;
        static public XElement root { get { return _root; } }
        static public void Read(string filePath) {
            _root = XElement.Load(filePath);
        }
        static public XElement GetEmployee(string surname) {
            return root.Descendants("Сотрудник")
                .Where(
                    _employee => _employee.Element("ФИО").Value.Split(' ').First() == surname
                ).FirstOrDefault(
                    // TODO: Default
                );
        }
        
        static private void PrintBegin() {
            Console.Clear();
        }


        /// <summary>Prints employee object to the console</summary>
        /// <param name="employee">XElement employee object to print</param>
        /// <param name="print_statistics">bool should payment statistics also be printed</param>
        /// <param name="print_begin">bool should printBegin function be called before printing</param>
        static public void PrintEmployee(XElement employee, bool print_statistics=false, bool print_begin=true) {

            if (print_begin) PrintBegin();

            Console.WriteLine($"ФИО сотрудника: {employee.Element("ФИО").Value}");

            Console.WriteLine($"Год рождения: {employee.Element("Год_рождения").Value}");

            Console.WriteLine($"Сведения о работе:");
            int count_Работа = employee.Element("Список_Работ").Elements().Count();
            foreach(var _job in employee.Element("Список_Работ").Elements()
                .Select(
                    (_el, _index) => _index == TABLE_LENGTH_LIMIT - 2 && count_Работа > TABLE_LENGTH_LIMIT
                        ? new XElement("Работа",
                            new XElement("Название_должности", "..."), 
                            new XElement("Дата_начала", "..."), 
                            new XElement("Дата_окончания", "..."), 
                            new XElement("Отдел", "..."))
                        : _el
                ).Where(
                    (_el, _index) => _index < 3 || _index == count_Работа - 1
                ))
                PrintJob(_job, print_begin=false);

            Console.WriteLine($"Зарплата:");
            int count_Зарплата = employee.Element("Список_Зарплат").Elements().Count();
            foreach(var _payment in employee.Element("Список_Зарплат").Elements()
                .Select(
                    (_el, _index) => _index == TABLE_LENGTH_LIMIT - 2 && count_Зарплата > TABLE_LENGTH_LIMIT
                        ? new XElement("Зарплата", 
                            new XElement("Год", "..."), 
                            new XElement("Месяц", "..."), 
                            new XElement("Итого", "..."))
                        : _el
                ).Where(
                    (_el, _index) => _index < 3 || _index == count_Зарплата - 1
                ))
                PrintPayment(_payment, print_begin=false);

            if (print_statistics) {
                Console.WriteLine($"максимальная заработная плата:");
                PrintPayment(employee.Element("Список_Зарплат").Elements()
                    .MaxBy(
                        _payment => int.Parse(_payment.Element("Итого").Value)
                    ), print_begin=false);
                Console.WriteLine($"минимальная заработная плата:");
                PrintPayment(employee.Element("Список_Зарплат").Elements()
                    .MaxBy(
                        _payment => int.Parse(_payment.Element("Итого").Value)
                    ), print_begin=false);
                Console.WriteLine($"средняя заработная плата: {employee.Element("Список_Зарплат").Elements()
                    .Select( _payment => int.Parse(_payment.Element("Итого").Value))
                    .Average()}");
            }
        }
        
        
        /// <summary>Finds and prints employee object to the console</summary>
        /// <param name="surname">`ФИО` value of employee object to print</param>
        /// <param name="print_statistics">bool should payment statistics also be printed</param>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintEmployee(string surname, bool print_statistics=false, bool print_begin=true) {
            PrintEmployee(GetEmployee(surname), print_statistics, print_begin);
        }
    

        /// <summary>Prints job object to the console</summary>
        /// <param name="job">XElement job object to print</param>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintJob(XElement job, bool print_begin=true) {

            if (print_begin) PrintBegin();

            Console.WriteLine($"{job.Element("Название_должности").Value
                                }\t{job.Element("Дата_начала").Value
                                }\t{job.Element("Дата_окончания").Value
                                }\t{job.Element("Отдел").Value
            }");
        }


        /// <summary>Prints payment object to the console</summary>
        /// <param name="payment">XElement job object to print</param>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintPayment(XElement payment, bool print_begin=true) {

            if (print_begin) PrintBegin();

            Console.WriteLine($"{payment.Element("Год").Value
                                }\t{payment.Element("Месяц").Value
                                }\t{payment.Element("Итого").Value
            }");
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintDepartmentWorkers(bool print_begin=true) {

            if (print_begin) PrintBegin();

            foreach (var item in _root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_окончания").Value == ""
                    ).Select(
                        _job => new {
                            Сотрудник=_employee.Element("ФИО").Value,
                            Отдел=_job.Element("Отдел").Value,
                            Название_должности=_job.Element("Название_должности").Value
                        }
                    )
                ).GroupBy(
                    _item => _item.Отдел
                ).Select(
                    _list => new {
                        Отдел=_list.First().Отдел,
                        Count=_list.Count(),
                        Titles=_list.Select(
                            _item => _item.Название_должности
                        ).Distinct()
                    }
                ).Select(
                    _list => $"{_list.Отдел
                            }\t{_list.Count
                            }\n{_list.Titles.Aggregate(
                                (_title1, _title2) => _title1 + '\t' + _title2
                            )}\n"
                )
            )
                Console.WriteLine(item);
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintWorkersWithMultipleJobs(bool print_begin=true) {

            if (print_begin) PrintBegin();

            foreach (var item in _root.Elements("Сотрудник").Where(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                    _job => _job.Element("Дата_окончания").Value == ""
                ).Count() > 1
                ).Select(
                    _employee => _employee.Element("ФИО").Value
                )
            )
                Console.WriteLine(item);
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintDepartmentsWithLowEmployees(int max_employees, bool print_begin=true) {

            if (print_begin) PrintBegin();

            foreach (var item in _root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_окончания").Value == ""
                    ).Select(
                        _job => new {
                            Сотрудник=_employee.Element("ФИО").Value,
                            Отдел=_job.Element("Отдел").Value
                        }
                    )
                ).GroupBy(
                    _item => _item.Отдел
                ).Where(
                    _group_by_Отдел => _group_by_Отдел.Count() <= max_employees
                ).Select(
                    _group_by_Отдел => $"{_group_by_Отдел.First().Отдел}\t{_group_by_Отдел.Count()}"
                )
            )
                Console.WriteLine(item);
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintMaxMinJobFlowYears(bool print_begin=true) {

            if (print_begin) PrintBegin();

            Console.WriteLine("Max hires: ");
            Console.WriteLine(_root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_начала").Value != ""
                    )
                ).GroupBy(
                    _job => _job.Element("Дата_начала").Value.Split('.').First()
                ).MaxBy(
                    _group_by_Дата_начала => _group_by_Дата_начала.Count()
                ).First().Element("Дата_начала").Value.Split('.').First()
            );

            Console.WriteLine("Min hires: ");
            Console.WriteLine(_root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_начала").Value != ""
                    )
                ).GroupBy(
                    _job => _job.Element("Дата_начала").Value.Split('.').First()
                ).MinBy(
                    _group_by_Дата_начала => _group_by_Дата_начала.Count()
                ).First().Element("Дата_начала").Value.Split('.').First()
            );

            Console.WriteLine("Max fires: ");
            Console.WriteLine(_root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_окончания").Value != ""
                    )
                ).GroupBy(
                    _item => _item.Element("Дата_окончания").Value.Split('.').First()
                ).MaxBy(
                    _group_by_Дата_окончания => _group_by_Дата_окончания.Count()
                ).First().Element("Дата_окончания").Value.Split('.').First()
            );

            Console.WriteLine("Min fires: ");
            Console.WriteLine(_root.Elements("Сотрудник").SelectMany(
                _employee => _employee.Element("Список_Работ").Elements().Where(
                        _job => _job.Element("Дата_окончания").Value != ""
                    )
                ).GroupBy(
                    _item => _item.Element("Дата_окончания").Value.Split('.').First()
                ).MinBy(
                    _group_by_Дата_окончания => _group_by_Дата_окончания.Count()
                ).First().Element("Дата_окончания").Value.Split('.').First()
            );
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void PrintAnniversaries(bool print_begin=true) {

            if (print_begin) PrintBegin();

            foreach (var item in _root.Elements("Сотрудник").Where(
                    _employee => (int.Parse(_employee.Element("Год_рождения").Value) - DateTime.Now.Year) % 10 == 0
                ).Select(
                    _employee => $"{_employee.Element("ФИО").Value}\t{_employee.Element("Год_рождения").Value}"
                )
            )
                Console.WriteLine(item);
        }


        /// <summary></summary>
        /// <param name="print_begin">should printBegin function be called before printing</param>
        static public void Export(string fileName) {
            
            var data = _root.Elements("Сотрудник").SelectMany(
                    _employee => _employee.Element("Список_Работ").Elements().Select(
                        _job => new {
                            Отдел=_job.Element("Отдел").Value,
                            ФИО=_employee.Element("ФИО").Value,
                            Год_рождения=_employee.Element("Год_рождения")
                        }
                    )
                ).GroupBy(
                    _item => _item.Отдел
                ).Select(
                    _group_by_Отдел => new XElement("Отдел",
                        new XAttribute("Название", _group_by_Отдел.First().Отдел),
                        new XElement("Количество_работающих_сотрудников", _group_by_Отдел.Count()),
                        new XElement("Количество_работающих_сотрудников_молодежь", _group_by_Отдел.Where(
                                _item => (int.Parse(_item.Год_рождения.Value) - DateTime.Now.Year) > -30
                            ).Count()
                        )
                    )
                );

            new XElement("Отделы", data).Save("output/"+fileName);
        }


        

        public static void Run(string[] args){
            Read(@"./Data/Table_6.xml");

            if (args.Length < 1) throw new Exception($"this task expects command");


            switch (args[0])
            {
                case "employee":
                    if (args.Length < 2) throw new Exception($"this command expects argument");
                    PrintEmployee(args[1]);
                    break;
                case "workers":
                    PrintDepartmentWorkers();
                    break;
                case "multiworkers":
                    PrintWorkersWithMultipleJobs();
                    break;
                case "low":
                    PrintDepartmentsWithLowEmployees(3);
                    break;
                case "minmax":
                    PrintMaxMinJobFlowYears();
                    break;
                case "anniversary":
                    PrintAnniversaries();
                    break;
                case "export":
                    Export("text.xml");
                    break;
                default: throw new Exception($"unknown command: '{args[0]}'");
            }
        }
    }
}