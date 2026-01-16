using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeNodeCollection : CollectionBase
    {
        public ClTreeNodeCollection dll_obj;
        public System.Windows.Forms.TreeNodeCollection M_TreeNodeCollection;

        public TreeNodeCollection()
        {
        }

        public TreeNodeCollection(System.Windows.Forms.TreeNodeCollection p1)
        {
            M_TreeNodeCollection = p1;
            base.List = M_TreeNodeCollection;
        }

        public override object Current
        {
            get { return (object)((TreeNodeEx)(System.Windows.Forms.TreeNode)Enumerator.Current).M_Object; }
        }

        public new osf.TreeNode this[int index]
        {
            get { return ((TreeNodeEx)M_TreeNodeCollection[index]).M_Object; }
        }

        public osf.TreeNode Insert(int p1, TreeNode p2)
        {
            M_TreeNodeCollection.Insert(p1, p2.M_TreeNode);
            return p2;
        }

        public new osf.TreeNode Add(object p1)
        {
            if (p1 is TreeNode)
            {
                M_TreeNodeCollection.Add((System.Windows.Forms.TreeNode)((TreeNode)p1).M_TreeNode);
                //System.Windows.Forms.Application.DoEvents();
                return (TreeNode)p1;
            }
            TreeNode TreeNode1 = new TreeNode();
            TreeNode1.Text = Convert.ToString(p1);
            M_TreeNodeCollection.Add((System.Windows.Forms.TreeNode)((TreeNode)TreeNode1).M_TreeNode);
            //System.Windows.Forms.Application.DoEvents();
            return TreeNode1;
        }

        public void Remove(TreeNode TreeNode)
        {
            M_TreeNodeCollection.Remove((System.Windows.Forms.TreeNode)TreeNode.M_TreeNode);
        }
    }

    [ContextClass("КлУзлыДерева", "ClTreeNodeCollection")]
    public class ClTreeNodeCollection : AutoContext<ClTreeNodeCollection>
    {
        public ClTreeNodeCollection()
        {
            TreeNodeCollection TreeNodeCollection1 = new TreeNodeCollection();
            TreeNodeCollection1.dll_obj = this;
            Base_obj = TreeNodeCollection1;
        }

        public ClTreeNodeCollection(TreeNodeCollection p1)
        {
            TreeNodeCollection TreeNodeCollection1 = p1;
            TreeNodeCollection1.dll_obj = this;
            Base_obj = TreeNodeCollection1;
        }

        public TreeNodeCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Вставить", "Insert")]
        public ClTreeNode Insert(int p1, ClTreeNode p2)
        {
            return new ClTreeNode(Base_obj.Insert(p1, p2.Base_obj));
        }

        [ContextMethod("Добавить", "Add")]
        public ClTreeNode Add(IValue p1)
        {
            if (p1.GetType() == typeof(osf.ClTreeNode))
            {
                Base_obj.Add((TreeNode)((ClTreeNode)p1.AsObject()).Base_obj);
                return (ClTreeNode)p1;
            }
            else if (p1.SystemType.Name == "Строка")
            {
                ClTreeNode ClTreeNode1 = new ClTreeNode(new TreeNode(p1.AsString()));
                Base_obj.Add(ClTreeNode1.Base_obj);
                return ClTreeNode1;
            }
            return null;
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClTreeNode p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClTreeNode Item(int p1)
        {
            return (ClTreeNode)OneScriptForms.RevertObj(Base_obj[p1]);
        }
    }
}
