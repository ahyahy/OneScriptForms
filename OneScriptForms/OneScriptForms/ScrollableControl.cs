namespace osf
{

    public class ScrollableControl : Control
    {
        private System.Windows.Forms.ScrollableControl m_ScrollableControl;

        //Свойства============================================================

        public bool AutoScroll
        {
            get { return m_ScrollableControl.AutoScroll; }
            set { m_ScrollableControl.AutoScroll = value; }
        }

        public osf.Size AutoScrollMargin
        {
            get { return new Size(m_ScrollableControl.AutoScrollMargin); }
            set { m_ScrollableControl.AutoScrollMargin = value.M_Size; }
        }

        public osf.DockPaddingEdges DockPadding
        {
            get { return new DockPaddingEdges(m_ScrollableControl.DockPadding); }
        }

        public System.Windows.Forms.ScrollableControl M_ScrollableControl
        {
            get { return m_ScrollableControl; }
            set
            {
                m_ScrollableControl = value;
                base.M_Control = m_ScrollableControl;
            }
        }

        //Методы============================================================

    }

}
