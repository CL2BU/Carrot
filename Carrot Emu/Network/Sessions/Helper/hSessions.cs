using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using prjReborn_iNoX.Common.Logging.Manager;
using prjReborn_iNoX.Common.Logging.Helper;
using prjReborn_iNoX.Network.Sessions.Manager;

namespace prjReborn_iNoX.Network.Sessions.Helper
{
    public class hSessions
    {
        public Socket _u;
        public byte[] _b;

        public hSessions(Socket _sInput)
        {
            this._u = _sInput;
            this._b = new byte[4096];
            beginRecv();
        }
        public void beginRecv()
        {
            try
            {
                this._u.BeginReceive(this._b, 0, this._b.Length, SocketFlags.None, new AsyncCallback(atRecv), this._u);
            }
            catch { }
        }
        public void atRecv(IAsyncResult Iar)
        {
            try
            {
                int _r = this._u.EndReceive(Iar);
                if (_r > 0)
                {
                    String data = Encoding.Default.GetString(this._b, 0, _r);
                    Logger.Log(LoggerColoring.GetColor("green"), "[SESSION] [IP: " + this._u.RemoteEndPoint.ToString().Split(':')[0] + "] Received data");
                    // TODO: Add Crypto
                }
                else
                {
                    this._u.Close();
                    this._u.Dispose();
                    mSessions._sessions.Remove(this._u);
                }
                beginRecv();
            }
            catch
            {
                this._u.Close();
                this._u.Dispose();
                mSessions._sessions.Remove(this._u);
            }
        }
    }
}
