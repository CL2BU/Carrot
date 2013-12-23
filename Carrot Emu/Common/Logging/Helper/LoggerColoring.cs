using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjReborn_iNoX.Common.Logging.Helper
{
    public class LoggerColoring
    {
        public static ConsoleColor GetColor(String color)
        {
            if (color.Equals("red"))
                return ConsoleColor.Red;
            if (color.Equals("blue"))
                return ConsoleColor.Blue;
            if (color.Equals("pink"))
                return ConsoleColor.Magenta;
            if (color.Equals("green"))
                return ConsoleColor.Green;
            if (color.Equals("carrot"))
                return ConsoleColor.DarkYellow;
            return ConsoleColor.White;
        }
    }
}
