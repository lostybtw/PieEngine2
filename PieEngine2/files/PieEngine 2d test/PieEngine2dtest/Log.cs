using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieEngine_2d_test.PieEngine2dtest
{
    public class Log
    {
        public static void Debug(string log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[Debug] {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void INFO(string log)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string log)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Warning] {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
