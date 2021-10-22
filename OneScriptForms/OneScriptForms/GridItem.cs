using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class GridItem
    {
        public ClGridItem dll_obj;
        public System.Windows.Forms.GridItem M_GridItem;

        public GridItem(osf.GridItem p1)
        {
            M_GridItem = p1.M_GridItem;
            OneScriptForms.AddToHashtable(M_GridItem, this);
        }

        public GridItem(System.Windows.Forms.GridItem p1)
        {
            M_GridItem = p1;
            OneScriptForms.AddToHashtable(M_GridItem, this);
        }

        public string Label
        {
            get { return M_GridItem.Label; }
        }

        public object Value
        {
            get { return M_GridItem.Value; }
        }
    }

    [ContextClass ("КлЭлементСетки", "ClGridItem")]
    public class ClGridItem : AutoContext<ClGridItem>
    {
        public ClGridItem(GridItem p1)
        {
            GridItem GridItem1 = p1;
            GridItem1.dll_obj = this;
            Base_obj = GridItem1;
        }

        public GridItem Base_obj;
        
        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get { return OneScriptForms.RevertObj(Base_obj.Value); }
        }
        
        [ContextProperty("Надпись", "Label")]
        public string Label
        {
            get { return Base_obj.Label; }
        }

        [ContextProperty("ТипЭлементаСетки", "GridItemType")]
        public int GridItemType
        {
            get { return (int)Base_obj.M_GridItem.GridItemType; }
        }
        
        [ContextProperty("ЭлементыСетки", "GridItems")]
        public ClGridItemCollection GridItems
        {
            get { return new ClGridItemCollection(Base_obj.M_GridItem.GridItems); }
        }
        
    }
}
