using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ListViewItemEx : System.Windows.Forms.ListViewItem
    {
        public osf.ListViewItem M_Object;
    }

    public class ListViewItem
    {
        public ClListViewItem dll_obj;
        public ListViewItemEx M_ListViewItem;

        public ListViewItem(System.Windows.Forms.ListViewItem p1)
        {
            M_ListViewItem = (ListViewItemEx)p1;
            M_ListViewItem.M_Object = this;
        }

        public ListViewItem(osf.ListViewItem p1)
        {
            M_ListViewItem = p1.M_ListViewItem;
            M_ListViewItem.M_Object = this;
        }

        public ListViewItem(string text = "", int imageIndex = -1)
        {
            M_ListViewItem = new ListViewItemEx();
            M_ListViewItem.M_Object = this;
            M_ListViewItem.Text = text;
            M_ListViewItem.ImageIndex = imageIndex;
        }

        //Свойства============================================================

        public osf.Color BackColor
        {
            get { return new Color(M_ListViewItem.BackColor); }
            set
            {
                M_ListViewItem.BackColor = value.M_Color;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Rectangle Bounds
        {
            get { return new Rectangle(M_ListViewItem.Bounds); }
        }

        public bool Checked
        {
            get { return M_ListViewItem.Checked; }
            set
            {
                M_ListViewItem.Checked = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool Focused
        {
            get { return M_ListViewItem.Focused; }
            set
            {
                M_ListViewItem.Focused = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Font Font
        {
            get { return new Font(M_ListViewItem.Font); }
            set
            {
                M_ListViewItem.Font = value.M_Font;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_ListViewItem.ForeColor); }
            set
            {
                M_ListViewItem.ForeColor = value.M_Color;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int ImageIndex
        {
            get { return M_ListViewItem.ImageIndex; }
            set
            {
                M_ListViewItem.ImageIndex = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.ImageList ImageList
        {
            get { return new ImageList(M_ListViewItem.ImageList); }
        }

        public int Index
        {
            get { return M_ListViewItem.Index; }
        }

        public bool Selected
        {
            get { return M_ListViewItem.Selected; }
            set
            {
                M_ListViewItem.Selected = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.ListViewSubItemCollection SubItems
        {
            get { return new ListViewSubItemCollection(M_ListViewItem.SubItems); }
        }

        public object Tag
        {
            get { return M_ListViewItem.Tag; }
            set
            {
                M_ListViewItem.Tag = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Text
        {
            get { return M_ListViewItem.Text; }
            set
            {
                M_ListViewItem.Text = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool UseItemStyleForSubItems
        {
            get { return M_ListViewItem.UseItemStyleForSubItems; }
            set
            {
                M_ListViewItem.UseItemStyleForSubItems = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

        public void BeginEdit()
        {
            M_ListViewItem.BeginEdit();
            System.Windows.Forms.Application.DoEvents();
        }

        public void EnsureVisible()
        {
            M_ListViewItem.EnsureVisible();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Remove()
        {
            M_ListViewItem.Remove();
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлЭлементСпискаЭлементов", "ClListViewItem")]
    public class ClListViewItem : AutoContext<ClListViewItem>
    {
        private ClColor backColor;
        private ClRectangle bounds;
        private ClColor foreColor;
        private ClListViewSubItemCollection subItems;
        private ClCollection tag = new ClCollection();

        public ClListViewItem(string p1 = "", int p2 = -1)
        {
            ListViewItem ListViewItem1 = new ListViewItem(p1, p2);
            ListViewItem1.dll_obj = this;
            Base_obj = ListViewItem1;
            bounds = new ClRectangle(Base_obj.Bounds);
            foreColor = new ClColor(Base_obj.ForeColor);
            subItems = new ClListViewSubItemCollection(Base_obj.SubItems);
            backColor = new ClColor(Base_obj.BackColor);
        }
		
        public ClListViewItem(ListViewItem p1)
        {
            ListViewItem ListViewItem1 = p1;
            ListViewItem1.dll_obj = this;
            Base_obj = ListViewItem1;
            bounds = new ClRectangle(Base_obj.Bounds);
            foreColor = new ClColor(Base_obj.ForeColor);
            subItems = new ClListViewSubItemCollection(Base_obj.SubItems);
            backColor = new ClColor(Base_obj.BackColor);
        }

        public ListViewItem Base_obj;

        //Свойства============================================================

        [ContextProperty("Выбран", "Selected")]
        public bool Selected
        {
            get { return Base_obj.Selected; }
            set { Base_obj.Selected = value; }
        }

        [ContextProperty("Границы", "Bounds")]
        public ClRectangle Bounds
        {
            get { return bounds; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("ИндексИзображения", "ImageIndex")]
        public int ImageIndex
        {
            get { return Base_obj.ImageIndex; }
            set { Base_obj.ImageIndex = value; }
        }

        [ContextProperty("ИспользоватьСтильДляПодэлементов", "UseItemStyleForSubItems")]
        public bool UseItemStyleForSubItems
        {
            get { return Base_obj.UseItemStyleForSubItems; }
            set { Base_obj.UseItemStyleForSubItems = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set 
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Подэлементы", "SubItems")]
        public ClListViewSubItemCollection SubItems
        {
            get { return subItems; }
        }

        [ContextProperty("Помечен", "Checked")]
        public bool Checked
        {
            get { return Base_obj.Checked; }
            set { Base_obj.Checked = value; }
        }

        [ContextProperty("СписокИзображений", "ImageList")]
        public ClImageList ImageList
        {
            get { return (ClImageList)OneScriptForms.RevertObj(Base_obj.ImageList); }
        }

        [ContextProperty("Сфокусирован", "Focused")]
        public bool Focused
        {
            get { return Base_obj.Focused; }
            set { Base_obj.Focused = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set 
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.Font); }
            set 
            {
                Base_obj.Font = value.Base_obj; 
                Base_obj.Font.dll_obj = value;
            }
        }

        //Методы============================================================

        [ContextMethod("НачатьРедактирование", "BeginEdit")]
        public void BeginEdit()
        {
            Base_obj.BeginEdit();
        }
					
        [ContextMethod("ОбеспечитьОтображение", "EnsureVisible")]
        public void EnsureVisible()
        {
            Base_obj.EnsureVisible();
        }
					
        [ContextMethod("Подэлементы", "SubItems")]
        public ClListViewSubItem SubItems2(int p1)
        {
            return new ClListViewSubItem(Base_obj.SubItems[p1]);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove()
        {
            Base_obj.Remove();
        }
    }
}
