﻿using Program.Tasks;


namespace Program
{
    internal class Program {

        public static void Main(string[] args)
        {
            TaskRunner.Run(args[0], args.Skip(1).ToArray());
        }
    }
}