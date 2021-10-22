namespace osf
{
    public class DataGridColumnStyle : Component
    {
        public System.Windows.Forms.DataGridColumnStyle M_DataGridColumnStyle;

        public DataGridColumnStyle()
        {
        }

        public DataGridColumnStyle(osf.DataGridColumnStyle p1)
        {
            M_DataGridColumnStyle = p1.M_DataGridColumnStyle;
            base.M_Component = M_DataGridColumnStyle;
        }

        public DataGridColumnStyle(System.Windows.Forms.DataGridColumnStyle p1)
        {
            M_DataGridColumnStyle = p1;
            base.M_Component = M_DataGridColumnStyle;
        }

        public int Alignment
        {
            get { return (int)M_DataGridColumnStyle.Alignment; }
            set { M_DataGridColumnStyle.Alignment = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        public string HeaderText
        {
            get { return M_DataGridColumnStyle.HeaderText; }
            set { M_DataGridColumnStyle.HeaderText = value; }
        }

        public string MappingName
        {
            get { return M_DataGridColumnStyle.MappingName; }
            set { M_DataGridColumnStyle.MappingName = value; }
        }

        public bool ReadOnly
        {
            get { return M_DataGridColumnStyle.ReadOnly; }
            set { M_DataGridColumnStyle.ReadOnly = value; }
        }

        public int Width
        {
            get { return M_DataGridColumnStyle.Width; }
            set { M_DataGridColumnStyle.Width = value; }
        }
    }
}
