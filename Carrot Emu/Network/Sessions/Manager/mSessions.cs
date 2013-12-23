using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using prjReborn_iNoX.Network.Sessions.Helper;
using System.Net;
using prjReborn_iNoX.Common.Logging.Manager;
using prjReborn_iNoX.Common.Logging.Helper;
using prjReborn_iNoX.Common.SocketEx;

namespace prjReborn_iNoX.Network.Sessions.Manager
{
    public class mSessions
    {
        public static Socket _s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Dictionary<Socket, hSessions> _sessions = new Dictionary<Socket, hSessions>();

        public mSessions(int _p = 90, int _b = 1000)
        {
            try
            {
                _s.Bind(new IPEndPoint(IPAddress.Any, _p));
                _s.Blocking = false;
                _s.Listen(_b);
                Logger.Log(LoggerColoring.GetColor("green"), "Session Manager started listening..");
                beginAccept();
            }
            catch { }
        }
        public void beginAccept()
        {
            try
            {
                _s.BeginAccept(new AsyncCallback(atAccept), _s);
            }
            catch { }
        }
        public void atAccept(IAsyncResult Iar)
        {
            try
            {
                Socket _n = _s.EndAccept(Iar);
                Logger.Log(LoggerColoring.GetColor("green"), "Session Manager accepted client (IP: "+_n.RemoteEndPoint.ToString().Split(':')[0] + ")");
                hSessions _ns = new hSessions(_n);
                _sessions.Add(_n, _ns);
                beginAccept();
            }
            catch { }
        }
    }
}
