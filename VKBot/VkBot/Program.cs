using System;
using System.IO;

namespace MonteceVkBot

{
    class Program
    {      
        static void Main(string[] args)
        {           
            if (MonteceVk.Authorization("3fccfa54ed7a5c8fa15ab967e127dd1027104adb8c2cce515faed7df6e5a2d329d7f5ea37e7fa90b60a6d"))
            {
                bool True = true;

                while (True)
                {
                    switch (Console.ReadLine().ToLower())
                    {
                        case "exit": Environment.Exit(0); break;
                        default: break;
                    }
                }
            }
            Console.WriteLine("Нажмите ENTER чтобы выйти...");
            Console.ReadLine();
        }                  
    }
}
