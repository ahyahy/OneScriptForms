using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{

    public class ComboBoxObjectCollection : CollectionBase
    {
        public ClComboBoxObjectCollection dll_obj;
        public System.Windows.Forms.ComboBox.ObjectCollection M_ComboBoxObjectCollection;

        public ComboBoxObjectCollection()
        {
        }

        public ComboBoxObjectCollection(System.Windows.Forms.ComboBox.ObjectCollection p1)
        {
            M_ComboBoxObjectCollection = p1;
            base.List = M_ComboBoxObjectCollection;
        }

        //Свойства============================================================

        public new object this[int index]
        {
            get { return M_ComboBoxObjectCollection[index]; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        //Методы============================================================

        public new object Add(object item)
        {
            M_ComboBoxObjectCollection.Add(item);
            System.Windows.Forms.Application.DoEvents();
            return item;
        }

        public new object Insert(int index, object item)
        {
            M_ComboBoxObjectCollection.Insert(index, item);
            System.Windows.Forms.Application.DoEvents();
            return item;
        }

        public new void Remove(object item)
        {
            M_ComboBoxObjectCollection.Remove(item);
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлЭлементыПоляВыбора", "ClComboBoxObjectCollection")]
    public class ClComboBoxObjectCollection : AutoContext<ClComboBoxObjectCollection>
    {
        public ArrayList heightItems;
        public ClComboBox m_obj;

        public ClComboBoxObjectCollection(ComboBoxObjectCollection p1)
        {
            ComboBoxObjectCollection ComboBoxObjectCollection1 = p1;
            ComboBoxObjectCollection1.dll_obj = this;
            Base_obj = ComboBoxObjectCollection1;
        }

        public ComboBoxObjectCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Вставить", "Insert")]
        public IValue Insert(int p1, IValue p2)
        {
            heightItems.Insert(p1, ValueFactory.Create(m_obj._HeightItems));
            osf.ClListItem p3 = new ClListItem();
            if (p2.GetType().ToString().Contains("osf.ClListItem"))
            {
                p3.Base_obj = ((osf.ClListItem)p2).Base_obj;
            }
            else
            {
                p3.Base_obj = new ListItem(p2.ToString(), p2);
            }
            Base_obj.Insert(p1, p3.Base_obj);
            return p3;
        }

        [ContextMethod("ВысотаЭлемента", "HeightItem")]
        public int HeightItem(int p1, IValue p2 = null)
        {
            if (m_obj.DrawMode == 2)
            {
                if (p2 != null)
                {
                    heightItems.RemoveAt(p1);
                    heightItems.Insert(p1, Convert.ToInt32(p2.AsNumber()));
                    return Convert.ToInt32(p2.AsNumber());
                }
                else
                {
                    System.Collections.ArrayList ArrayList2 = (System.Collections.ArrayList)heightItems.M_ArrayList;
                    return (int)ArrayList2[p1];
                }
            }
            return m_obj.Height;
        }
        
        [ContextMethod("Добавить", "Add")]
        public IValue Add(IValue p1)
        {
            m_obj.Base_obj.HeightItems.Add(ValueFactory.Create(m_obj.ItemHeight));
            osf.ClListItem p2;
            if (p1.GetType().ToString().Contains("osf.ClListItem"))
            {
                p2 = new ClListItem(((osf.ClListItem)p1).Base_obj);
            }
            else
            {
                string s = "";
                try
                {
                    s = p1.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
                }
                catch
                {
                    s = p1.ToString();
                }
                p2 = new ClListItem(new ListItem(s, p1));
            }
            Base_obj.Add(p2.Base_obj);
            return p2;
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClListItem p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1, IValue p2 = null)
        {
            osf.ListItem ListItem1 = new osf.ListItem();
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                if (p2.GetType().ToString().Contains("osf.ClListItem"))
                {
                    ListItem1 = ((dynamic)p2).Base_obj;
                }
                else
                {
                    ListItem1 = new osf.ListItem(p2.ToString(), p2);
                }
                Base_obj.Insert(p1, ListItem1);
            }
            else
            {
                if (Base_obj[p1].GetType().ToString() == "System.Data.DataRowView")
                {
                    osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj[p1]);
                    ListItem1.Text = DataRowView1.get_Item(m_obj.Base_obj.DisplayMember).ToString();
                    ListItem1.Value = DataRowView1.get_Item(m_obj.Base_obj.ValueMember);
                }
                else if (Base_obj[p1].GetType().ToString() == "osf.ListItem")
                {
                    ListItem1 = (osf.ListItem)Base_obj[p1];
                }
                else
                {
                    ListItem1.Text = Base_obj[p1].ToString();
                    ListItem1.Value = Base_obj[p1];
                    ListItem1.ForeColor = ((dynamic)Base_obj[p1]).ForeColor;
                }
            }
            return (IValue)new ClListItem(ListItem1);
        }
    }
}
