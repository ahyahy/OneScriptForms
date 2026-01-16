using System.Collections.Generic;
using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ControlCollection : CollectionBase
    {
        public ClControlCollection dll_obj;
        public System.Windows.Forms.Control.ControlCollection M_ControlCollection;

        public ControlCollection()
        {
        }

        public ControlCollection(System.Windows.Forms.Control.ControlCollection p1)
        {
            M_ControlCollection = p1;
            base.List = M_ControlCollection;
        }

        public override object Current
        {
            get
            {
                object objectValue = Enumerator.Current;
                if (objectValue != null)
                {
                    return new Control(((dynamic)objectValue).M_Control);
                }
                return null;
            }
        }

        public new osf.Control this[int p1]
        {
            get
            {
                if (M_ControlCollection[p1] != null)
                {
                    return (osf.Control)((dynamic)M_ControlCollection[p1]).M_Object;
                }
                return null;
            }
        }

        public osf.Control Add(Control p1)
        {
            M_ControlCollection.Add(p1.M_Control);
            return (osf.Control)p1;
        }

        public osf.Button AddButton(string text = null, int left = 0, int top = 0, int width = 0, int height = 0)
        {
            Button Button1 = new Button();
            Button1.Text = text;
            Button1.Left = left;
            Button1.Top = top;
            Button1.Width = width;
            Button1.Height = height;
            M_ControlCollection.Add((System.Windows.Forms.Control)Button1.M_Button);
            //System.Windows.Forms.Application.DoEvents();
            return Button1;
        }

        public bool Contains(Control p1)
        {
            return M_ControlCollection.Contains(p1.M_Control);
        }

        public void Remove(Control p1)
        {
            M_ControlCollection.Remove(p1.M_Control);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void SetChildIndex(Control p1, int p2)
        {
            M_ControlCollection.SetChildIndex(p1.M_Control, p2);
            //System.Windows.Forms.Application.DoEvents();
        }
    }

    [ContextClass("КлЭлементыУправления", "ClControlCollection")]
    public class ClControlCollection : AutoContext<ClControlCollection>, ICollectionContext, IEnumerable<IValue>
    {
        public ClControlCollection()
        {
            ControlCollection ControlCollection1 = new ControlCollection();
            ControlCollection1.dll_obj = this;
            Base_obj = ControlCollection1;
        }

        public ClControlCollection(ControlCollection p1)
        {
            ControlCollection ControlCollection1 = p1;
            ControlCollection1.dll_obj = this;
            Base_obj = ControlCollection1;
        }

        public int Count()
        {
            return CountControl;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)this).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in Base_obj.M_ControlCollection)
            {
                yield return (((dynamic)item).M_Object.dll_obj as IValue);
            }
        }

        public ControlCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int CountControl
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Добавить", "Add")]
        public IValue Add(IValue p1)
        {
            Base_obj.Add(((dynamic)p1).Base_obj);
            //System.Windows.Forms.Application.DoEvents();
            return p1;
        }

        [ContextMethod("ДобавитьКнопку", "AddButton")]
        public ClButton AddButton(string p1 = null, int p2 = 0, int p3 = 0, int p4 = 0, int p5 = 0)
        {
            return new ClButton(Base_obj.AddButton(p1, p2, p3, p4, p5));
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(IValue p1)
        {
            int index1 = -1;
            for (int i = 0; i < Base_obj.Count; i++)
            {
                if (Base_obj[i] == ((dynamic)p1).Base_obj)
                {
                    index1 = i;
                    break;
                }
            }
            return index1;
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue p1)
        {
            return Base_obj.Contains(((dynamic)p1).Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(((dynamic)p1).Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("УстановитьИндексДочернего", "SetChildIndex")]
        public void SetChildIndex(IValue p1, int p2)
        {
            Base_obj.SetChildIndex(((osf.Control)((dynamic)p1).Base_obj), p2);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return OneScriptForms.RevertObj((osf.Control)Base_obj[p1]);
        }
    }
}
