namespace osf
{

    public class CommonDialog : Component
    {
        public System.Windows.Forms.CommonDialog M_CommonDialog;

        public CommonDialog()
        {
        }

        public CommonDialog(osf.CommonDialog p1)
        {
            M_CommonDialog = p1.M_CommonDialog;
            base.M_Component = M_CommonDialog;
        }

        public CommonDialog(System.Windows.Forms.CommonDialog p1)
        {
            M_CommonDialog = p1;
            base.M_Component = M_CommonDialog;
        }

        //Свойства============================================================

        //Методы============================================================

        public int ShowDialog()
        {
            return (int)M_CommonDialog.ShowDialog();
        }

    }

}
