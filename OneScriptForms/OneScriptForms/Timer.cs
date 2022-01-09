using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TimerEx : System.Windows.Forms.Timer
    {
        public osf.Timer M_Object;
    }

    public class Timer : Component
    {
        public ClTimer dll_obj;
        public TimerEx M_Timer;
        public string Tick;

        public Timer()
        {
            M_Timer = new TimerEx();
            M_Timer.M_Object = this;
            base.M_Component = M_Timer;
            M_Timer.Tick += M_Timer_Tick1;
            Tick = "";
        }

        public Timer(osf.Timer p1)
        {
            M_Timer = p1.M_Timer;
            M_Timer.M_Object = this;
            base.M_Component = M_Timer;
            M_Timer.Tick += M_Timer_Tick1;
            Tick = "";
        }

        public Timer(System.Windows.Forms.Timer p1)
        {
            M_Timer = (TimerEx)p1;
            M_Timer.M_Object = this;
            base.M_Component = M_Timer;
            M_Timer.Tick += M_Timer_Tick1;
            Tick = "";
        }

        public int Interval
        {
            get { return M_Timer.Interval; }
            set { M_Timer.Interval = value; }
        }

        public void M_Timer_Tick1(object sender, System.EventArgs e)
        {
            if (Tick.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Tick;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Tick);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Tick);
            }
        }

        public void Start()
        {
            M_Timer.Start();
        }

        public void Stop()
        {
            M_Timer.Stop();
        }
    }

    [ContextClass ("КлТаймер", "ClTimer")]
    public class ClTimer : AutoContext<ClTimer>
    {
        private IValue _Tick;
        private ClCollection tag = new ClCollection();

        public ClTimer()
        {
            Timer Timer1 = new Timer();
            Timer1.dll_obj = this;
            Base_obj = Timer1;
        }
		
        public ClTimer(Timer p1)
        {
            Timer Timer1 = p1;
            Timer1.dll_obj = this;
            Base_obj = Timer1;
        }
        
        public Timer Base_obj;
        
        [ContextProperty("Интервал", "Interval")]
        public int Interval
        {
            get { return Base_obj.Interval; }
            set { Base_obj.Interval = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("ПриСрабатыванииТаймера", "Tick")]
        public IValue Tick
        {
            get { return _Tick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Tick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Tick = "DelegateActionTick";
                }
                else
                {
                    _Tick = value;
                    Base_obj.Tick = "osfActionTick";
                }
            }
        }
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextMethod("Начать", "Start")]
        public void Start()
        {
            Base_obj.Start();
        }
					
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("Остановить", "Stop")]
        public void Stop()
        {
            Base_obj.Stop();
        }
    }
}
