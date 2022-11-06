using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ToolTipEx : System.Windows.Forms.ToolTip
    {
        public osf.ToolTip M_Object;
    }

    public class ToolTip
    {
        public ClToolTip dll_obj;
        public ToolTipEx M_ToolTip;

        public ToolTip()
        {
            M_ToolTip = new ToolTipEx();
            M_ToolTip.M_Object = this;
        }

        public ToolTip(osf.ToolTip p1)
        {
            M_ToolTip = p1.M_ToolTip;
            M_ToolTip.M_Object = this;
        }

        public ToolTip(System.Windows.Forms.ToolTip p1)
        {
            M_ToolTip = (ToolTipEx)p1;
            M_ToolTip.M_Object = this;
        }

        public bool Active
        {
            get { return M_ToolTip.Active; }
            set { M_ToolTip.Active = value; }
        }

        public int AutomaticDelay
        {
            get { return M_ToolTip.AutomaticDelay; }
            set { M_ToolTip.AutomaticDelay = value; }
        }

        public int AutoPopDelay
        {
            get { return M_ToolTip.AutoPopDelay; }
            set { M_ToolTip.AutoPopDelay = value; }
        }

        public int InitialDelay
        {
            get { return M_ToolTip.InitialDelay; }
            set { M_ToolTip.InitialDelay = value; }
        }

        public int ReshowDelay
        {
            get { return M_ToolTip.ReshowDelay; }
            set { M_ToolTip.ReshowDelay = value; }
        }

        public bool ShowAlways
        {
            get { return M_ToolTip.ShowAlways; }
            set { M_ToolTip.ShowAlways = value; }
        }

        public string GetToolTip(Control p1)
        {
            return M_ToolTip.GetToolTip(p1.M_Control);
        }

        public void RemoveAll()
        {
            M_ToolTip.RemoveAll();
        }

        public void SetToolTip(Control p1, string p2)
        {
            M_ToolTip.SetToolTip(p1.M_Control, p2);
        }
    }

    [ContextClass ("КлПодсказка", "ClToolTip")]
    public class ClToolTip : AutoContext<ClToolTip>
    {
        public ClToolTip()
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.dll_obj = this;
            Base_obj = ToolTip1;
        }
		
        public ClToolTip(ToolTip p1)
        {
            ToolTip ToolTip1 = p1;
            ToolTip1.dll_obj = this;
            Base_obj = ToolTip1;
        }
        
        public ToolTip Base_obj;
        
        [ContextProperty("АвтоЗадержка", "AutomaticDelay")]
        public int AutomaticDelay
        {
            get { return Base_obj.AutomaticDelay; }
            set { Base_obj.AutomaticDelay = value; }
        }

        [ContextProperty("АвтоЗадержкаПоказа", "AutoPopDelay")]
        public int AutoPopDelay
        {
            get { return Base_obj.AutoPopDelay; }
            set { Base_obj.AutoPopDelay = value; }
        }

        [ContextProperty("Активна", "Active")]
        public bool Active
        {
            get { return Base_obj.Active; }
            set { Base_obj.Active = value; }
        }

        [ContextProperty("ЗадержкаОчередногоПоказа", "ReshowDelay")]
        public int ReshowDelay
        {
            get { return Base_obj.ReshowDelay; }
            set { Base_obj.ReshowDelay = value; }
        }

        [ContextProperty("ЗадержкаПоявления", "InitialDelay")]
        public int InitialDelay
        {
            get { return Base_obj.InitialDelay; }
            set { Base_obj.InitialDelay = value; }
        }

        [ContextProperty("ПоказыватьВсегда", "ShowAlways")]
        public bool ShowAlways
        {
            get { return Base_obj.ShowAlways; }
            set { Base_obj.ShowAlways = value; }
        }
        
        [ContextMethod("ПолучитьПодсказку", "GetToolTip")]
        public IValue GetToolTip(IValue p1)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            if ((p3.GetType() == typeof(Aga.Controls.Tree.Node)) ||
                (p3.GetType().ToString().Contains("Aga.Controls.Tree.NodeControls.")) ||
                (p3.GetType() == typeof(osf.TreeColumn)))
            {
                System.Collections.Generic.Dictionary<osf.ClToolTip, object> dict = p3.ObjTooltip;
                object toolTip = dict[this];
                if (toolTip.GetType() == typeof(System.String))
                {
                    return ValueFactory.Create((string)toolTip);
                }
                return (IValue)toolTip;
            }
            else
            {
                return ValueFactory.Create(Base_obj.GetToolTip(((dynamic)p1).Base_obj));
            }
        }
        
        [ContextMethod("УдалитьВсе", "RemoveAll")]
        public void RemoveAll()
        {
            Base_obj.RemoveAll();
        }
					
        [ContextMethod("УстановитьПодсказку", "SetToolTip")]
        public void SetToolTip(IValue p1, IValue p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            if (p2.SystemType.Name == "Строка")
            {
                string str = p2.AsString();
                if ((p3.GetType() == typeof(Aga.Controls.Tree.Node)) ||
                    (p3.GetType().ToString().Contains("Aga.Controls.Tree.NodeControls.")) ||
                    (p3.GetType() == typeof(osf.TreeColumn)))
                {
                    p3.TooltipText = str;
                    System.Collections.Generic.Dictionary<osf.ClToolTip, object> dict = p3.ObjTooltip;
                    if (!dict.ContainsKey(this))
                    {
                        dict.Add(this, str);
                    }
                    else
                    {
                        if (!((object)dict[this]).Equals(str))
                        {
                            dict[this] = str;
                        }
                    }
                }
                else
                {
                    Base_obj.SetToolTip(p3, str);
                }
            }
            else
            {
                ClAction action = (ClAction)p2;
                p3.TooltipText = action;
                System.Collections.Generic.Dictionary<osf.ClToolTip, object> dict = p3.ObjTooltip;
                if (!dict.ContainsKey(this))
                {
                    dict.Add(this, action);
                }
                else
                {
                    if (!((object)dict[this]).Equals(action))
                    {
                        dict[this] = action;
                    }
                }
            }
        }
    }
}
