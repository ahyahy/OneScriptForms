using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ListViewColumnHeaderCollection : CollectionBase
    {
        public ClListViewColumnHeaderCollection dll_obj;
        public System.Windows.Forms.ListView.ColumnHeaderCollection M_ColumnHeaderCollection;

        public ListViewColumnHeaderCollection()
        {
        }

        public ListViewColumnHeaderCollection(System.Windows.Forms.ListView.ColumnHeaderCollection p1)
        {
            M_ColumnHeaderCollection = p1;
            base.List = M_ColumnHeaderCollection;
        }

        public override object Current
        {
            get { return (object)(ColumnHeader)((ColumnHeaderEx)Enumerator.Current).M_Object; }
        }

        public new osf.ColumnHeader this[int index]
        {
            get { return (ColumnHeader)((ColumnHeaderEx)M_ColumnHeaderCollection[index]).M_Object; }
        }

        public osf.ColumnHeader Insert(int index, ColumnHeader p1)
        {
            M_ColumnHeaderCollection.Insert(index, p1.M_ColumnHeader);
            return p1;
        }

        public new osf.ColumnHeader Add(object column = null)
        {
            if (column is ColumnHeader)
            {
                M_ColumnHeaderCollection.Add((ColumnHeaderEx)((ColumnHeader)column).M_ColumnHeader);
                //System.Windows.Forms.Application.DoEvents();
                return (ColumnHeader)column;
            }
            ColumnHeader ColumnHeader1 = new ColumnHeader();
            if (column is string)
            {
                ColumnHeader1.Text = Convert.ToString(column);
            }
            M_ColumnHeaderCollection.Add((ColumnHeaderEx)ColumnHeader1.M_ColumnHeader);
            //System.Windows.Forms.Application.DoEvents();
            return ColumnHeader1;
        }

        public void Remove(ColumnHeader column)
        {
            M_ColumnHeaderCollection.Remove((System.Windows.Forms.ColumnHeader)column.M_ColumnHeader);
        }
    }

    [ContextClass ("КлКолонки", "ClListViewColumnHeaderCollection")]
    public class ClListViewColumnHeaderCollection : AutoContext<ClListViewColumnHeaderCollection>
    {
        public ClListViewColumnHeaderCollection()
        {
            ListViewColumnHeaderCollection ListViewColumnHeaderCollection1 = new ListViewColumnHeaderCollection();
            ListViewColumnHeaderCollection1.dll_obj = this;
            Base_obj = ListViewColumnHeaderCollection1;
        }
		
        public ClListViewColumnHeaderCollection(ListViewColumnHeaderCollection p1)
        {
            ListViewColumnHeaderCollection ListViewColumnHeaderCollection1 = p1;
            ListViewColumnHeaderCollection1.dll_obj = this;
            Base_obj = ListViewColumnHeaderCollection1;
        }
        
        public ListViewColumnHeaderCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public ClColumnHeader Insert(int p1, ClColumnHeader p2)
        {
            return Base_obj.Insert(p1, p2.Base_obj).dll_obj;
        }
        
        [ContextMethod("Добавить", "Add")]
        public ClColumnHeader Add(IValue p1 = null)
        {
            if (p1 == null)
            {
                return new ClColumnHeader(Base_obj.Add());
            }
            else if (p1.SystemType.Name == "Строка")
            {
                return new ClColumnHeader(Base_obj.Add(p1.AsString()));
            }
            else if (p1.GetType() == typeof(ClColumnHeader))
            {
                return Base_obj.Add(((ClColumnHeader)p1).Base_obj).dll_obj;
            }
            return null;
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClColumnHeader p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClColumnHeader Item(int p1)
        {
            return Base_obj[p1].dll_obj;
        }
    }
}
