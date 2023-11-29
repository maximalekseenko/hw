namespace Program.Tasks
{
    class TaskRunner {
        public static void Run(string taskName, string[] args)
        {
            switch (taskName)
            {
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