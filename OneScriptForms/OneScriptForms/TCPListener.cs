using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Net.Sockets;

namespace osf
{
    public class TCPListener
    {
        public ClTCPListener dll_obj;
        private System.Net.Sockets.TcpListener M_TcpListener;

        public TCPListener(osf.IpAddress p1, int p2)
        {
            M_TcpListener = new System.Net.Sockets.TcpListener(p1.IPaddress, p2);
        }

        public TCPListener(osf.TCPListener p1)
        {
            M_TcpListener = p1.M_TcpListener;
        }

        public TCPListener(System.Net.IPAddress p1, int p2)
        {
            M_TcpListener = new System.Net.Sockets.TcpListener(p1, p2);
        }

        public TCPListener(System.Net.Sockets.TcpListener p1)
        {
            M_TcpListener = p1;
        }

        public bool Active
        {
            get
            {
                bool res = (bool)typeof(System.Net.Sockets.TcpListener).InvokeMember(
                        "Active",
                        BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        M_TcpListener,
                        null);

                return res;
            }
        }

        public osf.TCPClient AcceptTCPclient()
        {
            return new osf.TCPClient(M_TcpListener.AcceptTcpClient());
        }

        public bool Pending()
        {
            return M_TcpListener.Pending();
        }

        public void Start()
        {
            M_TcpListener.Start();
        }

        public void Stop()
        {
            M_TcpListener.Stop();
        }
    }

    [ContextClass ("КлTCPСлушатель", "ClTCPListener")]
    public class ClTCPListener : AutoContext<ClTCPListener>
    {
        public ClTCPListener(ClIpAddress p1, int p2)
        {
            TCPListener TCPListener1 = new TCPListener(p1.Base_obj, p2);
            TCPListener1.dll_obj = this;
            Base_obj = TCPListener1;
        }
		
        public ClTCPListener(osf.TCPListener p1)
        {
            TCPListener TCPListener1 = p1;
            TCPListener1.dll_obj = this;
            Base_obj = TCPListener1;
        }

        public TCPListener Base_obj;
        
        [ContextProperty("Активен", "Active")]
        public bool Active
        {
            get { return Base_obj.Active; }
        }
        
        [ContextMethod("Начать", "Start")]
        public void Start()
        {
            Base_obj.Start();
        }
					
        [ContextMethod("Ожидающие", "Pending")]
        public bool Pending()
        {
            return Base_obj.Pending();
        }

        [ContextMethod("Остановить", "Stop")]
        public void Stop()
        {
            Base_obj.Stop();
        }
					
        [ContextMethod("ПринимающийКлиент", "AcceptTCPclient")]
        public ClTCPClient AcceptTCPclient()
        {
            return new ClTCPClient(Base_obj.AcceptTCPclient());
        }
    }
}
