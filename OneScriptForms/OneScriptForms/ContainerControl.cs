namespace osf
{

    public class ContainerControl : ScrollableControl
    {
        private System.Windows.Forms.ContainerControl m_ContainerControl;

        //Свойства============================================================

        public osf.Control ActiveControl
        {
            get { return ((dynamic)M_ContainerControl.ActiveControl).M_Object; }
            set { M_ContainerControl.ActiveControl = ((dynamic)value).M_Control; }
        }

        //Свойства============================================================

        //Методы============================================================

        public System.Windows.Forms.ContainerControl M_ContainerControl
        {
            get { return m_ContainerControl; }
            set
            {
                m_ContainerControl = value;
                base.M_ScrollableControl = m_ContainerControl;
            }
        }

        //Методы============================================================

    }

}
