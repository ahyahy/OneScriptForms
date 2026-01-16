using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataSetEx : System.Data.DataSet
    {
        public osf.DataSet M_Object;
    }

    public class DataSet
    {
        public ClDataSet dll_obj;
        public DataSetEx M_DataSet;

        public DataSet()
        {
            M_DataSet = new DataSetEx();
            M_DataSet.M_Object = this;
        }

        public DataSet(osf.DataSet p1)
        {
            M_DataSet = p1.M_DataSet;
            M_DataSet.M_Object = this;
        }

        public DataSet(System.Data.DataSet p1)
        {
            M_DataSet = (DataSetEx)p1;
            M_DataSet.M_Object = this;
        }

        public string DataSetName
        {
            get { return M_DataSet.DataSetName; }
            set { M_DataSet.DataSetName = value; }
        }

        public osf.DataTableCollection Tables
        {
            get
            {
                if (M_DataSet.Tables != null)
                {
                    return new DataTableCollection(M_DataSet.Tables);
                }
                return null;
            }
        }

        public void AcceptChanges()
        {
            M_DataSet.AcceptChanges();
        }

        public bool HasChanges()
        {
            return M_DataSet.HasChanges();
        }

        public void RejectChanges()
        {
            M_DataSet.RejectChanges();
        }
    }

    [ContextClass("КлНаборДанных", "ClDataSet")]
    public class ClDataSet : AutoContext<ClDataSet>
    {
        private ClDataTableCollection tables;

        public ClDataSet()
        {
            DataSet DataSet1 = new DataSet();
            DataSet1.dll_obj = this;
            Base_obj = DataSet1;
            tables = new ClDataTableCollection(Base_obj.Tables);
        }

        public ClDataSet(DataSet p1)
        {
            DataSet DataSet1 = p1;
            DataSet1.dll_obj = this;
            Base_obj = DataSet1;
            tables = new ClDataTableCollection(Base_obj.Tables);
        }

        public DataSet Base_obj;

        [ContextProperty("ИмяНабораДанных", "DataSetName")]
        public string DataSetName
        {
            get { return Base_obj.DataSetName; }
            set { Base_obj.DataSetName = value; }
        }

        [ContextProperty("Таблицы", "Tables")]
        public ClDataTableCollection Tables
        {
            get { return tables; }
        }

        [ContextMethod("Изменен", "HasChanges")]
        public bool HasChanges()
        {
            return Base_obj.HasChanges();
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

        [ContextMethod("Таблицы", "Tables")]
        public ClDataTable Tables2(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return Base_obj.Tables[p1.AsString()].dll_obj;
            }
            else if (p1.SystemType.Name == "Число")
            {
                return Base_obj.Tables[Convert.ToInt32(p1.AsNumber())].dll_obj;
            }
            return null;
        }
    }
}
