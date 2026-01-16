using System;
using System.Collections.ObjectModel;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeControlsCollection : Collection<NodeControl>
    {
        private TreeViewAdv _tree;

        public NodeControlsCollection(TreeViewAdv tree)
        {
            _tree = tree;
        }

        protected new void ClearItems()
        {
            _tree.BeginUpdate();
            try
            {
                while (this.Count != 0)
                {
                    this.RemoveAt(this.Count - 1);
                }
            }
            finally
            {
                _tree.EndUpdate();
            }
        }

        protected new void InsertItem(int index, NodeControl item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (item.Parent != _tree)
            {
                if (item.Parent != null)
                {
                    item.Parent.NodeControls.Remove(item);
                }
                base.InsertItem(index, item);
                item.AssignParent(_tree);
                _tree.FullUpdate();
            }
        }

        protected new void RemoveItem(int index)
        {
            NodeControl value = this[index];
            value.AssignParent(null);
            base.RemoveItem(index);
            _tree.FullUpdate();
        }

        protected new void SetItem(int index, NodeControl item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _tree.BeginUpdate();
            try
            {
                RemoveAt(index);
                InsertItem(index, item);
            }
            finally
            {
                _tree.EndUpdate();
            }
        }

        public void SetControl(int p1, NodeControl p2)
        {
            SetItem(p1, p2);
        }
    }
}

namespace osf
{

    [ContextClass("КлЭлементыУзла", "ClNodeControlsCollection")]
    public class ClNodeControlsCollection : AutoContext<ClNodeControlsCollection>
    {
        public ClTreeViewAdv TreeViewAdv;

        public ClNodeControlsCollection(Aga.Controls.Tree.NodeControls.NodeControlsCollection p1)
        {
            Base_obj = p1;
        }

        public Aga.Controls.Tree.NodeControls.NodeControlsCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, IValue p2)
        {
            Base_obj.Insert(p1, ((dynamic)p2.AsObject()).Base_obj);
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(IValue p1)
        {
            dynamic p2 = p1.AsObject();
            p2.Base_obj.Parent = this.TreeViewAdv.Base_obj.M_TreeViewAdv;
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(IValue p1)
        {
            return Base_obj.IndexOf(((dynamic)p1.AsObject()).Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue p1)
        {
            return Base_obj.Contains(((dynamic)p1.AsObject()).Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(((dynamic)p1.AsObject()).Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("УстановитьЭлемент", "SetControl")]
        public void SetControl(int p1, IValue p2)
        {
            Base_obj.SetControl(p1, ((dynamic)p2.AsObject()).Base_obj);
        }

    }
}
