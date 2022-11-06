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

namespace osf
{

    [ContextClass("КлУзлыДереваЗначений", "ClTreeNodeAdvCollection")]
    public class ClNodeCollection : AutoContext<ClNodeCollection>
    {

        public ClNodeCollection(Aga.Controls.Tree.Node.NodeCollection p1)
        {
            Base_obj = p1;
        }//end_constr

        public Aga.Controls.Tree.Node.NodeCollection Base_obj;

        //Свойства============================================================
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, ClNode p2)
        {
            Base_obj.Insert(p1, p2.Base_obj);
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(ClNode p1)
        {
            Base_obj.Add(p1.Base_obj);
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClNode p1)
        {
            return Base_obj.IndexOf(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClNode p1)
        {
            return Base_obj.Contains(p1.Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClNode p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("УстановитьУзел", "SetNode")]
        public void SetNode(int p1, ClNode p2)
        {
            Base_obj.SetNode(p1, p2.Base_obj);
        }

        [ContextMethod("Элемент", "Item")]
        public ClNode Item(int p1)
        {
            return (ClNode)OneScriptForms.RevertObj(Base_obj[p1]);
        }

        //endMethods
    }//endClass

}//endnamespace
