using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ItemCheckEventArgs : EventArgs
    {
        public new ClItemCheckEventArgs dll_obj;
        public int CurrentValue = (int)System.Windows.Forms.CheckState.Unchecked;
        public int Index = -1;
        public int NewValue = (int)System.Windows.Forms.CheckState.Unchecked;

        public override bool PostEvent()
        {
            ListView ListView1 = (ListView)Sender;
            ListViewEx ListViewEx1 = ListView1.M_ListView;
            ListViewEx1.ItemCheck -= ListView1.M_ListView_ItemCheck;
            ListViewEx1.Items[Index].Checked = (uint)NewValue > 0U;
            ListViewEx1.ItemCheck += ListView1.M_ListView_ItemCheck;
            return true;
        }
    }

    [ContextClass ("КлЭлементПомеченАрг", "ClItemCheckEventArgs")]
    public class ClItemCheckEventArgs : AutoContext<ClItemCheckEventArgs>
    {
        public ClItemCheckEventArgs()
        {
            ItemCheckEventArgs ItemCheckEventArgs1 = new ItemCheckEventArgs();
            ItemCheckEventArgs1.dll_obj = this;
            Base_obj = ItemCheckEventArgs1;
        }
		
        public ClItemCheckEventArgs(ItemCheckEventArgs p1)
        {
            ItemCheckEventArgs ItemCheckEventArgs1 = p1;
            ItemCheckEventArgs1.dll_obj = this;
            Base_obj = ItemCheckEventArgs1;
        }
        
        public ItemCheckEventArgs Base_obj;
        
        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("НовоеЗначение", "NewValue")]
        public int NewValue
        {
            get { return (int)Base_obj.NewValue; }
        }

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }
        
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        [ContextProperty("ТекущееЗначение", "CurrentValue")]
        public int CurrentValue
        {
            get { return (int)Base_obj.CurrentValue; }
        }
        
    }
}
