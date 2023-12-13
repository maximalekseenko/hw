namespace Program.Tasks
{
    class TaskRunner {
        public static void Run(string taskName, string[] args)
        {
            switch (taskName)
            {
                case "4.1":
                    Task_4_1.Run(args);
                    break;
                case "4.2":
                    Task_4_2.Run(args);
                    break;
                case "4.3":
                    Task_4_3.Run(args);
                    break;
                case "4.4":
                    Task_4_4.Run(args);
                    break;
                case "4.5":
                    Task_4_5.Run(args);
                    break;
                case "4.6":
                    Task_4_6.Run(args);
                    break;
                case "4.7":
                    Task_4_7.Run(args);
                    break;
                case "4.8":
                    Task_4_8.Run(args);
                    break;
                case "4.9":
                    Task_4_9.Run(args);
                    break;
                case "4.10":
                    Task_4_10.Run(args);
                    break;
                case "4.11":
                    Task_4_11.Run(args);
                    break;

                case "5.1":
                    Task_5_1.Run(args);
                    break;
                case "5.2":
                    Task_5_2.Run(args);
                    break;
                case "5.3":
                    Task_5_2.Run(args);
                    break;
                case "5.4":
                    Task_5_4.Run(args);
                    break;
                case "5.5":
                    Task_5_5.Run(args);
                    break;
                case "5.6":
                    Task_5_6.Run(args);
                    break;
                case "5.7":
                    Task_5_7.Run(args);
                    break;
                case "5.8":
                    Task_5_8.Run(args);
                    break;
                case "6.1":
                    Task_6_1.Run(args);
                    break;
                case "6.2":
                    Task_6_2.Run(args);
                    break;
                default:
                    Console.WriteLine($"Task \"{taskName}\" not found");
                    break;
            }
        }
    }
}