using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class GridItemCollection : System.Collections.ICollection
    {
        public ClGridItemCollection dll_obj;
        public System.Windows.Forms.GridItemCollection M_GridItemCollection;

        public GridItemCollection(System.Windows.Forms.GridItemCollection p1)
        {
            M_GridItemCollection = p1;
        }

        //Свойства============================================================

        public int Count
        {
            get { return M_GridItemCollection.Count; }
        }

        public bool IsSynchronized
        {
            get { return IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return SyncRoot; }
        }

        public osf.GridItem this[int index]
        {
            get { return new GridItem(M_GridItemCollection[index]); }
        }

        public osf.GridItem this[string str]
        {
            get { return new GridItem(M_GridItemCollection[str]); }
        }

        //Методы============================================================

        public void CopyTo(Array array, int index)
        {
            CopyTo(array, index);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return M_GridItemCollection.GetEnumerator();
        }

    }

    [ContextClass ("КлЭлементыСетки", "ClGridItemCollection")]
    public class ClGridItemCollection : AutoContext<ClGridItemCollection>
    {

        public ClGridItemCollection(GridItemCollection p1)
        {
            GridItemCollection GridItemCollection1 = p1;
            GridItemCollection1.dll_obj = this;
            Base_obj = GridItemCollection1;
        }

        public ClGridItemCollection(System.Windows.Forms.GridItemCollection p1)
        {
            GridItemCollection GridItemCollection1 = new GridItemCollection(p1);
            GridItemCollection1.dll_obj = this;
            Base_obj = GridItemCollection1;
        }

        public GridItemCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Элемент", "Item")]
        public ClGridItem Item(IValue p1)
        {
            if (p1.SystemType.Name == "Число")
            {
                return new ClGridItem(Base_obj[Convert.ToInt32(p1.AsNumber())]);
            }
            return new ClGridItem(Base_obj[p1.AsString()]);
        }
    }
}
