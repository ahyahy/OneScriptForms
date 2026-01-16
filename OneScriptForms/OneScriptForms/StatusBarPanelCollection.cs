using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class StatusBarPanelCollection : CollectionBase
    {
        public ClStatusBarPanelCollection dll_obj;
        public System.Windows.Forms.StatusBar.StatusBarPanelCollection M_StatusBarPanelCollection;

        public StatusBarPanelCollection()
        {
        }

        public StatusBarPanelCollection(System.Windows.Forms.StatusBar.StatusBarPanelCollection p1)
        {
            M_StatusBarPanelCollection = p1;
            base.List = M_StatusBarPanelCollection;
        }

        public override object Current
        {
            get { return (object)((StatusBarPanelEx)Enumerator.Current).M_Object; }
        }

        public new osf.StatusBarPanel this[int Index]
        {
            get { return ((StatusBarPanelEx)M_StatusBarPanelCollection[Index]).M_Object; }
        }

        public osf.StatusBarPanel Add(osf.StatusBarPanel p1)
        {
            M_StatusBarPanelCollection.Add(p1.M_StatusBarPanel);
            return p1;
        }

        public osf.StatusBarPanel Insert(int index, osf.StatusBarPanel p1)
        {
            M_StatusBarPanelCollection.Insert(index, p1.M_StatusBarPanel);
            return p1;
        }

        public void Remove(osf.StatusBarPanel p1)
        {
            M_StatusBarPanelCollection.Remove(p1.M_StatusBarPanel);
        }
    }

    [ContextClass("КлПанелиСтрокиСостояния", "ClStatusBarPanelCollection")]
    public class ClStatusBarPanelCollection : AutoContext<ClStatusBarPanelCollection>
    {
        public ClStatusBarPanelCollection()
        {
            StatusBarPanelCollection StatusBarPanelCollection1 = new StatusBarPanelCollection();
            StatusBarPanelCollection1.dll_obj = this;
            Base_obj = StatusBarPanelCollection1;
        }

        public ClStatusBarPanelCollection(StatusBarPanelCollection p1)
        {
            StatusBarPanelCollection StatusBarPanelCollection1 = p1;
            StatusBarPanelCollection1.dll_obj = this;
            Base_obj = StatusBarPanelCollection1;
        }

        public StatusBarPanelCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Вставить", "Insert")]
        public ClStatusBarPanel Insert(int p1, ClStatusBarPanel p2)
        {
            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj.Insert(p1, p2.Base_obj));
        }

        [ContextMethod("Добавить", "Add")]
        public ClStatusBarPanel Add(ClStatusBarPanel p1)
        {
            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj.Add(p1.Base_obj));
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClStatusBarPanel p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClStatusBarPanel Item(int p1, ClStatusBarPanel p2 = null)
        {
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                Base_obj.Insert(p1, p2.Base_obj);
                return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj[p1]);
            }
            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj[p1]);
        }
    }
}
