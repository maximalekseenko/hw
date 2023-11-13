namespace Program.Tasks
{
    class TaskRunner {
        public static void Run(string taskName)
        {
            switch (taskName)
            {
                case "5.1":
                    Task_5_1.Run();
                    break;
                case "5.2":
                    Task_5_2.Run();
                    break;
                case "5.3":
                    Task_5_2.Run();
                    break;
                case "5.4":
                    Task_5_4.Run();
                    break;
                case "5.5":
                    Task_5_5.Run();
                    break;
                case "5.6":
                    Task_5_6.Run();
                    break;
                case "5.7":
                    Task_5_7.Run();
                    break;
                case "5.8":
                    Task_5_8.Run();
                    break;
                default:
                    Console.WriteLine($"Task \"{taskName}\" not found");
                    break;
            }
        }
    }
}