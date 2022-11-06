using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeComboBoxObjectCollection : List<object>
    {
        public void SetControl(int index, dynamic item)
        {
            this[index] = item;
        }

        public new void Sort()
        {
            System.Collections.Generic.IComparer<object> myComparer = new ItemSorter();
            Sort(myComparer);
        }
    }

    public class ItemSorter : System.Collections.Generic.IComparer<object>
    {
        private dynamic x2;
        private dynamic y2;

        public int Compare(object x, object y)
        {
            x2 = osf.OneScriptForms.DefineTypeIValue(x);
            y2 = osf.OneScriptForms.DefineTypeIValue(y);
            int num = 0;
            if ((x2.GetType() != typeof(System.String)) && (y2.GetType() != typeof(System.String)))
            {
                num = 0;
            }
            else if ((x2.GetType() != typeof(System.String)) && (y2.GetType() == typeof(System.String)))
            {
                num = 1;
            }
            else if ((x2.GetType() == typeof(System.String)) && (y2.GetType() != typeof(System.String)))
            {
                num = -1;
            }
            else
            {
                num = ((System.String)x2).CompareTo((System.String)y2);
            }
            return num;
        }
    }
}
		
namespace osf
{

    [ContextClass("КлЭлементыПоляВыбораУзла", "ClNodeComboBoxObjectCollection")]
    public class ClNodeComboBoxObjectCollection : AutoContext<ClNodeComboBoxObjectCollection>
    {

        public ClNodeComboBoxObjectCollection(Aga.Controls.Tree.NodeControls.NodeComboBoxObjectCollection p1)
        {
            Base_obj = p1;
        }//end_constr

        public Aga.Controls.Tree.NodeControls.NodeComboBoxObjectCollection Base_obj;

        //Свойства============================================================
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, IValue p2)
        {
            Base_obj.Insert(p1, p2);
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(IValue p1)
        {
            Base_obj.Add(p1);
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(IValue p1)
        {
            return Base_obj.IndexOf(p1);
        }

        [ContextMethod("ОбратныйПорядок", "Reverse")]
        public void Reverse()
        {
            Base_obj.Reverse();
        }
					
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue p1)
        {
            return Base_obj.Contains(p1);
        }

        [ContextMethod("Сортировать", "Sort")]
        public void Sort()
        {
            Base_obj.Sort();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(p1);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("УстановитьЭлемент", "SetControl")]
        public void SetControl(int p1, IValue p2)
        {
            Base_obj.SetControl(p1, p2);
        }
        
        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return (IValue)Base_obj[p1];
        }
        
        //endMethods
    }//endClass

}//endnamespace
