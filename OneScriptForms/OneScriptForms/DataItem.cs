using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataItem
    {
        public ClDataItem dll_obj;
        public object Index;
        public System.Data.DataRow M_DataRow;

        public DataItem()
        {
        }

        public DataItem(osf.DataItem p1)
        {
            M_DataRow = p1.M_DataRow;
            Index = p1.Index;
        }

        public DataItem(System.Data.DataRow p1, object p2)
        {
            M_DataRow = p1;
            Index = p2;
        }

        public osf.DataRow DataRow
        {
            get { return new DataRow(M_DataRow); }
            set { M_DataRow = value.M_DataRow; }
        }

        public object Value
        {
            get
            {
                if (Index != null)
                {
                    if (Index.GetType() == typeof(int))
                    {
                        return M_DataRow[Convert.ToInt32(Index)];
                    }
                    if (Index.GetType() == typeof(string))
                    {
                        return M_DataRow[Convert.ToString(Index)];
                    }
                }
                return null;
            }
            set
            {
                if (Index is string)
                {
                    M_DataRow[(string)Index] = value;
                }
                else
                {
                    M_DataRow[(int)Index] = value;
                }
            }
        }
    }

    [ContextClass("КлЭлементДанных", "ClDataItem")]
    public class ClDataItem : AutoContext<ClDataItem>
    {
        public ClDataItem()
        {
            DataItem DataItem1 = new DataItem();
            DataItem1.dll_obj = this;
            Base_obj = DataItem1;
        }

        public ClDataItem(DataItem p1)
        {
            DataItem DataItem1 = p1;
            DataItem1.dll_obj = this;
            Base_obj = DataItem1;
        }

        public DataItem Base_obj;

        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get { return OneScriptForms.RevertObj(Base_obj.Value); }
            set
            {
                Base_obj.Value = OneScriptForms.DefineTypeIValue(value);
            }
        }

        [ContextProperty("СтрокаДанных", "DataRow")]
        public ClDataRow DataRow
        {
            get { return (ClDataRow)OneScriptForms.RevertObj(Base_obj.DataRow); }
            set { Base_obj.DataRow = value.Base_obj; }
        }

    }
}
