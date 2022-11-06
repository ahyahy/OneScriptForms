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
    [ContextClass ("КлDns", "ClDns")]
    public class ClDns : AutoContext<ClDns>
    {
        public ClDns()
        {
        }
        
        [ContextMethod("ПолучитьИмяУзла", "GetHostName")]
        public string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }
        
        [ContextMethod("ПолучитьУзелПоАдресу", "GetHostByAddress")]
        public ClIpHostEntry GetHostByAddress(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(System.Net.Dns.GetHostEntry(p1)));
        }
        
        [ContextMethod("ПолучитьУзелПоИмени", "GetHostByName")]
        public ClIpHostEntry GetHostByName(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(p1));
        }
        
        [ContextMethod("Разрешить", "Resolve")]
        public ClIpHostEntry Resolve(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(System.Net.Dns.GetHostEntry(p1)));
        }
    }
}
