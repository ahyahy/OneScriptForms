using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class GridColumnStylesCollection : CollectionBase
    {
        public ClGridColumnStylesCollection dll_obj;
        public System.Windows.Forms.GridColumnStylesCollection M_GridColumnStylesCollection;

        public GridColumnStylesCollection(System.Windows.Forms.GridColumnStylesCollection p1)
        {
            M_GridColumnStylesCollection = p1;
            base.List = M_GridColumnStylesCollection;
        }

        public new osf.DataGridColumnStyle this[int p1]
        {
            get { return new DataGridColumnStyle(M_GridColumnStylesCollection[p1]); }
        }

        public int Add(osf.DataGridColumnStyle p1)
        {
            int res = Convert.ToInt32(M_GridColumnStylesCollection.Add((System.Windows.Forms.DataGridColumnStyle)p1.M_DataGridColumnStyle));
            //System.Windows.Forms.Application.DoEvents();
            return res;
        }
    }

    [ContextClass ("КлСтилиКолонкиСеткиДанных", "ClGridColumnStylesCollection")]
    public class ClGridColumnStylesCollection : AutoContext<ClGridColumnStylesCollection>
    {
        public ClGridColumnStylesCollection(GridColumnStylesCollection p1)
        {
            GridColumnStylesCollection GridColumnStylesCollection1 = p1;
            GridColumnStylesCollection1.dll_obj = this;
            Base_obj = GridColumnStylesCollection1;
        }

        public GridColumnStylesCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Добавить", "Add")]
        public int Add(IValue p1)
        {
            return Base_obj.Add(((dynamic)p1).Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return OneScriptForms.RevertObj(((dynamic)Base_obj[p1].M_DataGridColumnStyle).M_Object);
        }
    }
}
