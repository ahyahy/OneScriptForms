using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ProcessEx : System.Diagnostics.Process
    {
        public osf.Process M_Object;
    }

    public class Process
    {
        public ClProcess dll_obj;
        public ProcessEx M_Process;

        public Process()
        {
            M_Process = new ProcessEx();
            M_Process.M_Object = this;
        }

        public Process(osf.Process p1)
        {
            M_Process = p1.M_Process;
            M_Process.M_Object = this;
        }

        public Process(System.Diagnostics.Process p1)
        {
            M_Process = (ProcessEx)p1;
            M_Process.M_Object = this;
        }

        //Свойства============================================================

        public bool HasExited
        {
            get { return M_Process.HasExited; }
        }

        public osf.StreamReader StandardOutput
        {
            get { return new StreamReader(M_Process.StandardOutput); }
        }

        public osf.ProcessStartInfo StartInfo
        {
            get { return new ProcessStartInfo(M_Process.StartInfo); }
            set { M_Process.StartInfo = (System.Diagnostics.ProcessStartInfo)value.M_ProcessStartInfo; }
        }

        //Методы============================================================

        public osf.Process Start()
        {
            M_Process.Start();
            return this;
        }

    }

    [ContextClass ("КлПроцесс", "ClProcess")]
    public class ClProcess : AutoContext<ClProcess>
    {

        public ClProcess()
        {
            Process Process1 = new Process();
            Process1.dll_obj = this;
            Base_obj = Process1;
        }
		
        public ClProcess(Process p1)
        {
            Process Process1 = p1;
            Process1.dll_obj = this;
            Base_obj = Process1;
        }
        
        public Process Base_obj;

        //Свойства============================================================

        [ContextProperty("Завершен", "HasExited")]
        public bool HasExited
        {
            get { return Base_obj.HasExited; }
        }

        [ContextProperty("НачальнаяИнформация", "StartInfo")]
        public ClProcessStartInfo StartInfo
        {
            get { return (ClProcessStartInfo)OneScriptForms.RevertObj(Base_obj.StartInfo); }
            set { Base_obj.StartInfo = value.Base_obj; }
        }

        [ContextProperty("СтандартныйВывод", "StandardOutput")]
        public ClStreamReader StandardOutput
        {
            get { return (ClStreamReader)OneScriptForms.RevertObj(Base_obj.StandardOutput); }
        }

        //Методы============================================================

        [ContextMethod("Начать", "Start")]
        public ClProcess Start()
        {
            return new ClProcess(Base_obj.Start());
        }
    }
}
