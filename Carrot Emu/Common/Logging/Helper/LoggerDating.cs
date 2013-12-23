using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjReborn_iNoX.Common.Logging.Helper
{
    public class LoggerDating
    {
        public static String GetTime()
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
}
