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
    public class IpHostEntry
    {
        public System.Net.IPHostEntry M_IPHostEntry;

        public IpHostEntry(osf.IpHostEntry p1)
        {
            M_IPHostEntry = p1.M_IPHostEntry;
        }

        public IpHostEntry(string HostName)
        {
            M_IPHostEntry = new IPHostEntry();
            M_IPHostEntry.HostName = HostName;

            string[] aliases = new string[0];
            M_IPHostEntry.Aliases = aliases;

            IPAddress[] addressList = new IPAddress[0];
            M_IPHostEntry.AddressList = addressList;
        }

        public IpHostEntry(System.Net.IPHostEntry p1)
        {
            M_IPHostEntry = p1;
        }

        public string HostName
        {
            get { return M_IPHostEntry.HostName; }
            set { M_IPHostEntry.HostName = value; }
        }

        public override string ToString()
        {
            return M_IPHostEntry.ToString();
        }
    }

    [ContextClass ("КлIpУзел", "ClIpHostEntry")]
    public class ClIpHostEntry : AutoContext<ClIpHostEntry>
    {
        public ClIpHostEntry(string p1)
        {
            IpHostEntry IpHostEntry1 = new IpHostEntry(p1);
            Base_obj = IpHostEntry1;
        }
		
        public ClIpHostEntry(osf.IpHostEntry p1)
        {
            Base_obj = p1;
        }

        public IpHostEntry Base_obj;
        
        [ContextProperty("Адреса", "AddressList")]
        public ClArrayList AddressList
        {
            get
            {
                osf.ClArrayList ClArrayList1 = new ClArrayList();
                for (int i = 0; i < Base_obj.M_IPHostEntry.AddressList.Length; i++)
                {
                    IpAddress IpAddress1 = new IpAddress(Base_obj.M_IPHostEntry.AddressList[i]);
                    ClIpAddress ClIpAddress1 = new ClIpAddress(IpAddress1);
                    ClArrayList1.Add(ClIpAddress1);
                }
                return ClArrayList1;
            }
            set
            {
                Base_obj.M_IPHostEntry.AddressList = new IPAddress[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    ClIpAddress ClIpAddress1 = (ClIpAddress)value.Item(i);
                    IpAddress IpAddress1 = ClIpAddress1.Base_obj;
                    Base_obj.M_IPHostEntry.AddressList[i] = IpAddress1.M_IPaddress;
                }
            }
        }
        
        [ContextProperty("ИмяУзла", "HostName")]
        public string HostName
        {
            get { return Base_obj.HostName; }
            set { Base_obj.HostName = value; }
        }

        [ContextProperty("Псевдонимы", "Aliases")]
        public ClArrayList Aliases
        {
            get
            {
                osf.ClArrayList ClArrayList1 = new ClArrayList();
                for (int i = 0; i < Base_obj.M_IPHostEntry.Aliases.Length; i++)
                {
                    string alias = Base_obj.M_IPHostEntry.Aliases[i];
                    ClArrayList1.Add(ValueFactory.Create(alias));
                }
                return ClArrayList1;
            }
            set
            {
                Base_obj.M_IPHostEntry.Aliases = new string[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    Base_obj.M_IPHostEntry.Aliases[i] = value.Item(i).AsString();
                }
            }
        }
        
    }
}
