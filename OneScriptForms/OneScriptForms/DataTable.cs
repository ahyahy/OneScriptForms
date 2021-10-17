using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataTableEx : System.Data.DataTable
    {
        public osf.DataTable M_Object;
    }

    public class DataTable
    {
        public ClDataTable dll_obj;
        public DataTableEx M_DataTable;

        public DataTable()
        {
            M_DataTable = new DataTableEx();
            M_DataTable.M_Object = this;
        }

        public DataTable(osf.DataTable p1)
        {
            M_DataTable = p1.M_DataTable;
            M_DataTable.M_Object = this;
        }

        public DataTable(string p1)
        {
            M_DataTable = new DataTableEx();
            M_DataTable.M_Object = this;
            M_DataTable.TableName = p1;
        }

        public DataTable(System.Data.DataTable p1)
        {
            M_DataTable = (DataTableEx)p1;
            M_DataTable.M_Object = this;
        }

        //Свойства============================================================

        public osf.DataColumnCollection Columns
        {
            get { return new DataColumnCollection(M_DataTable.Columns); }
        }

        public osf.DataSet DataSet
        {
            get { return ((DataSetEx)M_DataTable.DataSet).M_Object; }
        }

        public osf.DataView DefaultView
        {
            get { return new DataView(M_DataTable.DefaultView); }
        }

        public osf.DataColumn get_Column(object p1)
        {
            if (p1 is int)
            {
                return ((DataColumnEx)(M_DataTable.Columns[Convert.ToInt32(p1)])).M_Object;
            }
            else
            {
                return ((DataColumnEx)(M_DataTable.Columns[Convert.ToString(p1)])).M_Object;
            }
        }

        public osf.DataRowCollection Rows
        {
            get { return new DataRowCollection(M_DataTable.Rows); }
        }

        public string TableName
        {
            get { return M_DataTable.TableName; }
            set { M_DataTable.TableName = value; }
        }

        //Методы============================================================

        public void AcceptChanges()
        {
            M_DataTable.AcceptChanges();
        }

        public osf.DataTable Clone()
        {
            return new DataTable(M_DataTable.Clone());
        }

        public osf.DataTable Copy()
        {
            return new DataTable(M_DataTable.Copy());
        }

        public osf.DataRow NewRow()
        {
            return new DataRow(M_DataTable.NewRow());
        }

        public void RejectChanges()
        {
            M_DataTable.RejectChanges();
        }

        public object[] Select(string filter)
        {
            System.Data.DataRow[] dataRowArray = M_DataTable.Select(filter);
            int num1 = dataRowArray.Length;
            object[] objArray = new object[num1];
            for (int i = 0; i < dataRowArray.Length; i++)
            {
                objArray[i] = (object)new DataRow(dataRowArray[i]);
            }
            return objArray;
        }

        public void Sort(string expression)
        {
            if (M_DataTable.Rows.Count > 0)
            {
                System.Data.DataTable DataTable1 = M_DataTable.Copy();
                M_DataTable.Clear();
                System.Data.DataRow[] DataRowArray1 = DataTable1.Select((string)null, expression);
                for (int i = 0; i < DataRowArray1.Length; i++)
                {
                    M_DataTable.ImportRow(DataRowArray1[i]);
                }
            }
        }

    }

    [ContextClass ("КлТаблицаДанных", "ClDataTable")]
    public class ClDataTable : AutoContext<ClDataTable>
    {
        private ClDataColumnCollection columns;
        private ClDataRowCollection rows;

        public ClDataTable()
        {
            DataTable DataTable1 = new DataTable();
            DataTable1.dll_obj = this;
            Base_obj = DataTable1;
            columns = new ClDataColumnCollection(Base_obj.Columns);
            rows = new ClDataRowCollection(Base_obj.Rows);
        }
		
        public ClDataTable(string p1)
        {
            DataTable DataTable1 = new DataTable(p1);
            DataTable1.dll_obj = this;
            Base_obj = DataTable1;
            columns = new ClDataColumnCollection(Base_obj.Columns);
            rows = new ClDataRowCollection(Base_obj.Rows);
        }

        public ClDataTable(DataTable p1)
        {
            DataTable DataTable1 = p1;
            DataTable1.dll_obj = this;
            Base_obj = DataTable1;
            columns = new ClDataColumnCollection(Base_obj.Columns);
            rows = new ClDataRowCollection(Base_obj.Rows);
        }

        public DataTable Base_obj;

        //Свойства============================================================

        [ContextProperty("ИмяТаблицы", "TableName")]
        public string TableName
        {
            get { return Base_obj.TableName; }
            set { Base_obj.TableName = value; }
        }

        [ContextProperty("Колонки", "Columns")]
        public ClDataColumnCollection Columns
        {
            get { return columns; }
        }

        [ContextProperty("НаборДанных", "DataSet")]
        public ClDataSet DataSet
        {
            get { return (ClDataSet)OneScriptForms.RevertObj(Base_obj.DataSet); }
        }

        [ContextProperty("ПредставлениеПоУмолчанию", "DefaultView")]
        public ClDataView DefaultView
        {
            get { return new ClDataView(Base_obj.DefaultView); }
        }

        [ContextProperty("Строки", "Rows")]
        public ClDataRowCollection Rows
        {
            get { return rows; }
        }

        //Методы============================================================

        [ContextMethod("Выбрать", "Select")]
        public ClArrayList Select(string p1)
        {
            ClArrayList ClArrayList1 = new ClArrayList();
            try
            {
                object[] objects = Base_obj.Select(p1);
                for (int i = 0; i < objects.Length; i++)
                {
                    ClArrayList1.Base_obj.Add(new ClDataRow((osf.DataRow)objects[i]));
                }
            }
            catch
            {
            }
            return ClArrayList1;
        }

        [ContextMethod("ВыгрузитьКолонку", "UnloadColumn")]
        public ClArrayList UnloadColumn(IValue p1)
        {
            ClArrayList ClArrayList1 = new ClArrayList();
            if (p1.SystemType.Name == "Число")
            {
                for (int i = 0; i < Base_obj.Rows.Count; i++)
                {
                    dynamic p2 = Base_obj.Rows[i].get_Item(Convert.ToInt32(p1.AsNumber()));
                    ClArrayList1.Base_obj.Add(p2.Value);
                }
                return ClArrayList1;
            }
            else if (p1.SystemType.Name == "Строка")
            {
                for (int i = 0; i < Base_obj.Rows.Count; i++)
                {
                    dynamic p2 = Base_obj.Rows[i].get_Item(p1.AsString());
                    ClArrayList1.Base_obj.Add(p2.Value);
                }
                return ClArrayList1;
            }
            else if (p1.SystemType.Name == "КлКолонкаДанных")
            {
                for (int i = 0; i < Base_obj.Rows.Count; i++)
                {
                    dynamic p2 = Base_obj.Rows[i].get_Item(((ClDataColumn)p1.AsObject()).Base_obj.ColumnName);
                    ClArrayList1.Base_obj.Add(p2.Value);
                }
                return ClArrayList1;
            }
            return null;
        }

        [ContextMethod("ЗагрузитьКолонку", "LoadColumn")]
        public void LoadColumn(ClArrayList p1, IValue p2)
        {
            dynamic p3 = null;
            if (p2.SystemType.Name == "Число")
            {
                p3 = Convert.ToInt32(p2.AsNumber());
            }
            else if (p2.SystemType.Name == "Строка")
            {
                p3 = p2.AsString();
            }
            else if (p2.SystemType.Name == "КлКолонкаДанных")
            {
                p3 = ((ClDataColumn)p2.AsObject()).Base_obj.ColumnName;
            }

            for (int i = 0; i < p1.Count; i++)
            {
                Base_obj.Rows[i].SetItem(p3, OneScriptForms.DefineTypeIValue(p1.Base_obj[i]));
            }
        }

        [ContextMethod("Клонировать", "Clone")]
        public ClDataTable Clone()
        {
            return new ClDataTable(Base_obj.Clone());
        }

        [ContextMethod("Колонка", "Column")]
        public ClDataColumn Column(IValue p1)
        {
            if (p1.SystemType.Name == "Число")
            {
                return new ClDataColumn(Base_obj.get_Column(Convert.ToInt32(p1.AsNumber())));
            }
            else if (p1.SystemType.Name == "Строка")
            {
                return new ClDataColumn(Base_obj.get_Column(Convert.ToString(p1.AsString())));
            }
            return null;
        }
        
        [ContextMethod("Колонки", "Columns")]
        public ClDataColumn Columns2(IValue p1)
        {
            if (p1.SystemType.Name == "Число")
            {
                return ((DataColumnEx)Base_obj.M_DataTable.Columns[Convert.ToInt32(p1.AsNumber())]).M_Object.dll_obj;
            }
            if (p1.SystemType.Name == "Строка")
            {
                return ((DataColumnEx)Base_obj.M_DataTable.Columns[p1.AsString()]).M_Object.dll_obj;
            }
            return null;
        }

        [ContextMethod("Копировать", "Copy")]
        public ClDataTable Copy()
        {
            return new ClDataTable(Base_obj.Copy());
        }

        [ContextMethod("НоваяСтрока", "NewRow")]
        public ClDataRow NewRow()
        {
            return new ClDataRow(Base_obj.NewRow());
        }

        [ContextMethod("ОтказИзменений", "RejectChanges")]
        public void RejectChanges()
        {
            Base_obj.RejectChanges();
        }
					
        [ContextMethod("ПринятьИзменения", "AcceptChanges")]
        public void AcceptChanges()
        {
            Base_obj.AcceptChanges();
        }
					
        [ContextMethod("Строки", "Rows")]
        public ClDataRow Rows2(int p1)
        {
            return new ClDataRow(Base_obj.Rows[p1]);
        }
    }
}
