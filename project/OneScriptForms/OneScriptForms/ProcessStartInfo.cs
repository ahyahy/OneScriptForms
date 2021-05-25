using System;
using ScriptEngine.Machine.Contexts;
using Microsoft.VisualBasic;
using System.Security;

namespace osf
{

    public class ProcessStartInfo
    {
        public ClProcessStartInfo dll_obj;
        public System.Diagnostics.ProcessStartInfo M_ProcessStartInfo;

        public ProcessStartInfo(System.Diagnostics.ProcessStartInfo p1)
        {
            M_ProcessStartInfo = p1;
            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
        }

        public ProcessStartInfo(osf.ProcessStartInfo p1)
        {
            M_ProcessStartInfo = p1.M_ProcessStartInfo;
            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
        }

        public ProcessStartInfo(string filename = null, string arguments = null)
        {
            M_ProcessStartInfo = new System.Diagnostics.ProcessStartInfo(filename, arguments);
            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
        }

        //Свойства============================================================

        public string Arguments
        {
            get { return M_ProcessStartInfo.Arguments; }
            set { M_ProcessStartInfo.Arguments = value; }
        }

        public bool CreateNoWindow
        {
            get { return M_ProcessStartInfo.CreateNoWindow; }
            set { M_ProcessStartInfo.CreateNoWindow = value; }
        }

        public string Domain
        {
            get { return M_ProcessStartInfo.Domain; }
            set { M_ProcessStartInfo.Domain = value; }
        }

        public string FileName
        {
            get { return M_ProcessStartInfo.FileName; }
            set { M_ProcessStartInfo.FileName = value; }
        }

        public string Password
        {
            get { return ""; }
            set
            {
                SecureString secureString = new SecureString();
                for (int i = 0; i < Strings.Len(value); i++)
                {
                    secureString.AppendChar(Convert.ToChar(value.Substring(i, 1)));
                }
                M_ProcessStartInfo.Password = secureString;
            }
        }

        public bool RedirectStandardOutput
        {
            get { return M_ProcessStartInfo.RedirectStandardOutput; }
            set { M_ProcessStartInfo.RedirectStandardOutput = value; }
        }

        public string UserName
        {
            get { return M_ProcessStartInfo.UserName; }
            set { M_ProcessStartInfo.UserName = value; }
        }

        public bool UseShellExecute
        {
            get { return M_ProcessStartInfo.UseShellExecute; }
            set { M_ProcessStartInfo.UseShellExecute = value; }
        }

        public int WindowStyle
        {
            get { return (int)M_ProcessStartInfo.WindowStyle; }
            set { M_ProcessStartInfo.WindowStyle = (System.Diagnostics.ProcessWindowStyle)value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлИнформацияЗапускаПроцесса", "ClProcessStartInfo")]
    public class ClProcessStartInfo : AutoContext<ClProcessStartInfo>
    {

        public ClProcessStartInfo(string p1 = null, string p2 = null)
        {
            ProcessStartInfo ProcessStartInfo1 = new ProcessStartInfo(p1, p2);
            ProcessStartInfo1.dll_obj = this;
            Base_obj = ProcessStartInfo1;
        }

        public ClProcessStartInfo(ProcessStartInfo p1)
        {
            ProcessStartInfo ProcessStartInfo1 = p1;
            ProcessStartInfo1.dll_obj = this;
            Base_obj = ProcessStartInfo1;
        }

        public ProcessStartInfo Base_obj;

        //Свойства============================================================

        [ContextProperty("Аргументы", "Arguments")]
        public string Arguments
        {
            get { return Base_obj.Arguments; }
            set { Base_obj.Arguments = value; }
        }

        [ContextProperty("Домен", "Domain")]
        public string Domain
        {
            get { return Base_obj.Domain; }
            set { Base_obj.Domain = value; }
        }

        [ContextProperty("ИмяПользователя", "UserName")]
        public string UserName
        {
            get { return Base_obj.UserName; }
            set { Base_obj.UserName = value; }
        }

        [ContextProperty("ИмяФайла", "FileName")]
        public string FileName
        {
            get { return Base_obj.FileName; }
            set { Base_obj.FileName = value; }
        }

        [ContextProperty("ИспользоватьОболочку", "UseShellExecute")]
        public bool UseShellExecute
        {
            get { return Base_obj.UseShellExecute; }
            set { Base_obj.UseShellExecute = value; }
        }

        [ContextProperty("Пароль", "Password")]
        public string Password
        {
            get { return Base_obj.Password; }
            set { Base_obj.Password = value; }
        }

        [ContextProperty("ПеренаправитьСтандартныйВывод", "RedirectStandardOutput")]
        public bool RedirectStandardOutput
        {
            get { return Base_obj.RedirectStandardOutput; }
            set { Base_obj.RedirectStandardOutput = value; }
        }

        [ContextProperty("СоздатьБезОкна", "CreateNoWindow")]
        public bool CreateNoWindow
        {
            get { return Base_obj.CreateNoWindow; }
            set { Base_obj.CreateNoWindow = value; }
        }

        [ContextProperty("СтильОкна", "WindowStyle")]
        public int WindowStyle
        {
            get { return (int)Base_obj.WindowStyle; }
            set { Base_obj.WindowStyle = value; }
        }

        //Методы============================================================

    }
}
