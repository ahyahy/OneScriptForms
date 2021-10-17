using System;

namespace osf
{

    public class ScrollBar : Control
    {
        public ClArrayList ManagedProperties = new ClArrayList();
        public string Scroll;
        public dynamic v_h_ScrollBar;
        public string ValueChanged;

        public ScrollBar()
        {
        }

        //Свойства============================================================

        public int LargeChange
        {
            get { return M_ScrollBar.LargeChange; }
            set
            {
                M_ScrollBar.LargeChange = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public System.Windows.Forms.ScrollBar M_ScrollBar
        {
            get { return v_h_ScrollBar; }
            set
            {
                v_h_ScrollBar = value;
                base.M_Control = v_h_ScrollBar;
            }
        }

        public int Maximum
        {
            get { return M_ScrollBar.Maximum; }
            set
            {
                M_ScrollBar.Maximum = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int Minimum
        {
            get { return M_ScrollBar.Minimum; }
            set
            {
                M_ScrollBar.Minimum = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int SmallChange
        {
            get { return M_ScrollBar.SmallChange; }
            set
            {
                M_ScrollBar.SmallChange = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int Value
        {
            get { return M_ScrollBar.Value; }
            set
            {
                M_ScrollBar.Value = value;
                ScrollBarManagedProperties();
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

        public void M_ScrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (Scroll.Length > 0)
            {
                ScrollEventArgs ScrollEventArgs1 = new ScrollEventArgs();
                ScrollEventArgs1.EventString = Scroll;
                ScrollEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Scroll;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    ScrollEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    ScrollEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    ScrollEventArgs1.Parameter = null;
                }
                ScrollEventArgs1.OldValue = e.OldValue;
                ScrollEventArgs1.NewValue = e.NewValue;
                ScrollEventArgs1.ScrollOrientation = (int)e.ScrollOrientation;
                ScrollEventArgs1.EventType = (int)e.Type;
                OneScriptForms.EventQueue.Add(ScrollEventArgs1);
                ClScrollEventArgs ClScrollEventArgs1 = new ClScrollEventArgs(ScrollEventArgs1);

                ScrollBarManagedProperties();
            }
        }

        public void M_ScrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            if (ValueChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = ValueChanged;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.ValueChanged;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void ScrollBarManagedProperties()
        {
            if (ManagedProperties.Count > 0)
            {
                foreach (ClManagedProperty ClManagedProperty1 in ManagedProperties.Base_obj)
                {
                    object obj1 = ClManagedProperty1.ManagedObject;
                    string prop1 = "";
                    float ratio1 = 1.0f;
                    if (ClManagedProperty1.Ratio == null)
                    {
                    }
                    else
                    {
                        ratio1 = Convert.ToSingle(ClManagedProperty1.Ratio.AsNumber());
                    }
                    System.Reflection.PropertyInfo[] myPropertyInfo;
                    myPropertyInfo = obj1.GetType().GetProperties();
                    for (int i = 0; i < myPropertyInfo.Length; i++)
                    {
                        System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributeData1 =
                            myPropertyInfo[i].CustomAttributes;
                        foreach (System.Reflection.CustomAttributeData CustomAttribute1 in CustomAttributeData1)
                        {
                            string quote = "\"";
                            string text = CustomAttribute1.ToString();
                            if (text.Contains("[ScriptEngine.Machine.Contexts.ContextPropertyAttribute(" + quote))
                            {
                                text = text.Replace("[ScriptEngine.Machine.Contexts.ContextPropertyAttribute(" + quote, "");
                                text = text.Replace(quote + ", " + quote, " ");
                                text = text.Replace(quote + ")]", "");
                                string[] stringSeparators = new string[] { };
                                string[] result = text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                if (ClManagedProperty1.ManagedProperty == result[0])
                                {
                                    prop1 = result[1];
                                    break;
                                }
                            }
                        }
                    }
                    System.Type Type1 = obj1.GetType();
                    float _Value = Convert.ToSingle(v_h_ScrollBar.Value);
                    int res = Convert.ToInt32(ratio1 * _Value);
                    if (Type1.GetProperty(prop1).PropertyType.ToString() != "System.String")
                    {
                        Type1.GetProperty(prop1).SetValue(obj1, res);
                    }
                    else
                    {
                        Type1.GetProperty(prop1).SetValue(obj1, res.ToString());
                    }
                }
            }
        }

    }

}
