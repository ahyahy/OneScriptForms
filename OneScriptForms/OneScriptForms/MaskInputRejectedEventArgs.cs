using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class MaskInputRejectedEventArgs : EventArgs
    {
        public new ClMaskInputRejectedEventArgs dll_obj;
        public int Position;
        public int RejectionHint;

    }

    [ContextClass ("КлВводОтклоненАрг", "ClMaskInputRejectedEventArgs")]
    public class ClMaskInputRejectedEventArgs : AutoContext<ClMaskInputRejectedEventArgs>
    {
        public ClMaskInputRejectedEventArgs()
        {
            MaskInputRejectedEventArgs MaskInputRejectedEventArgs1 = new MaskInputRejectedEventArgs();
            MaskInputRejectedEventArgs1.dll_obj = this;
            Base_obj = MaskInputRejectedEventArgs1;
        }
		
        public ClMaskInputRejectedEventArgs(MaskInputRejectedEventArgs p1)
        {
            MaskInputRejectedEventArgs MaskInputRejectedEventArgs1 = p1;
            MaskInputRejectedEventArgs1.dll_obj = this;
            Base_obj = MaskInputRejectedEventArgs1;
        }
        
        public MaskInputRejectedEventArgs Base_obj;
        
        [ContextProperty("Позиция", "Position")]
        public int Position
        {
            get { return Base_obj.Position; }
        }

        [ContextProperty("Причина", "RejectionHint")]
        public int RejectionHint
        {
            get { return (int)Base_obj.RejectionHint; }
        }
        
    }
}
