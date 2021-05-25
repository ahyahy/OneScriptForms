using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class CancelEventArgs : EventArgs
    {
        public bool Cancel = false;
        public new ClCancelEventArgs dll_obj;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлОтменаАрг", "ClCancelEventArgs")]
    public class ClCancelEventArgs : AutoContext<ClCancelEventArgs>
    {

        public ClCancelEventArgs()
        {
            CancelEventArgs CancelEventArgs1 = new CancelEventArgs();
            CancelEventArgs1.dll_obj = this;
            Base_obj = CancelEventArgs1;
        }
		
        public ClCancelEventArgs(CancelEventArgs p1)
        {
            CancelEventArgs CancelEventArgs1 = p1;
            CancelEventArgs1.dll_obj = this;
            Base_obj = CancelEventArgs1;
        }
        
        public CancelEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Отмена", "Cancel")]
        public bool Cancel
        {
            get { return Base_obj.Cancel; }
            set { Base_obj.Cancel = value; }
        }

        //Методы============================================================

    }
}
