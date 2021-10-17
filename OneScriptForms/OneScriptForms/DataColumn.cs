using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataColumnEx : System.Data.DataColumn
    {
        public osf.DataColumn M_Object;

        public DataColumnEx()
        {
        }

        public DataColumnEx(string p1) : base(p1)
        {
        }

        public DataColumnEx(string p1, System.Type p2) : base(p1, p2)
        {
        }
    }

    public class DataColumn
    {
        public ClDataColumn dll_obj;
        public DataColumnEx M_DataColumn;

        public DataColumn()
        {
            M_DataColumn = new DataColumnEx();
            M_DataColumn.M_Object = this;
        }

        public DataColumn(osf.DataColumn p1)
        {
            M_DataColumn = p1.M_DataColumn;
            M_DataColumn.M_Object = this;
        }

        public DataColumn(string p1)
        {
            M_DataColumn = new DataColumnEx(p1);
            M_DataColumn.M_Object = this;
        }

        public DataColumn(string p1, System.Type p2)
        {
            M_DataColumn = new DataColumnEx(p1, p2);
            M_DataColumn.M_Object = this;
        }

        public DataColumn(System.Data.DataColumn p1)
        {
            M_DataColumn = (DataColumnEx)p1;
            M_DataColumn.M_Object = this;
        }

        //Свойства============================================================

        public bool AutoIncrement
        {
            get { return M_DataColumn.AutoIncrement; }
            set { M_DataColumn.AutoIncrement = value; }
        }

        public int AutoIncrementSeed
        {
            get { return Convert.ToInt32(M_DataColumn.AutoIncrementSeed); }
            set { M_DataColumn.AutoIncrementSeed = value; }
        }

        public int AutoIncrementStep
        {
            get { return Convert.ToInt32(M_DataColumn.AutoIncrementStep); }
            set { M_DataColumn.AutoIncrementStep = value; }
        }

        public string Caption
        {
            get { return M_DataColumn.Caption; }
            set { M_DataColumn.Caption = value; }
        }

        public string ColumnName
        {
            get { return M_DataColumn.ColumnName; }
            set { M_DataColumn.ColumnName = value; }
        }

        public System.Type DataType
        {
            get { return M_DataColumn.DataType; }
            set { M_DataColumn.DataType = value; }
        }

        public object DefaultValue
        {
            get { return M_DataColumn.DefaultValue; }
            set { M_DataColumn.DefaultValue = value; }
        }

        public int Ordinal
        {
            get { return M_DataColumn.Ordinal; }
        }

        public bool ReadOnly
        {
            get { return M_DataColumn.ReadOnly; }
            set { M_DataColumn.ReadOnly = value; }
        }

        public osf.DataTable Table
        {
            get { return  (DataTable)((DataTableEx)M_DataColumn.Table).M_Object; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлКолонкаДанных", "ClDataColumn")]
    public class ClDataColumn : AutoContext<ClDataColumn>
    {

        public ClDataColumn()
        {
            DataColumn DataColumn1 = new DataColumn();
            DataColumn1.dll_obj = this;
            Base_obj = DataColumn1;
        }

        public ClDataColumn(string p1)
        {
            DataColumn DataColumn1 = new DataColumn(p1);
            DataColumn1.dll_obj = this;
            Base_obj = DataColumn1;
        }
		
        public ClDataColumn(string p1, System.Type p2)
        {
            DataColumn DataColumn1 = new DataColumn(p1, p2);
            DataColumn1.dll_obj = this;
            Base_obj = DataColumn1;
        }

        public ClDataColumn(DataColumn p1)
        {
            DataColumn DataColumn1 = p1;
            DataColumn1.dll_obj = this;
            Base_obj = DataColumn1;
        }

        public DataColumn Base_obj;

        //Свойства============================================================

        [ContextProperty("АвтоПриращение", "AutoIncrement")]
        public bool AutoIncrement
        {
            get { return Base_obj.AutoIncrement; }
            set { Base_obj.AutoIncrement = value; }
        }

        [ContextProperty("Заголовок", "Caption")]
        public string Caption
        {
            get { return Base_obj.Caption; }
            set { Base_obj.Caption = value; }
        }

        [ContextProperty("ЗначениеПоУмолчанию", "DefaultValue")]
        public IValue DefaultValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.DefaultValue); }
            set
            {
                if (value.GetType().ToString().Contains("osf."))
                {
                    Base_obj.DefaultValue = value;
                }
                else if (value.SystemType.Name == "Строка")
                {
                    Base_obj.DefaultValue = value.AsString();
                }
                else if (value.SystemType.Name == "Булево")
                {
                    Base_obj.DefaultValue = value.AsBoolean();
                }
                else if (value.SystemType.Name == "Дата")
                {
                    Base_obj.DefaultValue = new System.DateTime(
                        value.AsDate().Year,
                        value.AsDate().Month,
                        value.AsDate().Day,
                        value.AsDate().Hour,
                        value.AsDate().Minute,
                        value.AsDate().Second
                        );
                }
                else if (value.SystemType.Name == "Число")
                {
                    Base_obj.DefaultValue = value.AsNumber();
                }
                else
                {
                    Base_obj.DefaultValue = value;
                }
            }
        }

        [ContextProperty("ИмяКолонки", "ColumnName")]
        public string ColumnName
        {
            get { return Base_obj.ColumnName; }
            set { Base_obj.ColumnName = value; }
        }

        [ContextProperty("НачальноеЧисло", "AutoIncrementSeed")]
        public int AutoIncrementSeed
        {
            get { return Base_obj.AutoIncrementSeed; }
            set { Base_obj.AutoIncrementSeed = value; }
        }

        [ContextProperty("Позиция", "Ordinal")]
        public int Ordinal
        {
            get { return Base_obj.Ordinal; }
        }

        [ContextProperty("Таблица", "Table")]
        public ClDataTable Table
        {
            get { return (ClDataTable)OneScriptForms.RevertObj(Base_obj.Table); }
        }

        [ContextProperty("ТипДанных", "DataType")]
        public new IValue DataType
        {
            get
            {
                if (Base_obj.DataType == typeof(System.String))
                {
                    return ValueFactory.Create(0);
                }
                if (Base_obj.DataType == typeof(System.Decimal))
                {
                    return ValueFactory.Create(1);
                }
                if (Base_obj.DataType == typeof(System.Boolean))
                {
                    return ValueFactory.Create(2);
                }
                if (Base_obj.DataType == typeof(System.DateTime))
                {
                    return ValueFactory.Create(3);
                }
                if (Base_obj.DataType == typeof(System.Object))
                {
                    return ValueFactory.Create(4);
                }
                return null;
            }
            set
            {
                Base_obj.DataType = typeof(ScriptEngine.Machine.Values.StringValue);
                int type1 = Convert.ToInt32(value.AsNumber());
                if (type1 == 0)
                {
                    Base_obj.DataType = typeof(System.String);
                }
                else if (type1 == 1)
                {
                    Base_obj.DataType = typeof(System.Decimal);
                }
                else if (type1 == 2)
                {
                    Base_obj.DataType = typeof(System.Boolean);
                }
                else if (type1 == 3)
                {
                    Base_obj.DataType = typeof(System.DateTime);
                }
                else if (type1 == 4)
                {
                    Base_obj.DataType = typeof(System.Object);
                }
            }
        }

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("ШагПриращения", "AutoIncrementStep")]
        public int AutoIncrementStep
        {
            get { return Base_obj.AutoIncrementStep; }
            set { Base_obj.AutoIncrementStep = value; }
        }

        //Методы============================================================

    }
}
