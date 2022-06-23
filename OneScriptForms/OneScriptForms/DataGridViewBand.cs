namespace osf
{
    public class DataGridViewBand : DataGridViewElement
    {
        private System.Windows.Forms.DataGridViewBand m_DataGridViewBand;

        public bool Displayed
        {
            get { return M_DataGridViewBand.Displayed; }
        }

        public int Index
        {
            get { return M_DataGridViewBand.Index; }
        }

        public System.Windows.Forms.DataGridViewBand M_DataGridViewBand
        {
            get { return m_DataGridViewBand; }
            set
            {
                m_DataGridViewBand = value;
                base.M_DataGridViewElement = m_DataGridViewBand;
            }
        }

        public bool Selected
        {
            get { return M_DataGridViewBand.Selected; }
            set { M_DataGridViewBand.Selected = value; }
        }

        public object Tag
        {
            get { return M_DataGridViewBand.Tag; }
            set { M_DataGridViewBand.Tag = value; }
        }
    }
}
