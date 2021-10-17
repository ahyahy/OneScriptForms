using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class DataRow
    {
        public ClDataRow dll_obj;
        public System.Data.DataRow M_DataRow;

        public DataRow(osf.DataRow p1)
        {
            M_DataRow = p1.M_DataRow;
            OneScriptForms.AddToHashtable(M_DataRow, this);
        }

        public DataRow(System.Data.DataRow p1)
        {
            M_DataRow = p1;
            OneScriptForms.AddToHashtable(M_DataRow, this);
        }

        //Свойства============================================================

        public object get_Item(object index)
        {
            return (object)new DataItem(M_DataRow, index);
        }

        public int RowState
        {
            get { return (int)M_DataRow.RowState; }
        }

        public osf.DataTable Table
        {
            get { return ((osf.DataTableEx)M_DataRow.Table).M_Object; }
        }

        //Методы============================================================

        public void AcceptChanges()
        {
            M_DataRow.AcceptChanges();
        }

        public void BeginEdit()
        {
            M_DataRow.BeginEdit();
        }

        public void CancelEdit()
        {
            M_DataRow.CancelEdit();
        }

        public void Delete()
        {
            M_DataRow.Delete();
        }

        public void EndEdit()
        {
            M_DataRow.EndEdit();
        }

        public void RejectChanges()
        {
            M_DataRow.RejectChanges();
        }

        public void SetItem(object index, object item)
        {
            if (index is string)
            {
                M_DataRow[(string)index] = item;
            }
            else
            {
                M_DataRow[(int)index] = item;
            }
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлСтрокаДанных", "ClDataRow")]
    public class ClDataRow : AutoContext<ClDataRow>
    {

        public ClDataRow(DataRow p1)
        {
            DataRow DataRow1 = p1;
            DataRow1.dll_obj = this;
            Base_obj = DataRow1;
        }

        public DataRow Base_obj;

        //Свойства============================================================

        [ContextProperty("Состояние", "RowState")]
        public int RowState
        {
            get { return (int)Base_obj.RowState; }
        }

        [ContextProperty("Таблица", "Table")]
        public ClDataTable Table
        {
            get { return (ClDataTable)OneScriptForms.RevertObj(Base_obj.Table); }
        }

        //Методы============================================================

        [ContextMethod("ЗавершитьРедактирование", "EndEdit")]
        public void EndEdit()
        {
            Base_obj.EndEdit();
        }
					
        [ContextMethod("НачатьРедактирование", "BeginEdit")]
        public void BeginEdit()
        {
            Base_obj.BeginEdit();
        }

        [ContextMethod("ОтказИзменений", "RejectChanges")]
        public void RejectChanges()
        {
            Base_obj.RejectChanges();
        }
					
        [ContextMethod("ОтменаРедактирования", "CancelEdit")]
        public void CancelEdit()
        {
            Base_obj.CancelEdit();
        }
					
        [ContextMethod("ПринятьИзменения", "AcceptChanges")]
        public void AcceptChanges()
        {
            Base_obj.AcceptChanges();
        }
					
        [ContextMethod("Удалить", "Delete")]
        public void Delete()
        {
            Base_obj.Delete();
        }
					
        [ContextMethod("УстановитьЭлемент", "SetItem")]
        public void SetItem(IValue p1, IValue p2)
        {
            dynamic p3 = p1;
            if (p1.SystemType.Name == "Строка")
            {
                p3 = p1.AsString();
            }
            else if (p1.SystemType.Name == "Число")
            {
                p3 = Convert.ToInt32(p1.AsNumber());
            }

            if (p2.GetType().ToString().Contains("osf."))
            {
                Base_obj.SetItem(p3, OneScriptForms.RevertObj(p2));
            }
            else if (p2.SystemType.Name == "Строка")
            {
                Base_obj.SetItem(p3, p2.AsString());
            }
            else if (p2.SystemType.Name == "Булево")
            {
                Base_obj.SetItem(p3, p2.AsBoolean());
            }
            else if (p2.SystemType.Name == "Дата")
            {
                Base_obj.SetItem(p3, new System.DateTime(
                    p2.AsDate().Year,
                    p2.AsDate().Month,
                    p2.AsDate().Day,
                    p2.AsDate().Hour,
                    p2.AsDate().Minute,
                    p2.AsDate().Second
                    ));
            }
            else if (p2.SystemType.Name == "Число")
            {
                Base_obj.SetItem(p3, p2.AsNumber());
            }
        }

        [ContextMethod("Элемент", "Item")]
        public ClDataItem Item(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return new ClDataItem((DataItem)Base_obj.get_Item(p1.AsString()));
            }
            return new ClDataItem((DataItem)Base_obj.get_Item(Convert.ToInt32(p1.AsNumber())));
        }
    }
}
