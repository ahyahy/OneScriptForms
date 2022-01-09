using System;

namespace osf
{
    public class ScrollBar : Control
    {
        public string Scroll;
        public dynamic v_h_ScrollBar;
        public string ValueChanged;

        public ScrollBar()
        {
        }

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
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public void M_ScrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (Scroll.Length > 0)
            {
                ScrollEventArgs ScrollEventArgs1 = new ScrollEventArgs();
                ScrollEventArgs1.EventString = Scroll;
                ScrollEventArgs1.Sender = this;
                ScrollEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Scroll);
                ScrollEventArgs1.OldValue = e.OldValue;
                ScrollEventArgs1.NewValue = e.NewValue;
                ScrollEventArgs1.ScrollOrientation = (int)e.ScrollOrientation;
                ScrollEventArgs1.EventType = (int)e.Type;
                ClScrollEventArgs ClScrollEventArgs1 = new ClScrollEventArgs(ScrollEventArgs1);
                OneScriptForms.Event = ClScrollEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Scroll);
            }
        }

        public void M_ScrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            if (ValueChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = ValueChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ValueChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ValueChanged);
            }
        }
    }
}
