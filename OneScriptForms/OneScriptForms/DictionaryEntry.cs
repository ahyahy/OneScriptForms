using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class DictionaryEntry
    {
        public ClDictionaryEntry dll_obj;
        public System.Collections.DictionaryEntry M_DictionaryEntry;

        public DictionaryEntry(System.Collections.DictionaryEntry p1)
        {
            M_DictionaryEntry = p1;
            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
        }

        public DictionaryEntry(object p1, object p2)
        {
            M_DictionaryEntry = new System.Collections.DictionaryEntry(p1, p2);
            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
        }

        public DictionaryEntry(osf.DictionaryEntry p1)
        {
            M_DictionaryEntry = p1.M_DictionaryEntry;
            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
        }

        //Свойства============================================================

        public object Key
        {
            get{return M_DictionaryEntry.Key;}
            set{M_DictionaryEntry.Key = value;}
        }

        public object Value
        {
            get{return M_DictionaryEntry.Value;}
            set{M_DictionaryEntry.Value = value;}
        }

        //Методы============================================================

    }

    [ContextClass ("КлСловарнаяЗапись", "ClDictionaryEntry")]
    public class ClDictionaryEntry : AutoContext<ClDictionaryEntry>
    {

        public ClDictionaryEntry(IValue p1, IValue p2)
        {
            DictionaryEntry DictionaryEntry1 = new DictionaryEntry(p1, p2);
            DictionaryEntry1.dll_obj = this;
            Base_obj = DictionaryEntry1;
        }
		
        public ClDictionaryEntry(DictionaryEntry p1)
        {
            DictionaryEntry DictionaryEntry1 = p1;
            DictionaryEntry1.dll_obj = this;
            Base_obj = DictionaryEntry1;
        }

        public DictionaryEntry Base_obj;

        //Свойства============================================================

        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get { return OneScriptForms.RevertObj(Base_obj.Value); }
            set { Base_obj.Value = value; }
        }
        
        [ContextProperty("Ключ", "Key")]
        public IValue Key
        {
            get { return OneScriptForms.RevertObj(Base_obj.Key); }
            set { Base_obj.Key = value; }
        }

        //Методы============================================================

    }
}
