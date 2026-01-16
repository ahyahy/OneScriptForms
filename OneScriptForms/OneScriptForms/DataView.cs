using System.Collections;
using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataView : IEnumerable, IEnumerator
    {
        public ClDataView dll_obj;
        private System.Collections.IEnumerator Enumerator;
        public System.Data.DataView M_DataView;

        public DataView()
        {
            M_DataView = new System.Data.DataView();
            OneScriptForms.AddToHashtable(M_DataView, this);
        }

        public DataView(osf.DataView p1)
        {
            M_DataView = p1.M_DataView;
            OneScriptForms.AddToHashtable(M_DataView, this);
        }

        public DataView(System.Data.DataView p1)
        {
            M_DataView = p1;
            OneScriptForms.AddToHashtable(M_DataView, this);
        }

        public bool AllowEdit
        {
            get { return M_DataView.AllowEdit; }
            set
            {
                M_DataView.AllowEdit = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool AllowNew
        {
            get { return M_DataView.AllowNew; }
            set
            {
                M_DataView.AllowNew = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool ApplyDefaultSort
        {
            get { return M_DataView.ApplyDefaultSort; }
            set
            {
                M_DataView.ApplyDefaultSort = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int Count
        {
            get { return M_DataView.Count; }
        }

        public object Current
        {
            get { return (object)new DataRow((System.Data.DataRow)Enumerator.Current); }
        }

        public object get_Item(int index)
        {
            return new DataRowView(M_DataView[index]);
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public string RowFilter
        {
            get { return M_DataView.RowFilter; }
            set { M_DataView.RowFilter = value; }
        }

        public string Sort
        {
            get { return M_DataView.Sort; }
            set { M_DataView.Sort = value; }
        }

        public osf.DataTable Table
        {
            get { return (DataTable)((DataTableEx)M_DataView.Table).M_Object; }
            set { M_DataView.Table = (System.Data.DataTable)value.M_DataTable; }
        }

        public osf.DataRowView AddNew()
        {
            return new DataRowView(M_DataView.AddNew());
        }

        public void BeginInit()
        {
            M_DataView.BeginInit();
        }

        public void EndInit()
        {
            M_DataView.EndInit();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Enumerator = M_DataView.GetEnumerator();
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }
    }

    [ContextClass("КлПредставлениеДанных", "ClDataView")]
    public class ClDataView : AutoContext<ClDataView>
    {
        public ClDataView()
        {
            DataView DataView1 = new DataView();
            DataView1.dll_obj = this;
            Base_obj = DataView1;
        }

        public ClDataView(DataView p1)
        {
            DataView DataView1 = p1;
            DataView1.dll_obj = this;
            Base_obj = DataView1;
        }

        public ClDataView(System.Data.DataView p1)
        {
            DataView DataView1 = new DataView(p1);
            DataView1.dll_obj = this;
            Base_obj = DataView1;
        }

        public DataView Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextProperty("РазрешитьНовые", "AllowNew")]
        public bool AllowNew
        {
            get { return Base_obj.AllowNew; }
            set { Base_obj.AllowNew = value; }
        }

        [ContextProperty("РазрешитьРедактирование", "AllowEdit")]
        public bool AllowEdit
        {
            get { return Base_obj.AllowEdit; }
            set { Base_obj.AllowEdit = value; }
        }

        [ContextProperty("СортироватьПоУмолчанию", "ApplyDefaultSort")]
        public bool ApplyDefaultSort
        {
            get { return Base_obj.ApplyDefaultSort; }
            set { Base_obj.ApplyDefaultSort = value; }
        }

        [ContextProperty("Сортировка", "Sort")]
        public string Sort
        {
            get { return Base_obj.Sort; }
            set { Base_obj.Sort = value; }
        }

        [ContextProperty("Таблица", "Table")]
        public ClDataTable Table
        {
            get { return (ClDataTable)OneScriptForms.RevertObj(Base_obj.Table); }
            set { Base_obj.Table = value.Base_obj; }
        }

        [ContextProperty("ФильтрСтрок", "RowFilter")]
        public string RowFilter
        {
            get { return Base_obj.RowFilter; }
            set { Base_obj.RowFilter = value; }
        }

        [ContextMethod("ДобавитьНовуюСтроку", "AddNew")]
        public ClDataRowView AddNew()
        {
            return new ClDataRowView(Base_obj.AddNew());
        }

        [ContextMethod("ЗакончитьИнициализацию", "EndInit")]
        public void EndInit()
        {
            Base_obj.EndInit();
        }

        [ContextMethod("НачатьИнициализацию", "BeginInit")]
        public void BeginInit()
        {
            Base_obj.BeginInit();
        }

        [ContextMethod("Элемент", "Item")]
        public ClDataRowView Item(int p1)
        {
            return new ClDataRowView((osf.DataRowView)Base_obj.get_Item(p1));
        }
    }
}
