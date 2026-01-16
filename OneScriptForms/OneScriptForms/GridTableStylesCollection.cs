using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class GridTableStylesCollection : CollectionBase
    {
        public ClGridTableStylesCollection dll_obj;
        public System.Windows.Forms.GridTableStylesCollection M_GridTableStylesCollection;

        public GridTableStylesCollection(System.Windows.Forms.GridTableStylesCollection p1)
        {
            M_GridTableStylesCollection = p1;
            base.List = M_GridTableStylesCollection;
        }

        public new osf.DataGridTableStyle this[int p1]
        {
            get { return ((DataGridTableStyleEx)M_GridTableStylesCollection[p1]).M_Object; }
        }

        public int Add(osf.DataGridTableStyle p1)
        {
            int res = Convert.ToInt32(M_GridTableStylesCollection.Add((System.Windows.Forms.DataGridTableStyle)p1.M_DataGridTableStyle));
            //System.Windows.Forms.Application.DoEvents();
            return res;
        }
    }

    [ContextClass("КлСтилиТаблицыСеткиДанных", "ClGridTableStylesCollection")]
    public class ClGridTableStylesCollection : AutoContext<ClGridTableStylesCollection>
    {
        public ClGridTableStylesCollection(GridTableStylesCollection p1)
        {
            GridTableStylesCollection GridTableStylesCollection1 = p1;
            GridTableStylesCollection1.dll_obj = this;
            Base_obj = GridTableStylesCollection1;
        }

        public GridTableStylesCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Добавить", "Add")]
        public int Add(ClDataGridTableStyle p1)
        {
            return Base_obj.Add(p1.Base_obj);
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
        public ClDataGridTableStyle Item(int p1)
        {
            return new ClDataGridTableStyle(Base_obj[p1]);
        }
    }
}
