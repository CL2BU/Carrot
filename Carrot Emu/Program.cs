using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prjReborn_iNoX.Common.Logging.Manager;
using prjReborn_iNoX.Network.Sessions.Manager;
using System.Diagnostics;
using System.Threading;

namespace prjReborn_iNoX
{
    public class Program
    {
        public static mSessions sM;
        public static void Main(string[] args)
        {
            Logger.Init();
            sM = new mSessions();
            Thread _t = new Thread(new ThreadStart(CheckMem));
            _t.Start();
            while (true) ;
        }
        public static void CheckMem()
        {
            while (true)
            {
                // get the current process
                Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();

                // get the physical mem usage
                long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
                long totalMegaBytes = (totalBytesOfMemoryUsed / 1024 / 1024);
                Console.Title = "Carrot Emulator ~ Sessions: " + mSessions._sessions.Count + ", RAM: " + totalMegaBytes + "MB";
                Thread.Sleep(1200);
            }
        }
    }
}
