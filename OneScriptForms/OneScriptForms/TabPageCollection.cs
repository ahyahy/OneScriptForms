using System;
using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TabPageCollection : IEnumerable, IEnumerator
    {
        public ClTabPageCollection dll_obj;
        private System.Collections.IEnumerator Enumerator;
        public System.Windows.Forms.TabControl.TabPageCollection M_TabPageCollection;

        public TabPageCollection(System.Windows.Forms.TabControl.TabPageCollection p1)
        {
            M_TabPageCollection = p1;
        }

        public int Count
        {
            get { return M_TabPageCollection.Count; }
        }

        public object Current
        {
            get { return ((TabPageEx)Enumerator.Current).M_Object; }
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public osf.TabPage this[int index]
        {
            get { return (TabPage)((TabPageEx)M_TabPageCollection[index]).M_Object; }
        }

        public TabPage Add(TabPage page)
        {
            M_TabPageCollection.Add(page.M_TabPage);
            return page;
        }

        public void Clear()
        {
            M_TabPageCollection.Clear();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Enumerator = M_TabPageCollection.GetEnumerator();
            return (IEnumerator)this;
        }

        public int IndexOf(TabPage page)
        {
            return M_TabPageCollection.IndexOf((System.Windows.Forms.TabPage)page.M_TabPage);
        }

        public osf.TabPage Insert(int index, object page)
        {
            if (page is TabPage)
            {
                M_TabPageCollection.Insert(index, ((dynamic)page).M_TabPage);
                System.Windows.Forms.Application.DoEvents();
                return (TabPage)page;
            }
            if (!(page is string))
            {
                return null;
            }
            TabPage TabPage1 = new TabPage((string)null);
            TabPage1.Text = Convert.ToString(page);
            M_TabPageCollection.Insert(index, (System.Windows.Forms.TabPage)TabPage1.M_TabPage);
            return TabPage1;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(TabPage page)
        {
            M_TabPageCollection.Remove((System.Windows.Forms.TabPage)page.M_TabPage);
        }

        public void RemoveAt(int index)
        {
            M_TabPageCollection.RemoveAt(index);
        }
    }

    [ContextClass ("КлВкладки", "ClTabPageCollection")]
    public class ClTabPageCollection : AutoContext<ClTabPageCollection>
    {
        public ClTabPageCollection(TabPageCollection p1)
        {
            TabPageCollection TabPageCollection1 = p1;
            TabPageCollection1.dll_obj = this;
            Base_obj = TabPageCollection1;
        }

        public TabPageCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public ClTabPage Insert(int p1, IValue p2)
        {
            if (p2.SystemType.Name == "КлВкладка")
            {
                ClTabPage ClTabPage1 = new ClTabPage(((ClTabPage)p2).Text);
                Base_obj.Insert(p1, ClTabPage1.Base_obj);
                return ClTabPage1;
            }
            else if (p2.SystemType.Name == "Строка")
            {
                ClTabPage ClTabPage1 = new ClTabPage(p2.AsString());
                Base_obj.Insert(p1, ClTabPage1.Base_obj);
                return ClTabPage1;
            }
            else
            {
                return null;
            }
        }
        
        [ContextMethod("Добавить", "Add")]
        public ClTabPage Add(ClTabPage p1)
        {
            return Base_obj.Add(p1.Base_obj).dll_obj;
        }
        
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClTabPage p1)
        {
            return Base_obj.IndexOf(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClTabPage p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClTabPage Item(int p1, ClTabPage p2 = null)
        {
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                Base_obj.Insert(p1, p2.Base_obj);
                return p2;
            }
            else
            {
                return Base_obj[p1].dll_obj;
            }
        }
    }
}
