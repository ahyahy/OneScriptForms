using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{

    public class EventArgs
    {
        public ClEventArgs dll_obj;
        public string EventString = "";
        public dynamic Parameter;
        public dynamic Sender;

        public EventArgs()
        {
            Sender = null;
            Parameter = null;
        }

        //Свойства============================================================

        //Методы============================================================

        public virtual bool PostEvent()
        {
            if (Sender.GetType() == typeof(osf.ComboBox))
            {
                string s = "";
                osf.ComboBox ComboBox1 = (osf.ComboBox)Sender;
                if (ComboBox1.DrawMode != 0)
                {
                    dynamic item = ComboBox1.Items[ComboBox1.SelectedIndex];
                    if (Sender.GetType() == typeof(osf.ComboBox))
                    {
                        string ObjType = item.GetType().ToString();
                        if (ObjType == "System.Data.DataRowView")
                        {
                            System.Data.DataRowView drv = (System.Data.DataRowView)item;
                            try
                            {
                                dynamic var1 = drv.Row[ComboBox1.DisplayMember];
                                System.Type Type1 = var1.GetType();
                                s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                            }
                            catch
                            {
                                if (drv.Row[ComboBox1.DisplayMember].GetType() == typeof(System.Boolean))
                                {
                                    ScriptEngine.Machine.Values.BooleanValue Bool1;
                                    if ((System.Boolean)drv.Row[ComboBox1.DisplayMember])
                                    {
                                        Bool1 = ScriptEngine.Machine.Values.BooleanValue.True;
                                    }
                                    else
                                    {
                                        Bool1 = ScriptEngine.Machine.Values.BooleanValue.False;
                                    }
                                    s = Bool1.ToString();
                                }
                                else
                                {
                                    s = drv.Row[ComboBox1.DisplayMember].ToString();
                                }
                            }
                        }
                    }
                    else if (Sender.GetType() == typeof(osf.ListItem))
                    {

                    }
                    if (s == "")
                    {
                        try
                        {
                            System.Type Type1 = item.GetType();
                            s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                        }
                        catch
                        {
                            s = item.ToString();
                        }
                    }
                    ComboBox1.Text = s;
                }
            }
            return true;
        }

    }

    [ContextClass ("КлАргументыСобытия", "ClEventArgs")]
    public class ClEventArgs : AutoContext<ClEventArgs>
    {

        public ClEventArgs()
        {
            EventArgs EventArgs1 = new EventArgs();
            EventArgs1.dll_obj = this;
            Base_obj = EventArgs1;
        }
		
        public ClEventArgs(EventArgs p1)
        {
            EventArgs EventArgs1 = p1;
            EventArgs1.dll_obj = this;
            Base_obj = EventArgs1;
        }
        
        public EventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }
        
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        //Методы============================================================

    }
}
