using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class DataRowView
    {
        public ClDataRowView dll_obj;
        public System.Data.DataRowView M_DataRowView;

        public DataRowView()
        {
        }

        public DataRowView(osf.DataRowView p1)
        {
            M_DataRowView = p1.M_DataRowView;
            OneScriptForms.AddToHashtable(M_DataRowView, this);
        }

        public DataRowView(System.Data.DataRowView p1)
        {
            M_DataRowView = p1;
            OneScriptForms.AddToHashtable(M_DataRowView, this);
        }

        //Свойства============================================================

        public object get_Item(object p1)
        {
            if (p1 is string)
            {
                return M_DataRowView[(string)p1];
            }
            return M_DataRowView[(int)p1];
        }

        public osf.DataRow Row
        {
            get { return new DataRow(M_DataRowView.Row); }
        }

        //Методы============================================================

        public void Delete()
        {
            M_DataRowView.Delete();
        }

        public void EndEdit()
        {
            M_DataRowView.EndEdit();
        }

        public void SetItem(object index, object item)
        {
            if (index is string)
            {
                M_DataRowView[(string)index] = item;
            }
            else
            {
                M_DataRowView[(int)index] = item;
            }
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлПредставлениеСтрокиДанных", "ClDataRowView")]
    public class ClDataRowView : AutoContext<ClDataRowView>
    {

        public ClDataRowView()
        {
            DataRowView DataRowView1 = new DataRowView();
            DataRowView1.dll_obj = this;
            Base_obj = DataRowView1;
        }
		
        public ClDataRowView(DataRowView p1)
        {
            DataRowView DataRowView1 = p1;
            DataRowView1.dll_obj = this;
            Base_obj = DataRowView1;
        }

        public ClDataRowView(System.Data.DataRowView p1)
        {
            DataRowView DataRowView1 = new DataRowView(p1);
            DataRowView1.dll_obj = this;
            Base_obj = DataRowView1;
        }

        public DataRowView Base_obj;

        //Свойства============================================================

        [ContextProperty("Строка", "Row")]
        public ClDataRow Row
        {
            get { return new ClDataRow(Base_obj.Row); }
        }

        //Методы============================================================

        [ContextMethod("ЗакончитьРедактирование", "EndEdit")]
        public void EndEdit()
        {
            Base_obj.EndEdit();
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
        public IValue Item(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return OneScriptForms.RevertObj(Base_obj.get_Item(p1.AsString()));
            }
            return OneScriptForms.RevertObj(Base_obj.get_Item(Convert.ToInt32(p1.AsNumber())));
        }
    }
}
