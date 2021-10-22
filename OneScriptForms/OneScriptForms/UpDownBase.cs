namespace osf
{
    public class UpDownBase : ContainerControl
    {
        private System.Windows.Forms.UpDownBase m_UpDownBase;

        public UpDownBase()
        {
        }

        public UpDownBase(osf.UpDownBase p1)
        {
            M_UpDownBase = p1.M_UpDownBase;
            base.M_ContainerControl = M_UpDownBase;
        }

        public UpDownBase(System.Windows.Forms.UpDownBase p1)
        {
            M_UpDownBase = p1;
            base.M_ContainerControl = M_UpDownBase;
        }

        public int BorderStyle
        {
            get { return (int)M_UpDownBase.BorderStyle; }
            set
            {
                M_UpDownBase.BorderStyle = (System.Windows.Forms.BorderStyle)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public System.Windows.Forms.UpDownBase M_UpDownBase
        {
            get { return m_UpDownBase; }
            set
            {
                m_UpDownBase = value;
                base.M_ContainerControl = m_UpDownBase;
            }
        }

        public bool ReadOnly
        {
            get { return M_UpDownBase.ReadOnly; }
            set
            {
                M_UpDownBase.ReadOnly = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }
    }
}
