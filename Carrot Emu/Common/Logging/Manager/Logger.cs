using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prjReborn_iNoX.Common.Logging.Helper;

namespace prjReborn_iNoX.Common.Logging.Manager
{
    public class Logger
    {
        public static int currentItem = 0;
        public static void Init()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 10;
            Console.ForegroundColor = LoggerColoring.GetColor("carrot");
            Console.WriteLine(@"    _______  _______  _______  _______  _______ _________" + Environment.NewLine +
                        @"   (  ____ \(  ___  )(  ____ )(  ____ )(  ___  )\__   __/" + Environment.NewLine +
                        @"   | (    \/| (   ) || (    )|| (    )|| (   ) |   ) ( " + Environment.NewLine +
                        @"   | |      | (___) || (____)|| (____)|| |   | |   | | " + Environment.NewLine +
                        @"   | |      |  ___  ||     __)|     __)| |   | |   | | " + Environment.NewLine +
                        @"   | |      | (   ) || (\ (   | (\ (   | |   | |   | |   " + Environment.NewLine +
                        @"   | (____/\| )   ( || ) \ \__| ) \ \__| (___) |   | |   " + Environment.NewLine +
                        @"   (_______/|/     \||/   \__/|/   \__/(_______)   )_( Development" + Environment.NewLine +
                        @"                                                    By BetterWay (iNoX)");
            // Restore previous position
            Console.SetCursorPosition(x, y);
        }
        public static void Log(ConsoleColor _c, String _input, bool isError = false)
        {
            if (currentItem > 10)
            {
                Console.Clear();
                currentItem = 0;
                Init();
            }
            else
            {
                if (isError)
                {
                    Console.ForegroundColor = LoggerColoring.GetColor("red");
                    Console.WriteLine("[" + LoggerDating.GetTime() + "] ERROR: " + _input);
                    currentItem++;
                }
                else
                {
                    Console.ForegroundColor = _c;
                    Console.WriteLine("[" + LoggerDating.GetTime() + "] LOG: " + _input);
                    currentItem++;
                }
                Init();
            }
        }
    }
}
