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
    public class TCPClient
    {
        public ClTCPClient dll_obj;
        private System.Net.Sockets.TcpClient M_TcpClient;

        public TCPClient(string HostName = null, int port = 0)
        {
            if (HostName != null && port != 0)
            {
                M_TcpClient = new System.Net.Sockets.TcpClient(HostName, port);
            }
            else if (HostName == null && port == 0)
            {
                M_TcpClient = new System.Net.Sockets.TcpClient();
            }
            else
            {
                return;
            }
        }

        public TCPClient(System.Net.Sockets.TcpClient p1)
        {
            M_TcpClient = p1;
        }

        public TCPClient(TCPClient p1)
        {
            M_TcpClient = p1.M_TcpClient;
        }

        public bool Connected
        {
            get { return M_TcpClient.Connected; }
        }

        public void Close()
        {
            M_TcpClient.Close();
        }

        public void Connect(IpAddress ipaddress, int portNo)
        {
            M_TcpClient.Connect(ipaddress.IPaddress, portNo);
        }

        public void Connect(string hostname, int portNo)
        {
            M_TcpClient.Connect(hostname, portNo);
        }

        public System.Net.Sockets.NetworkStream GetStream()
        {
            return M_TcpClient.GetStream();
        }
    }

    [ContextClass ("КлTCPКлиент", "ClTCPClient")]
    public class ClTCPClient : AutoContext<ClTCPClient>
    {
        public ClTCPClient(string HostName = null, int port = 0)
        {
            TCPClient TCPClient1 = new TCPClient(HostName, port);
            TCPClient1.dll_obj = this;
            Base_obj = TCPClient1;
        }
		
        public ClTCPClient(TCPClient p1)
        {
            TCPClient TCPClient1 = p1;
            TCPClient1.dll_obj = this;
            Base_obj = TCPClient1;
        }

        public TCPClient Base_obj;
        
        [ContextProperty("Подключен", "Connected")]
        public bool Connected
        {
            get { return Base_obj.Connected; }
        }
        
        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }
					
        [ContextMethod("Подключить", "Connect")]
        public void Connect(IValue p1, int p2)
        {
            if (p1.SystemType.Name == "Строка")
            {
                Base_obj.Connect(p1.AsString(), p2);
            }
            else
            {
                Base_obj.Connect(((ClIpAddress)p1).Base_obj, p2);
            }
        }
        
        [ContextMethod("ПолучитьПоток", "GetStream")]
        public ClNetworkStream GetStream()
        {
            return new ClNetworkStream(Base_obj.GetStream());
        }
    }
}
