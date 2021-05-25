using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class LinkCollection
    {
        public ClLinkCollection dll_obj;
        public System.Windows.Forms.LinkLabel.LinkCollection M_LinkCollection;

        public LinkCollection(System.Windows.Forms.LinkLabel p1)
        {
            M_LinkCollection = p1.Links;
        }

        public LinkCollection(System.Windows.Forms.LinkLabel.LinkCollection p1)
        {
            M_LinkCollection = p1;
        }

        //Свойства============================================================

        public int Count
        {
            get { return M_LinkCollection.Count; }
        }

        public bool IsReadOnly
        {
            get { return M_LinkCollection.IsReadOnly; }
        }

        public bool LinksAdded
        {
            get { return M_LinkCollection.LinksAdded; }
        }

        public virtual object this[int index]
        {
            get { return M_LinkCollection[index]; }
            set { M_LinkCollection[index] = (System.Windows.Forms.LinkLabel.Link)value; }
        }

        //Методы============================================================

        public int Add(osf.Link p1)
        {
            return M_LinkCollection.Add((System.Windows.Forms.LinkLabel.Link)p1.M_Link);
        }

        public void Clear()
        {
            M_LinkCollection.Clear();
        }

        public void Remove(osf.Link p1)
        {
            M_LinkCollection.Remove((System.Windows.Forms.LinkLabel.Link)p1.M_Link);
        }

        public void RemoveAt(int p1)
        {
            M_LinkCollection.RemoveAt(p1);
        }

    }

    [ContextClass ("КлКоллекцияСсылок", "ClLinkCollection")]
    public class ClLinkCollection : AutoContext<ClLinkCollection>
    {

        public ClLinkCollection(LinkCollection p1)
        {
            LinkCollection LinkCollection1 = p1;
            LinkCollection1.dll_obj = this;
            Base_obj = LinkCollection1;
        }

        public LinkCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextProperty("СсылкиДобавлены", "LinksAdded")]
        public bool LinksAdded
        {
            get { return Base_obj.LinksAdded; }
        }

        [ContextProperty("ТолькоЧтение", "IsReadOnly")]
        public bool IsReadOnly
        {
            get { return Base_obj.IsReadOnly; }
        }

        //Методы============================================================

        [ContextMethod("Добавить", "Add")]
        public int Add(ClLink p1)
        {
            return Base_obj.Add(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClLink p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClLink Item(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return new ClLink(Base_obj.M_LinkCollection[p1.AsString()]);
            }
            else if (p1.SystemType.Name == "Число")
            {
                return new ClLink(Base_obj.M_LinkCollection[Convert.ToInt32(p1.AsNumber())]);
            }
            return null;
        }
    }
}
