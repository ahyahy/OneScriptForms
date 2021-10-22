namespace osf
{
    public class ListControl : Control
    {
        private System.Windows.Forms.ListControl m_ListControl;

        public ListControl()
        {
        }

        public object DataSource
        {
            get
            {
                object obj;
                try
                {
                    obj = ((dynamic)M_ListControl.DataSource).M_Object;
                }
                catch
                {
                    obj = M_ListControl.DataSource;
                }
                return obj;
            }
            set
            {
                M_ListControl.DataSource = null;
                try
                {
                    System.Type Type1 = value.GetType();
                    string strType1 = Type1.ToString();
                    string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                    M_ListControl.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                }
                catch
                {
                    M_ListControl.DataSource = value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string DisplayMember
        {
            get { return M_ListControl.DisplayMember; }
            set
            {
                M_ListControl.DisplayMember = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public System.Windows.Forms.ListControl M_ListControl
        {
            get { return m_ListControl; }
            set
            {
                m_ListControl = value;
                base.M_Control = m_ListControl;
            }
        }

        public object SelectedValue
        {
            get { return M_ListControl.SelectedValue; }
            set
            {
                M_ListControl.SelectedValue = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string ValueMember
        {
            get { return M_ListControl.ValueMember; }
            set
            {
                M_ListControl.ValueMember = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }
    }
}
