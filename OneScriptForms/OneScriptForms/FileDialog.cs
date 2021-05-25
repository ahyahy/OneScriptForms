namespace osf
{

    public class FileDialog : CommonDialog
    {
        private System.Windows.Forms.FileDialog m_FileDialog;

        public FileDialog(System.Windows.Forms.FileDialog p1 = null)
        {
        }

        //Свойства============================================================

        public bool AddExtension
        {
            get { return M_FileDialog.AddExtension; }
            set { M_FileDialog.AddExtension = value; }
        }

        public virtual bool CheckFileExists
        {
            get { return M_FileDialog.CheckFileExists; }
            set { M_FileDialog.CheckFileExists = value; }
        }

        public bool CheckPathExists
        {
            get { return M_FileDialog.CheckPathExists; }
            set { M_FileDialog.CheckPathExists = value; }
        }

        public string DefaultExt
        {
            get { return M_FileDialog.DefaultExt; }
            set { M_FileDialog.DefaultExt = value; }
        }

        public bool DereferenceLinks
        {
            get { return M_FileDialog.DereferenceLinks; }
            set { M_FileDialog.DereferenceLinks = value; }
        }

        public string FileName
        {
            get { return M_FileDialog.FileName; }
            set { M_FileDialog.FileName = value; }
        }

        public string Filter
        {
            get { return M_FileDialog.Filter; }
            set { M_FileDialog.Filter = value; }
        }

        public int FilterIndex
        {
            get { return M_FileDialog.FilterIndex; }
            set { M_FileDialog.FilterIndex = value; }
        }

        public string InitialDirectory
        {
            get { return M_FileDialog.InitialDirectory; }
            set { M_FileDialog.InitialDirectory = value; }
        }

        public System.Windows.Forms.FileDialog M_FileDialog
        {
            get { return m_FileDialog; }
            set
            {
                m_FileDialog = value;
                base.M_CommonDialog = m_FileDialog;
            }
        }

        public bool RestoreDirectory
        {
            get { return M_FileDialog.RestoreDirectory; }
            set { M_FileDialog.RestoreDirectory = value; }
        }

        public string Title
        {
            get { return M_FileDialog.Title; }
            set { M_FileDialog.Title = value; }
        }

        //Методы============================================================

    }

}
