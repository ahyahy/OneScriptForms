using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class SelectionRange
    {
        public ClSelectionRange dll_obj;
        public System.Windows.Forms.SelectionRange M_SelectionRange;

        public SelectionRange()
        {
            M_SelectionRange = new System.Windows.Forms.SelectionRange();
            OneScriptForms.AddToHashtable(M_SelectionRange, this);
        }

        public SelectionRange(DateTime p1, DateTime p2)
        {
            M_SelectionRange = new System.Windows.Forms.SelectionRange(p1, p2);
            OneScriptForms.AddToHashtable(M_SelectionRange, this);
        }

        public SelectionRange(osf.SelectionRange p1)
        {
            M_SelectionRange = p1.M_SelectionRange;
            OneScriptForms.AddToHashtable(M_SelectionRange, this);
        }

        public SelectionRange(System.Windows.Forms.SelectionRange p1)
        {
            M_SelectionRange = p1;
            OneScriptForms.AddToHashtable(M_SelectionRange, this);
        }

        public System.DateTime End
        {
            get { return M_SelectionRange.End; }
            set { M_SelectionRange.End = value; }
        }

        public System.DateTime Start
        {
            get { return M_SelectionRange.Start; }
            set { M_SelectionRange.Start = value; }
        }
    }

    [ContextClass ("КлВыделенныйДиапазон", "ClSelectionRange")]
    public class ClSelectionRange : AutoContext<ClSelectionRange>
    {
        public ClSelectionRange()
        {
            SelectionRange SelectionRange1 = new SelectionRange();
            SelectionRange1.dll_obj = this;
            Base_obj = SelectionRange1;
        }
		
        public ClSelectionRange(IValue p1, IValue p2)
        {
            SelectionRange SelectionRange1 = new SelectionRange(p1.AsDate(), p2.AsDate());
            SelectionRange1.dll_obj = this;
            Base_obj = SelectionRange1;
        }
		
        public ClSelectionRange(SelectionRange p1)
        {
            SelectionRange SelectionRange1 = p1;
            SelectionRange1.dll_obj = this;
            Base_obj = SelectionRange1;
        }

        public SelectionRange Base_obj;
        
        [ContextProperty("Конец", "End")]
        public DateTime End
        {
            get { return Base_obj.End; }
            set { Base_obj.End = value; }
        }

        [ContextProperty("Начало", "Start")]
        public DateTime Start
        {
            get { return Base_obj.Start; }
            set { Base_obj.Start = value; }
        }
        
    }
}
