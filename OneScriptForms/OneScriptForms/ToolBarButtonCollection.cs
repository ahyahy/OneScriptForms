using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ToolBarButtonCollection : CollectionBase
    {
        public ClToolBarButtonCollection dll_obj;
        private System.Windows.Forms.ToolBar.ToolBarButtonCollection M_ToolBarButtonCollection;

        public ToolBarButtonCollection()
        {
        }

        public ToolBarButtonCollection(System.Windows.Forms.ToolBar.ToolBarButtonCollection p1)
        {
            M_ToolBarButtonCollection = p1;
            base.List = M_ToolBarButtonCollection;
        }

        public override object Current
        {
            get { return (object)((ToolBarButtonEx)((System.Windows.Forms.ToolBarButton)Enumerator.Current)).M_Object; }
        }

        public new osf.ToolBarButton this[int Index]
        {
            get { return ((ToolBarButtonEx)M_ToolBarButtonCollection[Index]).M_Object; }
            set
            {
            }
        }

        public osf.ToolBarButton Add(ToolBarButton ToolBarButton)
        {
            M_ToolBarButtonCollection.Add(ToolBarButton.M_ToolBarButton);
            return ToolBarButton;
        }

        public osf.ToolBarButton Insert(int index, ToolBarButton ToolBarButton)
        {
            M_ToolBarButtonCollection.Insert(index, ToolBarButton.M_ToolBarButton);
            return ToolBarButton;
        }

        public void Remove(ToolBarButton ToolBarButton)
        {
            M_ToolBarButtonCollection.Remove(ToolBarButton.M_ToolBarButton);
        }
    }

    [ContextClass ("КлКнопкиПанелиИнструментов", "ClToolBarButtonCollection")]
    public class ClToolBarButtonCollection : AutoContext<ClToolBarButtonCollection>
    {
        public ClToolBarButtonCollection()
        {
            ToolBarButtonCollection ToolBarButtonCollection1 = new ToolBarButtonCollection();
            ToolBarButtonCollection1.dll_obj = this;
            Base_obj = ToolBarButtonCollection1;
        }
		
        public ClToolBarButtonCollection(ToolBarButtonCollection p1)
        {
            ToolBarButtonCollection ToolBarButtonCollection1 = p1;
            ToolBarButtonCollection1.dll_obj = this;
            Base_obj = ToolBarButtonCollection1;
        }
        
        public ToolBarButtonCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public ClToolBarButton Insert(int p1, ClToolBarButton p2)
        {
            return new ClToolBarButton(Base_obj.Insert(p1, p2.Base_obj));
        }

        [ContextMethod("Добавить", "Add")]
        public ClToolBarButton Add(ClToolBarButton p1)
        {
            return new ClToolBarButton(Base_obj.Add(p1.Base_obj));
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClToolBarButton p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClToolBarButton Item(int p1, ClToolBarButton p2 = null)
        {
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                Base_obj.Insert(p1, p2.Base_obj);
                return p2;
            }
            else
            {
                return new ClToolBarButton(Base_obj[p1]);
            }
        }
    }
}
