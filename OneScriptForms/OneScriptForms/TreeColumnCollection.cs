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

namespace Aga.Controls.Tree
{
    public class TreeColumnCollection : Collection<TreeColumn>
    {
        private TreeViewAdv _treeView;

        public TreeColumnCollection(TreeViewAdv treeView)
        {
            _treeView = treeView;
        }

        protected override void InsertItem(int index, TreeColumn item)
        {
            base.InsertItem(index, item);
            BindEvents(item);
            _treeView.UpdateColumns();
        }

        protected override void RemoveItem(int index)
        {
            UnbindEvents(this[index]);
            base.RemoveItem(index);
            _treeView.UpdateColumns();
        }

        protected override void SetItem(int index, TreeColumn item)
        {
            UnbindEvents(this[index]);
            base.SetItem(index, item);
            item.Owner = this;
            BindEvents(item);
            _treeView.UpdateColumns();
        }

        protected override void ClearItems()
        {
            foreach (TreeColumn c in Items)
            {
                UnbindEvents(c);
            }
            Items.Clear();
            _treeView.UpdateColumns();
        }

        private void BindEvents(TreeColumn item)
        {
            item.Owner = this;
            item.HeaderChanged += HeaderChanged;
            item.IsVisibleChanged += IsVisibleChanged;
            item.WidthChanged += WidthChanged;
            item.SortOrderChanged += SortOrderChanged;
        }

        private void UnbindEvents(TreeColumn item)
        {
            item.Owner = null;
            item.HeaderChanged -= HeaderChanged;
            item.IsVisibleChanged -= IsVisibleChanged;
            item.WidthChanged -= WidthChanged;
            item.SortOrderChanged -= SortOrderChanged;
        }

        void SortOrderChanged(object sender, EventArgs e)
        {
            TreeColumn changed = sender as TreeColumn;
            // Свойство сортировки может быть установлено только для одного столбца одновременно.
            if (changed.SortOrder != SortOrder.None)
            {
                foreach (TreeColumn col in this)
                {
                    if (col != changed)
                    {
                        col.SortOrder = SortOrder.None;
                    }
                }
            }
            _treeView.UpdateHeaders();
        }

        void WidthChanged(object sender, EventArgs e)
        {
            _treeView.ChangeColumnWidth(sender as TreeColumn);
        }

        void IsVisibleChanged(object sender, EventArgs e)
        {
            _treeView.FullUpdate();
        }

        void HeaderChanged(object sender, EventArgs e)
        {
            _treeView.UpdateView();
        }
		
        public void SetColumn(int p1, TreeColumn p2)
        {
            SetItem(p1, p2);
        }
    }
}

namespace osf
{

    [ContextClass("КлКолонкиДереваЗначений", "ClTreeColumnCollection")]
    public class ClTreeColumnCollection : AutoContext<ClTreeColumnCollection>
    {

        public ClTreeColumnCollection(Aga.Controls.Tree.TreeColumnCollection p1)
        {
            Base_obj = p1;
        }//end_constr

        public Aga.Controls.Tree.TreeColumnCollection Base_obj;

        //Свойства============================================================
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, ClTreeColumn p2)
        {
            Base_obj.Insert(p1, p2.Base_obj.M_TreeColumn);
        }
        
        [ContextMethod("Добавить", "Add")]
        public void Add(ClTreeColumn p1)
        {
            Base_obj.Add(p1.Base_obj.M_TreeColumn);
        }
        
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClTreeColumn p1)
        {
            return Base_obj.IndexOf(p1.Base_obj.M_TreeColumn);
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClTreeColumn p1)
        {
            return Base_obj.Contains(p1.Base_obj.M_TreeColumn);
        }
        
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClTreeColumn p1)
        {
            Base_obj.Remove(p1.Base_obj.M_TreeColumn);
        }
        
        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("УстановитьКолонку", "SetColumn")]
        public void SetColumn(int p1, ClTreeColumn p2)
        {
            Base_obj.SetColumn(p1, p2.Base_obj.M_TreeColumn);
        }
        
        //endMethods
    }//endClass

}//endnamespace
