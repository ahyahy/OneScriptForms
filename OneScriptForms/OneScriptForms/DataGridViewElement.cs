using System;
using Microsoft.VisualBasic;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osf
{
    public class DataGridViewElement : System.Windows.Forms.DataGridViewElement
    {
        public ClDataGridViewElement dll_obj;
        public System.Windows.Forms.DataGridViewElement M_DataGridViewElement;

        public new osf.DataGridView DataGridView
        {
            get { return new osf.DataGridView(M_DataGridViewElement.DataGridView); }
        }
    }

    [ContextClass ("КлЭлементТаблицы", "ClDataGridViewElement")]
    public class ClDataGridViewElement : AutoContext<ClDataGridViewElement>
    {
        public ClDataGridViewElement()
        {
            DataGridViewElement DataGridViewElement1 = new DataGridViewElement();
            DataGridViewElement1.dll_obj = this;
            Base_obj = DataGridViewElement1;
        }
		
        public ClDataGridViewElement(DataGridViewElement p1)
        {
            DataGridViewElement DataGridViewElement1 = p1;
            DataGridViewElement1.dll_obj = this;
            Base_obj = DataGridViewElement1;
        }
        
        public DataGridViewElement Base_obj;
        
        [ContextProperty("Таблица", "DataGridView")]
        public ClDataGridView DataGridView
        {
            get { return (ClDataGridView)OneScriptForms.RevertObj(Base_obj.DataGridView); }
        }
        
    }
}
